using AnindaKapinda.API.Services;
using AnindaKapinda.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnindaKapinda.API.Controllers
{
    [Authorize(Roles = "Member")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CreditCardController : BaseController
    {
        public CreditCardController(AnindaKapindaDbContext context, IMailService mailService) : base(context, mailService)
        {

        }

        [HttpGet]
        public IActionResult GetCreditCards(CreditCard creditCard)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddCreditCard(CreditCard creditCard)
        {

            if (account == null)
            {
                return NotFound("Üye bulunamadı");
            }
            else
            {
                creditCard.MemberId = account.UserId;
                context.CreditCards.Add(creditCard);
                context.SaveChanges();

                return Ok(creditCard);
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteCreditCardById(int id)
        {
            CreditCard creditCard = context.CreditCards.SingleOrDefault(a => a.CreditCardId == id);

            if (creditCard == null)
            {
                return NotFound("Kredi kartı bilgisi bulanamadı");
            }
            else
            {
                context.CreditCards.Remove(creditCard);
                context.SaveChanges();

                return NoContent();
            }

        }
    }
}
