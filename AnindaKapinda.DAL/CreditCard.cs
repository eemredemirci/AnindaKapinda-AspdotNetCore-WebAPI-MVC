using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DAL
{
    class CreditCard
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public DateTime Expiry { get; set; }
        public int Secure { get; set; }
        
    }
}
