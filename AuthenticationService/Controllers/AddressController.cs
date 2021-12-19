using AnindaKapinda.API.Models.Repository;
using AnindaKapinda.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class AddressController : BaseController
    {
        public AddressController(AnindaKapindaDbContext context) : base(context)
        {

        }

        //Adres ekle
        [HttpPost]
        public IActionResult AddAddress(Address address)
        {
            // Claim'den üye ID al
            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int id = int.Parse(userID);

            //ID den üyeyi bul
            Member member = context.Members.SingleOrDefault(a => a.ID == id);

            if (member == null)
            {
                return NotFound("Üye bulunamadı");
            }
            var city = context.Regions.SingleOrDefault(a => a.City == address.City);
            var province = context.Regions.SingleOrDefault(a => a.Province == address.Province);

            if (city == null)
            {
                return BadRequest("Geçici olarak " + address.City + " bölgesine hizmet verememekteyiz");

            }
            //Mail kayıtlarda yoksa
            else if (province == null)
            {
                return BadRequest("Geçici olarak " + address.Province + " bölgesine hizmet verememekteyiz");
            }
            else
            {
                address.MemberID = member.ID;
                context.Addresses.Add(address);
                context.SaveChanges();

                return Ok(address);
            }
        }
        //Adres sil
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAddressById(int id)
        {

            //ID den bul
            Address address = context.Addresses.SingleOrDefault(a => a.ID == id);

            if (address == null)
            {
                return NotFound("Adres bulanamadı");
            }
            else
            {
                context.Addresses.Remove(address);
                context.SaveChanges();

                return NoContent();
            }

        }
    }
}
