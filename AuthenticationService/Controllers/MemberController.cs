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
using AnindaKapinda.API.Services;

namespace AnindaKapinda.API.Controllers
{
    [Authorize(Roles = "Member")]
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class MemberController : BaseController
    {

        public MemberController(AnindaKapindaDbContext context,IMailService mailService) : base(context, mailService)
        {
           
        }

        

        

        

    }
}
