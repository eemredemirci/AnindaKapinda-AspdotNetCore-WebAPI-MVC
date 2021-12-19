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
        public CreditCardController(AnindaKapindaDbContext context) : base(context)
        {

        }
       
        [HttpPost]
        public IActionResult AddCreditCard(CreditCard creditCard)
        {
            
            //ID den üyeyi bul
            Member member = context.Members.SingleOrDefault(a => a.ID == account.ID);

            if (member == null)
            {
                return NotFound("Üye bulunamadı");
            }
            else
            {
                creditCard.MemberID = member.ID;
                context.CreditCards.Add(creditCard);
                context.SaveChanges();

                return Ok(creditCard);
            }
        }
        
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCreditCardById(int id)
        {
            CreditCard creditCard = context.CreditCards.SingleOrDefault(a => a.ID == id);

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
