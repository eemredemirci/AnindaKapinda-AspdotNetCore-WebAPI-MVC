using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return Ok("Hoş geldiniz Admin");
        }
    }
}
