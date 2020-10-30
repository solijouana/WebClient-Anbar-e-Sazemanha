using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient_Anbar_e_Sazemanha.Dto
{
    public class InputParams
    {
        public string number { get; set; }
        public string rcp_date { get; set; }
        public string warehouse_id { get; set; }
        public string postal_code { get; set; }
        public string contractor_national_id { get; set; }
        public string vehicle_number { get; set; }
        public string driver_national_id { get; set; }
        public string owner { get; set; }
        public string owner_birth_date { get; set; }
        public string driver_birth_date { get; set; }
        public string bol_tid { get; set; }
        public string bol_date { get; set; }
        public string bol_series { get; set; }
        public string bol_serial { get; set; }
        public List<ReceiptItem> receipt_items { get; set; } = new List<ReceiptItem>();
    }
}
