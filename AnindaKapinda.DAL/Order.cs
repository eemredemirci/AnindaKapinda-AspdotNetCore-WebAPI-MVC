using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DAL
{
    public class Order
    {
        public Order()
        {
            Members = new HashSet<Member>();
            Products = new HashSet<Product>();
        }
        public int ID { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public Courier Courier { get; set; }
        public Address Address { get; set; }
        public ICollection<Member> Members { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
