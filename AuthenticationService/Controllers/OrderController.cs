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
    [Authorize(Roles = "Member")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : BaseController
    {
        public OrderController(AnindaKapindaDbContext context, IMailService mailService) : base(context, mailService)
        {

        }

        public IActionResult GetOrder()
        {
            //Order orders = context.Orders.SingleOrDefault(o => o.MemberID == account.ID));
            //List<OrderDetail> orderDetails = context.OrderDetails.Where(details => details.OrderID == orders.ID).ToList();
            //if (orders != null)
            //{
            //    return Ok(orderDetails);
            //}

            return NoContent();
        }


        [HttpGet("{id}")]
        public IActionResult GetOrderByID(int id)
        {
            List<Order> orders = context.Orders.Where(c => c.OrderId == id).ToList();
            if (orders.Count != 0)
            {
                return Ok(orders);
            }

            return NoContent();
        }


        [HttpPost("{creditcardId}")]
        public IActionResult AddOrder(List<OrderDetail> orderDetail, int creditcardId)
        {
            //if(creditcardId ==0)
            //{
            //    return NotFound("Kredi kartı bilgileri bulunamadı");
            //}

            Member member = context.Members.SingleOrDefault(m => m.UserId == account.UserId);
            Address address = currentAddress;

            if (account == null)
            {
                return NotFound("Kullanıcı bulunamadı");
            }
            else if (address==null)
            {
                return NotFound("Adres bulunamadı");
            }
            else
            {
                Order order = new Order();
                order.MemberId = member.UserId;
                order.Status = "Hazırlanıyor";
                order.Date = DateTime.Now;
                order.City = address.City;
                order.Province = address.Province;
                order.District = address.District;
                order.Street = address.Street;
                order.Detail = address.Detail;

                

                order.OrderDetails = orderDetail;
                context.Orders.Add(order);
                context.SaveChanges();


                return Ok(order);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderById(int id)
        {
            //ID den bul
            Order order = context.Orders.SingleOrDefault(p => p.OrderId == id);

            if (account == null)
            {
                return NotFound("Kullanıcı bulunamadı");
            }
            else if (order == null)
            {
                return NotFound("Sipariş bulunamadı");
            }
            else
            {

                context.Orders.Remove(order);
                context.SaveChanges();

                return NoContent();
            }
        }

        //[HttpPut("{id}")]
        //public IActionResult UpdateOrder(Order order)
        //{
        //    Order updated = context.Orders.SingleOrDefault(p => p.ID == order.ID);

        //    if (account == null)
        //    {
        //        return NotFound("Admin bulunamadı");
        //    }
        //    else if (order == null)
        //    {
        //        return NotFound("Kategori bulunamadı");
        //    }
        //    else
        //    {
        //        updated.Name = order.Name;
        //        context.SaveChanges();
        //        return CreatedAtAction("GetOrderByID", "Order", new { id = order.ID });
        //    }
        //}
    }
}
