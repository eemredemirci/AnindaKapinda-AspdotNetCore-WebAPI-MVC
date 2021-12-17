using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DAL
{
    class AnindaKapindaDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<SupplyOfficer> SupplyOfficers { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Admin> Admins { get; set; }

    }
}
