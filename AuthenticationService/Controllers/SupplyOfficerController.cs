using AnindaKapinda.API.Services;
using AnindaKapinda.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda.API.Controllers
{
    [Authorize(Roles = "SupplyOfficer")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupplyOfficerController : BaseController
    {
        public SupplyOfficerController(AnindaKapindaDbContext context, IMailService mailService) : base(context, mailService)
        {

        }
        public IActionResult GetOrder()
        {
            User user = context.Users.SingleOrDefault(a => a.UserId == account.UserId);
            if (user.IsAccountActive)
            {
                var filtered = context.Orders.Where(a => a.Status == "Hazırlanıyor")
                .ToList();
                return Ok(filtered);
            }
            else
            {
                return NotFound("Hesabınızı aktif etmek için şifre değişitiriniz");
            }
        }

        [HttpGet("{orderId}")]
        public IActionResult ForwardOrder(int orderId)
        {
            Order order = context.Orders.SingleOrDefault(a => a.OrderId == orderId);
            if(order==null)
            {
                return NotFound("Sipariş bulanamadı");
            }
            Courier courier = context.Couriers.SingleOrDefault(a => a.Status == "Müsait");
            if (courier == null)
            {
                return NotFound("Müsait kurye bulanamadı");
            }
            order.CourierId = courier.UserId;
            order.Status = "Yola Çıktı";
            context.Orders.Update(order);

            courier.Status = "Meşgul";
            context.Couriers.Update(courier);
            context.SaveChanges();
            return Ok(order);
        }

    }
}
