using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using WebClient_Anbar_e_Sazemanha.Dto;
using WebClient_Anbar_e_Sazemanha.Utilities;

namespace WebClient_Anbar_e_Sazemanha.Services
{
    public static class AuthToken
    {
        public static string RefreshAuthToken(string baseUrl, AuthenticationHeaderValue ahv, string authTokenFilePath)
        {
            string curAuthToken = TokenTools.GetAuthToken(authTokenFilePath);

            var fs = new FileStream(authTokenFilePath, FileMode.Open);
            if (!fs.CanWrite)
            {
                throw new ApplicationException("The AuthToken file <" + authTokenFilePath + "> is not writable");
            }
            fs.Close();
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = ahv;
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("AuthToken", curAuthToken);
            try
            {
                HttpResponseMessage response = client.PostAsync("services/NWMSApiKeyRefreshService", null).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                TokenRefreshResponse res = new TokenRefreshResponse();
                res = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenRefreshResponse>(result);
                if (response.IsSuccessStatusCode)
                {
                    StreamWriter authFile = new StreamWriter(authTokenFilePath);
                    authFile.Write(res.token);
                    authFile.Close();
                    return res.token;
                }
                else
                {
                    throw new ApplicationException("An error occured when refreshing AuthToken");
                }
            }
            catch (UnsupportedMediaTypeException ex)
            {
                Console.WriteLine("UnsupportedMediaType");
                Console.WriteLine(ex);
                throw new ApplicationException("An error occured when refreshing AuthToken");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("HttpRequestException");
                Console.WriteLine(ex);
                throw new ApplicationException("An error occured when refreshing AuthToken");
            }
        }
    }

}
