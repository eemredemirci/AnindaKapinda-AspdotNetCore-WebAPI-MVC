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
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace AuthenticationService.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        AnindaKapindaDbContext context;
        private readonly TokenOption tokenOption;

        public AuthenticationController(AnindaKapindaDbContext dbContext)
        {
            context = dbContext;
        }
        [HttpPost]
        [Route("AddMember")]
        public IActionResult AddMember(Member member)
        {
            var mail =context.Members.SingleOrDefault(a=>a.Mail==member.Mail);
            if (mail!=null)
            {
                context.AddRange(new Member
                {
                    Name = member.Name,
                    Surname = member.Surname,
                    Mail = member.Mail,
                    Password=member.Password,
                    IsAccountActive=false,
                    Role="Member"
                });
                context.SaveChanges();
                return Ok("Üye başarıyla kaydedildi");
            }
            return BadRequest("Mail zaten kayıtlı");
        }
        [Route("Login")]
        public IActionResult Login(User user)
        {

            User login = context.Users.SingleOrDefault(a => a.Mail == user.Mail && a.Password == user.Password);

            //login is Instructor => true ise Instructor
            if (login != null)
            {
                TokenModel model = new TokenModel();

                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: tokenOption.Issuer,
                    expires: DateTime.Now.AddDays(tokenOption.AccessTokenExpiration),
                    notBefore: DateTime.Now,
                    claims: new List<Claim>() { new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()), new Claim(ClaimTypes.Role, "Instructor") },
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOption.SecurityKey)), SecurityAlgorithms.HmacSha256)
                );

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                model.AccessToken = tokenHandler.WriteToken(token);
                model.RefreshToken = Guid.NewGuid().ToString();
                model.RefreshTokenExpire = tokenOption.RefreshTokenExpiration;

                login.RefreshToken = model.RefreshToken;
                login.RefreshTokenDuration = model.RefreshTokenExpire;
                context.Users.Update(login);
                context.SaveChanges();

                return Ok(model);
            }
            else
            {
                return Unauthorized("Kullanıcı bulunamadı");
            }
        }
    }
}
