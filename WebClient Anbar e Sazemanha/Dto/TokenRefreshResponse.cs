using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient_Anbar_e_Sazemanha.Dto
{
    public class TokenRefreshResponse
    {
        public string token { get; set; }
        public string expire { get; set; }
        public string error_code { get; set; }
        public string error_message { get; set; }
    }
}
