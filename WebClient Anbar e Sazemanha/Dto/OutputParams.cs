using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebClient_Anbar_e_Sazemanha.Dto
{
    public class OutputParams
    {
        public string id { get; set; }
        public string warehouse_id { get; set; }
        public string creator { get; set; }
        public string create_date { get; set; }
        public string owner_name { get; set; }
        public string province { get; set; }
        public string township { get; set; }
        public string city { get; set; }
        public string postal_code { get; set; }
        public string contractor_national_id { get; set; }
        public string contractor_name { get; set; }
        public List<ReceiptItemResponse> receipt_items { get; set; } = new List<ReceiptItemResponse>();
        public string error_code { get; set; }
        public string error_message { get; set; }
        public string failed_condition { get; set; }
        public string failed_item { get; set; }
        public string error_detail { get; set; }
    }
}
