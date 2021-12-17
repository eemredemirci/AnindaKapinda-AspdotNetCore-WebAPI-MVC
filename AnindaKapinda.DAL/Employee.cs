using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DAL
{
    [Table("Employees")]
    class Employee :User
    {
        public Employee()
        {
            Orders = new HashSet<Order>();
        }
        public DateTime BirthDate { get; set; }
        public int Phone { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
