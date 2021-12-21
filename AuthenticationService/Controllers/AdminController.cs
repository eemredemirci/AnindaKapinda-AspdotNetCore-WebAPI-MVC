using AnindaKapinda.API.Services;
using AnindaKapinda.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : BaseController
    {
        public AdminController(AnindaKapindaDbContext context, IMailService mailService) : base(context, mailService)
        {
        }

        // SupplyOfficer ekle
        [HttpPost]
        public async Task<IActionResult> AddSupplyOfficer(SupplyOfficer supplyOfficer)
        {
            var mail = context.SupplyOfficers.SingleOrDefault(a => a.Mail == supplyOfficer.Mail);

            // Mail kayıtlarda yoksa
            if (mail == null)
            {
                context.AddRange(new SupplyOfficer
                {
                    Name = supplyOfficer.Name,
                    Surname = supplyOfficer.Surname,
                    Mail = supplyOfficer.Mail,
                    Password = supplyOfficer.Password,
                    BirthDate = supplyOfficer.BirthDate,
                    Phone = supplyOfficer.Phone,
                    IsAccountActive = false,
                    Role = "SupplyOfficer"

                });
                context.SaveChanges();

                User user = context.SupplyOfficers.SingleOrDefault(mail => mail.Mail == supplyOfficer.Mail);
                // Mail gönder

                await mailService.SendEmailAsync(user);

                return Ok("Hesap bilgileri için mailinizi kontrol ediniz");
            }

            return BadRequest("Kayıt oluşturulamadı");
        }

        // Kurye ekle
        [HttpPost]
        public async Task<IActionResult> AddCourier(Courier courier)
        {
            var mail = context.Couriers.SingleOrDefault(a => a.Mail == courier.Mail);
            
            // Mail kayıtlarda yoksa
            if (mail == null)
            {
                context.AddRange(new Courier
                {
                    Name = courier.Name,
                    Surname = courier.Surname,
                    Mail = courier.Mail,
                    Password = courier.Password,
                    BirthDate=courier.BirthDate,
                    Phone=courier.Phone,
                    IsAccountActive = false,
                    Role = "Courier",
                    Status="Müsait"

                });
                context.SaveChanges();

                User user = context.Couriers.SingleOrDefault(mail => mail.Mail == courier.Mail);
                // Mail gönder

                await mailService.SendEmailAsync(user);

                return Ok("Hesap bilgileri için mailinizi kontrol ediniz");
            }

            return BadRequest("Kayıt oluşturulamadı");
        }

    }
}
