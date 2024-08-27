using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListKaryawanAPI.Config
{
    public class Credential
    {
        public string Secret { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public string IssuerAdmin { get; set; }
        public string TokenLifeTime { get; set; }

    }
}
