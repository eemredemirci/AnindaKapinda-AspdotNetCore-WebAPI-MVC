using AnindaKapinda.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda.API.Models.Repository
{
    public interface IAppUser 
    {
        User GetUser(ControllerBase controllerBase);
    }
}
