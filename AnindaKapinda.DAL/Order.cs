using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int CourierId { get; set; }
        public int MemberId { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }

        public string City { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string Detail { get; set; }

        public Member Member { get; set; }
        public Courier Courier { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
