using AnindaKapinda.API.Models;
using AnindaKapinda.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda.API.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(User user);
    }
}
