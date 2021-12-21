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
            if (account.IsAccountActive)
            {
                var filtered = context.Orders.Where(a => a.CourierId == account.UserId)
                .Include(order => order.OrderDetails)
                .ToList();
                return Ok(filtered);
            }
            else
            {
                return NotFound("Hesabınızı aktif etmek için şifre değişitiriniz");
            }
        }

        [HttpGet("{id}")]
        public IActionResult DeliverOrder(int orderId)
        {
            Order order = context.Orders.SingleOrDefault(a => a.OrderId == orderId);
            Courier courier = context.Couriers.FirstOrDefault();
            order.CourierId = courier.UserId;
            order.Status = "Yola Çıktı";
            return Ok();
        }

    }
}
