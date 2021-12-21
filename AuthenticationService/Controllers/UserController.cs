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
using AnindaKapinda.API.Controllers;
using AnindaKapinda.API.Services;
using AnindaKapinda.API.Models;

namespace AuthenticationService.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {

        //public List<Token> listTokens = new();

        public UserController(AnindaKapindaDbContext context, IMailService mailService) : base(context,mailService)
        {

        }

        

        // Sadece üye ekle
        [HttpPost]
        public async Task<IActionResult> AddMember(UserModelForRegister member)
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
            // Mail kayıtlarda yoksa
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

                User user = context.Members.SingleOrDefault(mail => mail.Mail == member.Mail);
                // Mail gönder
                
                await mailService.SendEmailAsync(user);

                return Ok("Hesap aktivasyonu için mailinizi kontrol ediniz");
            }

            return BadRequest("Kayıt oluşturulamadı");
        }



        // Hesabı Aktifleştir
        [HttpGet("{id}")]
        public IActionResult ActivateUser(int id)
        {
            // Hesabı update yap
            User user = context.Users.SingleOrDefault(a => a.UserId == id);
            user.IsAccountActive = true;
            context.SaveChanges();

            return Ok("Kullanıcı hesabı aktifleştirildi. Giriş yapabilirsiniz");
        }

        // Bütün kullanıcı girişleri
        [HttpPost]
        public IActionResult Login(User user)
        {
            //Admin yoksa defaultAdmin ekle
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

            // Kullanıcıyı bul
            User login = context.Users.SingleOrDefault(a => a.Mail == user.Mail && a.Password == user.Password);

            if (!login.IsAccountActive)
            {
                return BadRequest("Epostanıza gelen link ile hesabı aktifleştirin");
            }

            // Password Mail doğru mu?
            else if (login != null && login.Password == user.Password && login.Mail == user.Mail)
            {
                //Token üretiliyor.
                TokenHandler tokenHandler = new TokenHandler();
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
