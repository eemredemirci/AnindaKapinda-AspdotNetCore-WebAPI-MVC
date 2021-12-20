using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AnindaKapinda.DAL;
using Microsoft.AspNetCore.Mvc;

namespace AnindaKapinda.API.Models.Repository
{
    public class AppUser :IAppUser
    {
        AnindaKapindaDbContext context;

        public AppUser(AnindaKapindaDbContext dbContext)
        {
            context = dbContext;
        }
        public User GetUser(ControllerBase controllerBase)
        {
            string userID = controllerBase.User.FindFirstValue(ClaimTypes.NameIdentifier);
            int id = int.Parse(userID);

            //ID den üyeyi bul
            User user = context.Members.SingleOrDefault(a => a.ID == id);
            return user;
        }
    }
}
