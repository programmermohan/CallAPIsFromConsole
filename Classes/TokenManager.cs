using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallAPIs.Classes
{
    public class TokenManager
    {
        public string Token { get; set; }

        public DateTime expiration { get; set; }

        public string User { get; set; }
    }
}
