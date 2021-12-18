using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DAL
{
    public class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float? Discount { get; set; }
        public string Desciption { get; set; }
        public byte[] Photo { get; set; }

        public Category Category { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
