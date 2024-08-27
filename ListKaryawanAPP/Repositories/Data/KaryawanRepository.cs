using Newtonsoft.Json;
using ListKaryawanAPP.Base.Urls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ListKaryawanAPI.ViewModels;
using ListKaryawanAPI.Models.Karyawan;
using System.Security.Cryptography;

namespace ListKaryawanAPP.Repositories.Data
{
    public class KaryawanRepository : GeneralRepository<TblTKaryawan, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;
        public KaryawanRepository(Address address, string request = "Karyawan/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };

        }

        public async Task<List<LoadDataVM>> KaryawanList()
        {
            List<LoadDataVM> entities = new List<LoadDataVM>();

            using (var response = await httpClient.GetAsync(request + "GetData"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<LoadDataVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<List<LoadDataVM>> DataKaryawan()
        {
            List<LoadDataVM> entities = new List<LoadDataVM>();

            using (var response = await httpClient.GetAsync(request + "DataKaryawan"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<LoadDataVM>>(apiResponse);
            }
            return entities;
        }

        public async Task<LoadDataVM> UpdateId(DeleteVM req)
        {
            LoadDataVM entity = null;

            using (var response = await httpClient.GetAsync(request + "ViewUpdate/" + req.NRP))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<LoadDataVM>(apiResponse);
            }
            return entity;
        }

        public HttpStatusCode InsertData(DeleteVM req)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + request+ "insertData", content).Result;
            return result.StatusCode;
        }
        public HttpStatusCode DeleteData(DeleteVM req)
        {
            var result = httpClient.DeleteAsync(request +"deleteData/"+ req.NRP).Result;
            return result.StatusCode;
        }

        public HttpStatusCode UpdateData(LoadDataVM req)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync(request + "UpdateData", content).Result;
            return result.StatusCode;
        }



    }
}
