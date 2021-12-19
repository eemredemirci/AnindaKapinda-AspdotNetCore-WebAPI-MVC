using AnindaKapinda.API.Models.Repository;
using AnindaKapinda.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnindaKapinda.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        AnindaKapindaDbContext context;
        private readonly IAppUser _appUser;

        public AddressController(AnindaKapindaDbContext dbContext,IAppUser appUser)
        {
            context = dbContext;
            _appUser = appUser;
        }
        //Adres ekle
        [HttpPost]
        [Route("AdresEkle")]

        public IActionResult AddAddress(Address address)
        {
            // Claim'den üye ID al
            string userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int id = int.Parse(userID);

            //ID den üyeyi bul
            Member member = context.Members.SingleOrDefault(a => a.ID == id);
            if (member == null)
            {
                return NotFound("Member not found!");
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
    }
}
