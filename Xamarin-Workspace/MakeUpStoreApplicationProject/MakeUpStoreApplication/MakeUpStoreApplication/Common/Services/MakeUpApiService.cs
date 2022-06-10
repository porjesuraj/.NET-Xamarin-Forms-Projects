using MakeUpStoreApplication.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MakeUpStoreApplication.Common.Services
{
    public interface IMakeUpApiService
    {
        Task<List<MakeUp>> GetAsync(string url);
    }

    public class MakeUpApiService : IMakeUpApiService
    {
        public readonly HttpClient httpClient;

        public MakeUpApiService()
        {
            httpClient = new HttpClient();
        }


        public async Task<List<MakeUp>> GetAsync(string url)
        {
           
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                string serialized = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<List<MakeUp>>(serialized);
                return result;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
               
            }


            return null;
           
        }

       




    }

}
