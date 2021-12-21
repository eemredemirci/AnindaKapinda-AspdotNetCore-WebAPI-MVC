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
            if (account.IsAccountActive)
            {
                var filtered = context.Orders.Where(a => a.Status == "Hazırlanıyor")
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
        public IActionResult ForwardOrder(int orderId)
        {
            Order order = context.Orders.SingleOrDefault(a => a.OrderId == orderId);

            Courier courier = context.Couriers.SingleOrDefault(a => a.Status == "Müsait");

            order.CourierId = courier.UserId;
            order.Status = "Yola Çıktı";
            context.Orders.Update(order);

            courier.Status = "Meşgul";
            context.Couriers.Update(courier);

            return Ok();
        }

    }
}
