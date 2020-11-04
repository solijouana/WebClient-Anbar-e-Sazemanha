using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WebClient_Anbar_e_Sazemanha.Dto;
using WebClient_Anbar_e_Sazemanha.Utilities;

namespace WebClient_Anbar_e_Sazemanha.Services
{
    public static class Receipt
    {
        public static void Public_NWM_SReceiptPermanent(string baseUrl, AuthenticationHeaderValue ahv,
            string authTokenFilePath, InputParams inputParams)
        {
            try
            {
                string authToken = TokenTools.GetAuthToken(authTokenFilePath);
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = ahv;
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("AuthToken", authToken);


                HttpResponseMessage response =
                    client.PostAsJsonAsync("services/PublicNWMSReceiptPermanent", inputParams).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                var statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    OutputParams output = JsonConvert.DeserializeObject<OutputParams>(result);
                    string error_code = output.error_code;
                    string error_message = output.error_message;
                    output = response.Content.ReadAsAsync<OutputParams>().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // print results
                        Console.WriteLine($"city: {output.city}");
                        Console.WriteLine($"province: {output.province}");
                        Console.WriteLine($"township: {output.township}");
                        Console.WriteLine($"contractor_name: {output.contractor_name}");
                        Console.WriteLine($"contractor_national_id: {output.contractor_national_id}");
                        Console.WriteLine($"create_date: {output.create_date}");
                        Console.WriteLine($"creator: {output.creator}");
                        Console.WriteLine($"warehouse_id: {output.warehouse_id}");
                        Console.WriteLine($"id: {output.id}");
                        Console.WriteLine($"owner_name: {output.owner_name}");
                        Console.WriteLine($"postal_code: {output.postal_code}");
                        Console.WriteLine($"receipt items:");
                        output.receipt_items.ForEach(delegate(ReceiptItemResponse rcp_item_resp)
                        {
                            Console.WriteLine($"\tid: {rcp_item_resp.id}");
                            Console.WriteLine($"\tgood_id: {rcp_item_resp.good_id}");
                            Console.WriteLine($"\tgood_desc: {rcp_item_resp.good_desc}");
                            Console.WriteLine("");
                        });
                    }
                    else
                    {
                        // error
                        Console.WriteLine($"status code:{statusCode}");

                        Console.WriteLine($"error_code: {output.error_code}");
                        Console.WriteLine($"error_message: {output.error_message}");
                        Console.WriteLine($"failed_condition: {output.failed_condition}");
                        Console.WriteLine($"failed_item: {output.failed_item}");
                        Console.WriteLine($"error_detail: {output.error_detail}");
                    }
                }
                else
                {
                    Console.WriteLine($"The Web Service {statusCode}");
                    return;
                }

            }
            catch (ApplicationException ex)
            {
                Console.WriteLine("ApplicationException");
                Console.WriteLine(ex);
            }
            catch (UnsupportedMediaTypeException ex)
            {
                Console.WriteLine("UnsupportedMediaType");
                Console.WriteLine(ex);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("HttpRequestException");
                Console.WriteLine(ex);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("AggregateException");
                Console.WriteLine(ex);
            }
        }

        public static void Public_NWM_SDraftPermanent(string baseUrl, AuthenticationHeaderValue ahv,
            string authTokenFilePath, InputParams inputParams)
        {
            try
            {
                string authToken = TokenTools.GetAuthToken(authTokenFilePath);

                if (authToken == null)
                    throw new Exception("Authentication Token file is not contains Token");

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Authorization = ahv;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("AuthToken", authToken);

                HttpResponseMessage response = client.PostAsJsonAsync("services/PublicNWMSDraftPermanent", inputParams).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                var statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {
                    OutputParams output = JsonConvert.DeserializeObject<OutputParams>(result);
                    string errorCode = output.error_code;
                    string errorMessage = output.error_message;
                    output = response.Content.ReadAsAsync<OutputParams>().Result;

                    if (response.IsSuccessStatusCode)
                    {

                        // print results
                        Console.WriteLine($"city: {output.city}");
                        Console.WriteLine($"province: {output.province}");
                        Console.WriteLine($"township: {output.township}");
                        Console.WriteLine($"contractor_name: {output.contractor_name}");
                        Console.WriteLine($"contractor_national_id: {output.contractor_national_id}");
                        Console.WriteLine($"create_date: {output.create_date}");
                        Console.WriteLine($"creator: {output.creator}");
                        Console.WriteLine($"warehouse_id: {output.warehouse_id}");
                        Console.WriteLine($"id: {output.id}");
                        Console.WriteLine($"owner_name: {output.owner_name}");
                        Console.WriteLine($"postal_code: {output.postal_code}");
                        Console.WriteLine($"receipt items:");
                        output.receipt_items.ForEach(delegate (ReceiptItemResponse rcp_item_resp)
                        {
                            Console.WriteLine($"\tid: {rcp_item_resp.id}");
                            Console.WriteLine($"\tgood_id: {rcp_item_resp.good_id}");
                            Console.WriteLine($"\tgood_desc: {rcp_item_resp.good_desc}");
                            Console.WriteLine("");
                        });
                    }
                    else
                    {
                        // error
                        Console.WriteLine($"status code:{statusCode}");

                        Console.WriteLine($"error_code: {output.error_code}");
                        Console.WriteLine($"error_message: {output.error_message}");
                        Console.WriteLine($"failed_condition: {output.failed_condition}");
                        Console.WriteLine($"failed_item: {output.failed_item}");
                        Console.WriteLine($"error_detail: {output.error_detail}");
                    }
                }
                else
                {
                    Console.WriteLine($"The Web Service {statusCode}");
                    return;
                }

            }
            catch (ApplicationException ex)
            {
                Console.WriteLine("ApplicationException");
                Console.WriteLine(ex);
            }
            catch (UnsupportedMediaTypeException ex)
            {
                Console.WriteLine("UnsupportedMediaType");
                Console.WriteLine(ex);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("HttpRequestException");
                Console.WriteLine(ex);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("AggregateException");
                Console.WriteLine(ex);
            }
        }

        public static void GetValue(string baseUrl,string authTokenFilePath,AuthenticationHeaderValue ahv)
        {
            try
            {
                string authToken = TokenTools.GetAuthToken(authTokenFilePath);
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = ahv;
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                client.DefaultRequestHeaders.Add("AuthToken", authToken);


                HttpResponseMessage response =
                    client.GetAsync("api/values/1").Result;
                string result = response.Content.ReadAsStringAsync().Result;
                var statusCode = response.StatusCode;
                if (statusCode == HttpStatusCode.OK)
                {

                    if (response.IsSuccessStatusCode)
                    {
                        // print results
                        Console.WriteLine($"city: {result}");
                    }
                    else
                    {
                        // error
                        Console.WriteLine($"status code:{statusCode}");
                    }
                }
                else
                {
                    Console.WriteLine($"The Web Service {statusCode}");
                    return;
                }

            }
            catch (ApplicationException ex)
            {
                Console.WriteLine("ApplicationException");
                Console.WriteLine(ex);
            }
            catch (UnsupportedMediaTypeException ex)
            {
                Console.WriteLine("UnsupportedMediaType");
                Console.WriteLine(ex);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("HttpRequestException");
                Console.WriteLine(ex);
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("AggregateException");
                Console.WriteLine(ex);
            }
        }
    }
}
