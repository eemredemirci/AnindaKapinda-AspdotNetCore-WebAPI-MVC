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
    [Authorize(Roles = "Courier")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourierController : BaseController
    {
        public CourierController(AnindaKapindaDbContext context, IMailService mailService) : base(context, mailService)
        {

        }
        public IActionResult GetOrder()
        {
            User user = context.Users.SingleOrDefault(a => a.UserId == account.UserId);

            if (user.IsAccountActive)
            {
                var filtered = context.Orders.Where(a => a.CourierId == account.UserId && a.Status == "Yola Çıktı")
                .ToList();
                return Ok(filtered);
            }
            else
            {
                return NotFound("Hesabınızı aktif etmek için şifre değişitiriniz");
            }
        }

        [HttpGet("{orderId}/{status}")]
        public IActionResult DeliverOrder(int orderId, int status)
        {
            Order order = context.Orders.SingleOrDefault(a => a.OrderId == orderId);
            Courier courier = context.Couriers.FirstOrDefault();
            order.CourierId = courier.UserId;
            if(status==1)
            {
                order.Status = "Teslim edildi ";

            }
            else if (status == 2)
            {
                order.Status = "Adres eksik/hatalı ";

            }
            if (status == 3)
            {
                order.Status = "Üye adreste yok";
            }
            courier.Status = "Müsait";
            context.Couriers.Update(courier);
            context.Orders.Update(order);
            context.SaveChanges();
            return Ok(order);
        }

    }
}
