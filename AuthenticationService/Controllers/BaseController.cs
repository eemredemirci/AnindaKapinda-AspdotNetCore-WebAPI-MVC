using AnindaKapinda.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using AnindaKapinda.API.Services;

namespace AnindaKapinda.API.Controllers
{
    public class BaseController : Controller
    {
        //public int _userId = 0;

        public User account;
        public Address currentAddress;
        protected readonly AnindaKapindaDbContext context;
        public readonly IMailService mailService;
        
        public BaseController(AnindaKapindaDbContext dbcontext, IMailService mailServices)
        {
            context = dbcontext;
            mailService = mailServices;
        }

        public override void OnActionExecuting(ActionExecutingContext actioncontext)
        {
            try
            {
                account = UserInfo(HttpContext);
                currentAddress = null;
                //if (account == null || account.ID == 0)
                //{
                //    actioncontext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "User", action = "Login" }));
                //}
                //else
                //{
                //    var _action = actioncontext.ActionDescriptor.RouteValues["action"];
                //    var _controller = actioncontext.ActionDescriptor.RouteValues["controller"];
                //    if ((_action == "addupdate" || _action == "delete") && _controller == "Admin" && account.Role != "Admin")
                //    {
                //        actioncontext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "NotPermission" }));
                //    }
                //    _userId = account.ID;
                //}

            }
            catch (Exception)
            {
                //actioncontext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "User", action = "Login" }));
            }
        }

        public string WelcomeUser(HttpContext context)
        {
            User account = UserInfo(context);
            if (account != null && account.UserId != 0)
            {
                return "Hoşgeldiniz" + account.Name + " " + account.Surname;
            }
            return "";
        }

        public User UserInfo(HttpContext context)
        {
            var result = new User();
            var identity = (ClaimsIdentity)context.User.Identity;
            if (identity.IsAuthenticated)
            {
                result.UserId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
                result.Mail = User.FindFirstValue(ClaimTypes.Email);
                result.Name = User.FindFirstValue(ClaimTypes.Name);
                result.Role = User.FindFirstValue(ClaimTypes.Role);
            }
            return result;
        }
    }
}