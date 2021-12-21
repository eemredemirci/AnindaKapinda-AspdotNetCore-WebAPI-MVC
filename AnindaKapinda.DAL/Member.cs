using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DAL
{
    [Table("Members")]
    public class Member : User
    {
        public Member()
        {
            Orders = new HashSet<Order>();
            Addresses = new HashSet<Address>();
            CreditCards = new HashSet<CreditCard>();
        }

        public ICollection<Address> Addresses { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<CreditCard> CreditCards { get; set; }
        
    }
}
