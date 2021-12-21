using AnindaKapinda.API.Services;
using AnindaKapinda.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
            var filtered = context.Orders
                .Include(order => order.OrderDetails)
                .ToList();

            return Ok(filtered);
        }


        [HttpGet("{id}")]
        public IActionResult GetOrderByID(int id)
        {
            var filtered = context.Orders.Where(c => c.OrderId == id)
                .Include(c => c.OrderDetails)
                .ToList();

            if (filtered != null)
            {
                return Ok(filtered);
            }

            return NoContent();
        }


        [HttpPost("{creditcardId}")]
        public IActionResult AddOrder(Order order, int creditcardId)
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
            //else if (address == null)
            //{
            //    return NotFound("Adres bulunamadı");
            //}
            else
            {
                Order myOrder = new Order();

                myOrder.MemberId = member.UserId;
                myOrder.Status = "Hazırlanıyor";
                myOrder.Date = DateTime.Now;
                myOrder.City = address.City;
                myOrder.Province = address.Province;
                myOrder.District = address.District;
                myOrder.Street = address.Street;
                myOrder.Detail = address.Detail;
                myOrder.OrderDetails = order.OrderDetails;
                context.Orders.Add(myOrder);
                context.SaveChanges();

                OrderDetail myOrderDetail = new OrderDetail();


                myOrderDetail = context.OrderDetails.SingleOrDefault(o => o.OrderId == 0);

                Product product = context.Products.SingleOrDefault(p => p.ProductId == myOrderDetail.ProductId);
                //myOrderDetail.Product = product;

                myOrderDetail.OrderId = myOrder.OrderId;

                decimal totalPrice = 0;

                CreditCard creditCard = context.CreditCards.FirstOrDefault();
                string lastDigits = creditCard.Number.Substring(creditCard.Number.Length - 4);

                return Ok(" Sonu **** **** **** " + lastDigits + " ile biten kartınızdan" + totalPrice + "ödeme yapılmıştır");
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
