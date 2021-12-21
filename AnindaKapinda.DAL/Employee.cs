using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DAL
{
    [Table("Employees")]
    public class Employee :User
    {
        public DateTime BirthDate { get; set; }
        public int Phone { get; set; }

    }
}
