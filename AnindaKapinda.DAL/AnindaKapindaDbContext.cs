using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DAL
{
    public class AnindaKapindaDbContext : DbContext
    {
        public AnindaKapindaDbContext()
        {

        }
        public AnindaKapindaDbContext(DbContextOptions<AnindaKapindaDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SupplyOfficer> SupplyOfficers { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = AnindaKapinda;");
            }
        }
    }
}
