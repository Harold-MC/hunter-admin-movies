using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Hunter.Web.Api
{
    public class ApiRequest
    {
        protected HttpClient Client { get; set; }
        public ApiRequest()
        {
            Client = new HttpClient();
            string api = System.Configuration.ConfigurationManager.AppSettings["HunterApi"];
            Client.BaseAddress = new Uri(api);
        }

        public async Task<T> Get<T>(string endpoint)
        {
            var response = await Client.GetAsync($"{endpoint}");

            if (response.IsSuccessStatusCode)
            {
                string resultString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(resultString);
                return result;
            }
            else
            {
                return default(T);
            }
        }

        public async Task<bool> Post<T>(string endpoint, List<T> model)
        { 

            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync($"{endpoint}", data);

            return response.IsSuccessStatusCode ? true : false;
        }

        public async Task<bool> Delete(string endpoint, int id)
        {
            var response = await Client.DeleteAsync($"{endpoint}/{id}");
            return response.IsSuccessStatusCode ? true : false;
        }

        public async Task<bool> Put(string endpoint, int id, Dictionary<string, string> fields)
        {
            var json = JsonConvert.SerializeObject(fields);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PutAsync($"{endpoint}/{id}", data);
            return response.IsSuccessStatusCode ? true : false;
        }
    }
}