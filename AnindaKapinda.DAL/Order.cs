using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DAL
{
    class Order
    {
        public int ID { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public Courier Courier { get; set; }
    }
}
