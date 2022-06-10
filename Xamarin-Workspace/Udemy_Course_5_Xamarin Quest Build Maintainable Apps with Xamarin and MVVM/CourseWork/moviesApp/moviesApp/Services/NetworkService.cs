using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace moviesApp.Services
{


    public class NetworkService : INetworkService
    {
        private readonly HttpClient httpClient;

        public NetworkService()
        {
            httpClient = new HttpClient();


        }


        public async Task<TResult> GetAsync<TResult>(string url)
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);

            string serialized = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<TResult>(serialized);

            return result;
        }


        public async Task<TResult> PostAsync<TResult>(string uri, string jsonData)
        {
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await httpClient.PostAsync(uri, content);

            string serialized = await response.Content.ReadAsStringAsync();

            TResult result = JsonConvert.DeserializeObject<TResult>(serialized);

            return result;

        }

        public async Task<TResult> PutAsync<TResult>(string uri, string jsonData)
        {
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PutAsync(uri, content);

            string serialized = await response.Content.ReadAsStringAsync();

            TResult result = JsonConvert.DeserializeObject<TResult>(serialized);

            return result;
        }

        public async Task DeleteAsync(string uri)
        {
            await httpClient.DeleteAsync(uri);
        }









    }
}
