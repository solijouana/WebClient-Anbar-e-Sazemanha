using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient_Anbar_e_Sazemanha.Dto
{
    public class ReceiptItem
    {
        public string good_id { get; set; }
        public int count { get; set; }
        public string measurement_unit { get; set; }
        public string production_type { get; set; }
    }
}
