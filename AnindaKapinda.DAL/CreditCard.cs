using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DAL
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public DateTime Expiry { get; set; }
        public int Secure { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }

    }
}
