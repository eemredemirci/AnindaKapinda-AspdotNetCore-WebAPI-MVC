using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnindaKapinda.API;
using FluentValidation.Results;
using AnindaKapinda.DAL;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AnindaKapinda.API.Controllers
{
    [Authorize(Roles = "Member")]
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class MemberController : ControllerBase
    {
        AnindaKapindaDbContext context;

        public MemberController(AnindaKapindaDbContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult GetOrders(Order order)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAddresses(Address address)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetCreditCards(CreditCard creditCard)
        {
            return Ok();
        }

    }
}
