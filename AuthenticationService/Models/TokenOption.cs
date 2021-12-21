using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Models
{
    public class TokenOption
    {
        public List<string> Audiences { get; set; }
        public string Issuer { get; set; }
        public string SecurityKey { get; set; }

    }
}
