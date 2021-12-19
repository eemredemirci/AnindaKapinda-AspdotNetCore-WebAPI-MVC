using AnindaKapinda.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthenticationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TestController : ControllerBase
    {
        [Authorize(Roles = "Member")]

        public IActionResult LoginTest()
        {
            return Ok("Hoş geldiniz member");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult LoginTest2()
        {
            
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok("Hoş geldiniz ID= "+id);
        }
    }
}
