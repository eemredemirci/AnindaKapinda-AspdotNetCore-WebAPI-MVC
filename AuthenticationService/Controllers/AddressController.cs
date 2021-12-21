using AnindaKapinda.API.Models.Repository;
using AnindaKapinda.API.Services;
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
        
        public AddressController(AnindaKapindaDbContext context, IMailService mailService) : base(context, mailService)
        {

        }

        [HttpGet]
        public IActionResult GetAddresses()
        {
            List<Address> addresses = context.Addresses.ToList();
            return Ok(addresses);
        }

        //Varsayılan Adresi seçme
        [HttpGet("{id}")]
        public IActionResult SelectAddressByID(int id)
        {
            currentAddress = context.Addresses.SingleOrDefault(a=>a.AddressId==id);
            return Ok(currentAddress);
        }

        //Adres ekle
        [HttpPost]
        public IActionResult AddAddress(Address address)
        {
            //// Claim'den üye ID al
            //string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //int id = int.Parse(userID);

            ////ID den üyeyi bul
            //Member member = context.Members.SingleOrDefault(a => a.ID == id);

            if (account == null)
            {
                return NotFound("Üye bulunamadı");
            }

            // Bölge kontrolü
            var city = context.Regions.SingleOrDefault(a => a.City == address.City);
            var province = context.Regions.SingleOrDefault(a => a.Province == address.Province);

            if (city == null)
            {
                return BadRequest("Geçici olarak " + address.City + " bölgesine hizmet verememekteyiz");

            }

            // Mail kayıtlarda yoksa
            else if (province == null)
            {
                return BadRequest("Geçici olarak " + address.Province + " bölgesine hizmet verememekteyiz");
            }
            else
            {
                address.MemberId = account.UserId;
                context.Addresses.Add(address);
                context.SaveChanges();

                return Ok(address);
            }
        }

        //Adres sil
        [HttpDelete("{id}")]
        public IActionResult DeleteAddressById(int id)
        {
            //ID den bul
            Address address = context.Addresses.SingleOrDefault(a => a.AddressId == id);

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
