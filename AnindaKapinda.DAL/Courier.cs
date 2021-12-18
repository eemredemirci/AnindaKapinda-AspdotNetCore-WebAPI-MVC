using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DAL
{
    [Table("Couriers")]
    public class Courier : Employee
    {
        public Courier()
        {
            Orders = new HashSet<Order>();

        }
        public string Status { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
