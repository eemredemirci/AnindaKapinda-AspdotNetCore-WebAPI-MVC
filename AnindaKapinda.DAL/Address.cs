using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DAL
{
    public class Address
    {
        public int AddressId { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string Detail { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
