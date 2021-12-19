using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnindaKapinda.DAL;
using AuthenticationService.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;
using AnindaKapinda.API;
using FluentValidation.Results;

namespace AuthenticationService.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        AnindaKapindaDbContext context;

        readonly IConfiguration _configuration;

        //public List<Token> listTokens = new();

        public AuthenticationController(AnindaKapindaDbContext dbContext, IConfiguration configuration)
        {
            context = dbContext;
            _configuration = configuration;
        }

        //Sadece üye ekle
        [HttpPost]
        public IActionResult AddMember(UserModelForRegister member)
        {
            var mail = context.Members.SingleOrDefault(a => a.Mail == member.Mail);
            UserValidator validator = new UserValidator();
            ValidationResult results = validator.Validate(member);

            if (!results.IsValid)
            {
                foreach (var error in results.Errors)
                {
                    string errorMessage = $"{error.PropertyName} -> {error.ErrorMessage}";
                    return BadRequest(errorMessage);
                }

            }
            //Mail kayıtlarda yoksa
            else if (mail == null)
            {
                context.AddRange(new Member
                {
                    Name = member.Name,
                    Surname = member.Surname,
                    Mail = member.Mail,
                    Password = member.Password,
                    IsAccountActive = false,
                    Role = "Member"

                });
                context.SaveChanges();

                return Ok("Üye başarıyla kaydedildi. Hesapınızı aktifleştirmek için e-postanızı kontrol ediniz.");
            }

            return BadRequest("Kayıt oluşturulamadı");
        }

        //Bütün kullanıcı girişleri
        [HttpPost]
        public IActionResult Login(User user)
        {
            //Admin yoksa ekle
            User admin = context.Users.SingleOrDefault(a => a.Role == "Admin");
            if (admin == null)
            {
                context.AddRange(new User
                {
                    Name = "admin",
                    Surname = "admin",
                    Mail = "admin@admin.com",
                    Password = "Admin1",
                    IsAccountActive = true,
                    Role = "Admin"

                });
                context.SaveChanges();
            }

            //Kullanıcıyı bul
            User login = context.Users.SingleOrDefault(a => a.Mail == user.Mail && a.Password == user.Password);

            //Password Mail doğru mu?
            if (login != null && login.Password == user.Password && login.Mail == user.Mail)
            {
                //Token üretiliyor.
                TokenHandler tokenHandler = new TokenHandler(_configuration);
                Token token = tokenHandler.CreateAccessToken(login);

                //Token kayıt ediliyor
                login.RefreshToken = token.RefreshToken;
                login.RefreshTokenEndDate = token.Expiration.AddMinutes(3);
                login.IsAccountActive = true;
                context.Users.Update(login);
                context.SaveChanges();

                //Token kotrolü
                //listTokens.Add(token);
                ////Token kontrolü
                //if(listTokens.Any(t=>t.RefreshToken==token.AccessToken&& t.Expiration>DateTime.Now))
                //{
                //    return Ok("Token Expired");
                //}

                return Ok(token);
            }
            else
            {
                return Unauthorized("Kullanıcı bulunamadı");
            }
        }
    }
}
