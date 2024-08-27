using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ListKaryawanAPI.Tools
{
    public class RequestToApi
    {
        public static (bool, string) GetJsonStringWebApi(string apiUrl, string token = null, int TimeOutSecond = 60)
        {
            bool resultApi = false;
            string JsonString = string.Empty;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(token))
                        httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                    httpClient.Timeout = TimeSpan.FromSeconds(TimeOutSecond);
                    var result = httpClient.GetAsync(apiUrl).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        resultApi = true;
                        JsonString = result.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch
            {
                throw;
            }
            return (resultApi, JsonString);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiUrl">this describe url from api</param>
        /// <param name="TimeOutSecond">this describe timeout when load api</param>
        /// <returns></returns>
        public static async Task<string> GetJsonStringWebApiAsync(string apiUrl, int TimeOutSecond = 6000)
        {
            string JsonString = string.Empty;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.Timeout = TimeSpan.FromSeconds(TimeOutSecond);
                    var result = await httpClient.GetAsync(apiUrl);
                    if (result.IsSuccessStatusCode)
                    {
                        JsonString = await result.Content.ReadAsStringAsync();
                    }
                }
            }
            catch
            {
                throw;
            }
            return JsonString;
        }

        public static (bool, string) GetRequestToApiExadiaAsync(string apiUrl, object request, string token = null, int TimeOutSecond = 60)
        {
            bool resultApi = false;
            string JsonString = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                var someData = JsonConvert.SerializeObject(request);
                var content = new StringContent(someData, System.Text.Encoding.UTF8, "application/json");
                if (!string.IsNullOrEmpty(token))
                    httpClient.DefaultRequestHeaders.Add("vaia-key", token);

                httpClient.Timeout = TimeSpan.FromSeconds(TimeOutSecond);
                httpClient.DefaultRequestHeaders.Accept.Clear();

                //var result = httpClient.PostAsync(apiUrl, content);
                //if (result.IsSuccessStatusCode)
                //{
                //    JsonString = result.Content.ReadAsStringAsync();
                //}

                var result = httpClient.GetAsync(apiUrl).Result;
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

        public static (bool, string) GetRequestToApiPlainAsync(string apiUrl, int TimeOutSecond = 6000)
        {
                bool resultApi = false;
                string JsonString = string.Empty;
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromSeconds(TimeOutSecond);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var result = httpClient.GetAsync(apiUrl).Result;

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

        public static (bool, string) GetRequestToApiTestAsync(string apiUrl, object request, string token = null, int TimeOutSecond = 60)
        {
            bool resultApi = false;
            string JsonString = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                var someData = JsonConvert.SerializeObject(request);
                var content = new StringContent(someData, System.Text.Encoding.UTF8, "multipart/form-data");
                if (!string.IsNullOrEmpty(token))
                    httpClient.DefaultRequestHeaders.Add("Apikey", token);

                httpClient.Timeout = TimeSpan.FromSeconds(TimeOutSecond);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //var result = httpClient.PostAsync(apiUrl, content);
                //if (result.IsSuccessStatusCode)
                //{
                //    JsonString = result.Content.ReadAsStringAsync();
                //}

                var result = httpClient.GetAsync(apiUrl).Result;
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

        /// <summary>
        /// hit api with HTTP verbs POST
        /// </summary>
        /// <param name="apiUrl">this describe url from api</param>
        /// <param name="request">this describe object model will be use in function api</param>
        /// <param name="TimeOutSecond">this describe timeout when load api</param>
        /// <returns></returns>
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

                //var result = httpClient.PostAsync(apiUrl, content);
                //if (result.IsSuccessStatusCode)
                //{
                //    JsonString = result.Content.ReadAsStringAsync();
                //}

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

        public static (bool, string) PostRequestToWebApiTest(string apiUrl, object request, string token = null, int TimeOutSecond = 60)
        {
            bool resultApi = false;
            string JsonString = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                var someData = JsonConvert.SerializeObject(request);
                var content = new StringContent(someData, System.Text.Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (!string.IsNullOrEmpty(token))
                    httpClient.DefaultRequestHeaders.Add("Apikey", token);



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

        public static async Task<(bool, string)> PostRequestToWebApiTest2(string apiUrl, object request, string token = null, int TimeOutSecond = 60)
        {
            bool resultApi = false;
            string JsonString = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                var someData = JsonConvert.SerializeObject(request);
                var buffer = System.Text.Encoding.UTF8.GetBytes(someData);
                var bytecontent = new ByteArrayContent(buffer);
                bytecontent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-date");
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Apikey", token);


                //var content = new StringContent(someData, System.Text.Encoding.UTF8, "application/json");
                //content.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
                //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //if (!string.IsNullOrEmpty(token))
                //    httpClient.DefaultRequestHeaders.Add("Apikey", token);



                //httpClient.Timeout = TimeSpan.FromSeconds(TimeOutSecond);
                //httpClient.DefaultRequestHeaders.Accept.Clear();

                //var result = httpClient.PostAsync(apiUrl, content).Result;
                var result = httpClient.PostAsync(apiUrl, bytecontent).Result;
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


        /// <summary>
        /// asynchronous hit api with HTTP verbs POST
        /// </summary>
        /// <param name="apiUrl">this describe url from api</param>
        /// <param name="request">this describe object model will be use in function api</param>
        /// <param name="TimeOutSecond">this describe timeout when load api</param>
        /// <returns></returns>
        public static async Task<string> PostRequestToWebApiAsync(string apiUrl, object request, int TimeOutSecond = 60)
        {
            string JsonString = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                var someData = JsonConvert.SerializeObject(request);
                var content = new StringContent(someData, System.Text.Encoding.UTF8, "application/json");
                httpClient.Timeout = TimeSpan.FromSeconds(TimeOutSecond);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                var result = await httpClient.PostAsync(apiUrl, content);
                if (result.IsSuccessStatusCode)
                {
                    JsonString = await result.Content.ReadAsStringAsync();
                }
            }
            return JsonString;
        }

        /// <summary>
        /// hit api with HTTP verbs POST
        /// </summary>
        /// <param name="apiUrl">this describe url from api</param>
        /// <param name="request">this describe object model will be use in function api</param>
        /// <param name="TimeOutSecond">this describe timeout when load api</param>
        /// <returns></returns>
        public static (bool, string) PostFormDataToWebApi(string apiUrl, object request, string token = null, int TimeOutSecond = 60)
        {
            bool resultApi = false;
            string JsonString = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                var formData = new MultipartFormDataContent();

                foreach (var prop in request.GetType().GetProperties())
                {
                    string name = prop.Name;

                    if (prop.PropertyType == typeof(IFormFile))
                    {
                        IFormFile file = ((IFormFile)prop.GetValue(request, null));
                        if (file != null)
                            formData.Add(new StreamContent(file.OpenReadStream()), prop.Name, file.FileName);
                    }
                    else if (prop.PropertyType == typeof(IFormFile[]))
                    {
                        IFormFile[] files = ((IFormFile[])prop.GetValue(request, null));
                        if (files != null)
                        {
                            foreach (var file in files)
                            {
                                if (file != null)
                                {
                                    formData.Add(new StreamContent(file.OpenReadStream()), prop.Name, file.FileName);
                                }
                            }
                        }
                    }
                    else
                    {
                        var value = (prop.GetValue(request, null) ?? string.Empty).ToString();
                        formData.Add(new StringContent(value), prop.Name);
                    }
                }

                if (!string.IsNullOrEmpty(token))
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                httpClient.Timeout = TimeSpan.FromSeconds(TimeOutSecond);

                httpClient.DefaultRequestHeaders.Accept.Clear();
                var result = httpClient.PostAsync(apiUrl, formData).Result;
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

        public static (bool, string) PostFormDataToWebApiTest(string apiUrl, object request, string token = null, int TimeOutSecond = 60)
        {
            bool resultApi = false;
            string JsonString = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                var formData = new MultipartFormDataContent();

                foreach (var prop in request.GetType().GetProperties())
                {
                    string name = prop.Name;

                    if (prop.PropertyType == typeof(IFormFile))
                    {
                        IFormFile file = ((IFormFile)prop.GetValue(request, null));
                        if (file != null)
                            formData.Add(new StreamContent(file.OpenReadStream()), prop.Name, file.FileName);
                    }
                    else if (prop.PropertyType == typeof(IFormFile[]))
                    {
                        IFormFile[] files = ((IFormFile[])prop.GetValue(request, null));
                        if (files != null)
                        {
                            foreach (var file in files)
                            {
                                if (file != null)
                                {
                                    formData.Add(new StreamContent(file.OpenReadStream()), prop.Name, file.FileName);
                                }
                            }
                        }
                    }
                    else
                    {
                        var value = (prop.GetValue(request, null) ?? string.Empty).ToString();
                        formData.Add(new StringContent(value), prop.Name);
                    }
                }

                if (!string.IsNullOrEmpty(token))
                    httpClient.DefaultRequestHeaders.Add("Apikey", token);

                httpClient.Timeout = TimeSpan.FromSeconds(TimeOutSecond);

                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Apikey", token);
                var result = httpClient.PostAsync(apiUrl, formData).Result;
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



        /// <summary>
        /// hit api with HTTP verbs POST
        /// </summary>
        /// <param name="apiUrl">this describe url from api</param>
        /// <param name="request">this describe object model will be use in function api</param>
        /// <param name="TimeOutSecond">this describe timeout when load api</param>
        /// <returns></returns>
        public static (bool, string) PostFormDataJsonToWebApi(string apiUrl, object request, object requestJson, string token = null, int TimeOutSecond = 60)
        {
            bool resultApi = false;
            string JsonString = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                var formData = new MultipartFormDataContent();
                var json = JsonConvert.SerializeObject(requestJson);

                formData.Add(new StringContent(json, Encoding.Unicode, "application/json"));
                foreach (var prop in request.GetType().GetProperties())
                {
                    string name = prop.Name;

                    if (prop.PropertyType == typeof(IFormFile))
                    {
                        IFormFile file = ((IFormFile)prop.GetValue(request, null));
                        if (file != null)
                            formData.Add(new StreamContent(file.OpenReadStream()), prop.Name, file.FileName);
                    }
                    else if (prop.PropertyType == typeof(IFormFile[]))
                    {
                        IFormFile[] files = ((IFormFile[])prop.GetValue(request, null));
                        if (files != null)
                        {
                            foreach (var file in files)
                            {
                                if (file != null)
                                {
                                    formData.Add(new StreamContent(file.OpenReadStream()), prop.Name, file.FileName);
                                }
                            }
                        }
                    }
                    else
                    {
                        var value = (prop.GetValue(request, null) ?? string.Empty).ToString();
                        formData.Add(new StringContent(value), prop.Name);
                    }
                }

                if (!string.IsNullOrEmpty(token))
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                httpClient.Timeout = TimeSpan.FromSeconds(TimeOutSecond);

                httpClient.DefaultRequestHeaders.Accept.Clear();
                var result = httpClient.PostAsync(apiUrl, formData).Result;
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

        public static (bool, string) PostFormDataJsonToWebApiTest(string apiUrl, object request, object requestJson, string token = null, int TimeOutSecond = 60)
        {
            bool resultApi = false;
            string JsonString = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                var formData = new MultipartFormDataContent();
                var json = JsonConvert.SerializeObject(requestJson);

                formData.Add(new StringContent(json, Encoding.Unicode, "multipart/form-data"));
                foreach (var prop in request.GetType().GetProperties())
                {
                    string name = prop.Name;

                    if (prop.PropertyType == typeof(IFormFile))
                    {
                        IFormFile file = ((IFormFile)prop.GetValue(request, null));
                        if (file != null)
                            formData.Add(new StreamContent(file.OpenReadStream()), prop.Name, file.FileName);
                    }
                    else if (prop.PropertyType == typeof(IFormFile[]))
                    {
                        IFormFile[] files = ((IFormFile[])prop.GetValue(request, null));
                        if (files != null)
                        {
                            foreach (var file in files)
                            {
                                if (file != null)
                                {
                                    formData.Add(new StreamContent(file.OpenReadStream()), prop.Name, file.FileName);
                                }
                            }
                        }
                    }
                    else
                    {
                        var value = (prop.GetValue(request, null) ?? string.Empty).ToString();
                        formData.Add(new StringContent(value), prop.Name);
                    }
                }

                //if (!string.IsNullOrEmpty(token))
                //    httpClient.DefaultRequestHeaders.Add("Apikey", token);

                httpClient.Timeout = TimeSpan.FromSeconds(TimeOutSecond);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("Apikey", token);

                var result = httpClient.PostAsync(apiUrl, formData).Result;
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



        /// <summary>
        /// hit api with HTTP verbs POST
        /// </summary>
        /// <param name="apiUrl">this describe url from api</param>
        /// <param name="request">this describe object model will be use in function api</param>
        /// <param name="TimeOutSecond">this describe timeout when load api</param>
        /// <returns></returns>
        public static (bool, string) PutRequestToWebApi(string apiUrl, object request, int TimeOutSecond = 60)
        {
            bool resultApi = false;
            string JsonString = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                var someData = JsonConvert.SerializeObject(request);
                var content = new StringContent(someData, System.Text.Encoding.UTF8, "application/json");
                httpClient.Timeout = TimeSpan.FromSeconds(TimeOutSecond);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                var result = httpClient.PutAsync(apiUrl, content).Result;
                if (result.IsSuccessStatusCode)
                {
                    resultApi = true;
                    JsonString = result.Content.ReadAsStringAsync().Result;
                }
            }
            return (resultApi, JsonString);
        }

        /// <summary>
        /// asynchronous hit api with HTTP verbs POST
        /// </summary>
        /// <param name="apiUrl">this describe url from api</param>
        /// <param name="request">this describe object model will be use in function api</param>
        /// <param name="TimeOutSecond">this describe timeout when load api</param>
        /// <returns></returns>
        public static async Task<string> PutRequestToWebApiAsync(string apiUrl, object request, int TimeOutSecond = 60)
        {
            string JsonString = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                var someData = JsonConvert.SerializeObject(request);
                var content = new StringContent(someData, System.Text.Encoding.UTF8, "application/json");
                httpClient.Timeout = TimeSpan.FromSeconds(TimeOutSecond);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                var result = await httpClient.PutAsync(apiUrl, content);
                if (result.IsSuccessStatusCode)
                {
                    JsonString = await result.Content.ReadAsStringAsync();
                }
            }
            return JsonString;
        }

        /// <summary>
        /// asynchronous hit api with HTTP verbs POST
        /// </summary>
        /// <param name="apiUrl">this describe url from api</param>
        /// <param name="request">this describe object model will be use in function api</param>
        /// <param name="TimeOutSecond">this describe timeout when load api</param>
        /// <returns></returns>
        public static async Task<string> DeleteRequestToWebApiAsync(string apiUrl, int TimeOutSecond = 60)
        {
            string JsonString = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromSeconds(TimeOutSecond);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                var result = await httpClient.DeleteAsync(apiUrl);
                if (result.IsSuccessStatusCode)
                {
                    JsonString = await result.Content.ReadAsStringAsync();
                }
            }
            return JsonString;
        }

        /// <summary>
        /// asynchronous hit api with HTTP verbs POST
        /// </summary>
        /// <param name="apiUrl">this describe url from api</param>
        /// <param name="TimeOutSecond">this describe timeout when load api</param>
        /// <returns></returns>
        public static string DeleteRequestToWebApi(string apiUrl, string token = null, int TimeOutSecond = 60)
        {
            string JsonString = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                if (!string.IsNullOrEmpty(token))
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                httpClient.Timeout = TimeSpan.FromSeconds(TimeOutSecond);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                var result = httpClient.DeleteAsync(apiUrl).Result;
                if (result.IsSuccessStatusCode)
                {
                    JsonString = result.Content.ReadAsStringAsync().Result;
                }
            }
            return JsonString;
        }
    }
}
