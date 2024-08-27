using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ListKaryawanAPI.Tools
{
    public class HttpClientIgnoreSSL
    {
        public static (bool, string) PostRequestToWebApi(string apiUrl, object request, string token = null, int TimeOutSecond = 60)
        {
            bool resultApi = false;
            string JsonString = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                var someData = JsonConvert.SerializeObject(request);
                var content = new StringContent(someData, System.Text.Encoding.UTF8, "application/json");
                if (!string.IsNullOrEmpty(token))
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                httpClient.Timeout = TimeSpan.FromSeconds(TimeOutSecond);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                var result = httpClient.PostAsync(apiUrl, content).Result;
                if (result.IsSuccessStatusCode)
                {
                    resultApi = true;
                    JsonString = result.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    JsonString = result.Content.ReadAsStringAsync().Result;
                }
            }
            return (resultApi, JsonString);
        }
    }
}
