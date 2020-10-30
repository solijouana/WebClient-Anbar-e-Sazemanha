using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using WebClient_Anbar_e_Sazemanha.Dto;
using WebClient_Anbar_e_Sazemanha.Services;

namespace WebClient_Anbar_e_Sazemanha
{
    class Program
    {
        private static void Main(string[] args)
        {

            var client = new HttpClient();


            // read config file
            string baseUrl = ConfigurationManager.AppSettings["baseUrl"];
           // string path = ConfigurationManager.AppSettings["path"];
            string authTokenFilePath = ConfigurationManager.AppSettings["authTokenFilePath"];
            string basicAuthUser = ConfigurationManager.AppSettings["basicAuthUser"];
            string basicAuthPassword = ConfigurationManager.AppSettings["basicAuthPassword"];
            var basicAuthCredential = Encoding.ASCII.GetBytes(basicAuthUser + ":" + basicAuthPassword);
            AuthenticationHeaderValue ahv = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(basicAuthCredential));


            // متد زیر کلید امنیتی را تغییر می دهد
            // این متد نیاز نیست برای هر بار فراخوانی صدا زده شود . این متد وظیفه تازه سازی کلید امنیتی را دارد
            // بهتر است که در بازه های زمانی مشخصی (مثلا یک هفته ای ) این متد صدا زده شود
            //تا در صورت فاش شدن کلید امنیتی ، فرصت سواستفاده از کلید کاهش یابد
            // AuthToken.RefreshAuthToken(baseUrl, ahv, authTokenFilePath);



            // set input parameters
            InputParams input = new InputParams();
            input.bol_date = "";
            input.bol_serial = "";
            input.bol_series = "";

            input.bol_tid = "";
            input.contractor_national_id = "";
            input.driver_birth_date = "";
            input.driver_national_id = "";
            input.number = "";
            input.owner = "";
            input.owner_birth_date = "";
            input.postal_code = "";
            input.rcp_date = "";
            input.vehicle_number = "";
            input.warehouse_id = "";

            ReceiptItem rcp_item = new ReceiptItem();
            rcp_item.count = 0;
            rcp_item.good_id = "";
            rcp_item.measurement_unit = "";
            rcp_item.production_type = "";
            input.receipt_items.Add(rcp_item);
            ///////////////////////////////////////////////

            Receipt.Public_NWM_SReceiptPermanent(baseUrl,ahv,authTokenFilePath,input);
            Receipt.Public_NWM_SDraftPermanent(baseUrl,ahv,authTokenFilePath,input);

        }

    }
}



