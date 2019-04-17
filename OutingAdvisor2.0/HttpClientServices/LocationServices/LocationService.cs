using System;
using System.Collections.Generic;
using System.Net.Http;
using OutingAdvisorV2DataObjects;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace OutingAdvisorV2.HttpClientServices.LocationServices
{
    public class LocationService
    {
        private HttpClient Client { get; }
        private IConfiguration Configuration { get; }

        public LocationService(HttpClient client, IConfiguration configuration)
        {
            Configuration = configuration;
            client.BaseAddress = new Uri(Configuration.GetValue<string>("ServicesBaseURI:LocationService"));

            Client = client;
        }

        public async Task<bool> Delete(Location location)
        {
            Task<bool> result = null;
            HttpResponseMessage response = await Client.DeleteAsync("?Identity=1&RowVersion=1");
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<bool>();
            }
            else
            {
                Console.WriteLine("Internal server Error");
            }
            return await result;
        }

        public async Task<bool> Insert(Location location)
        {
            Task<bool> result = null;
            HttpResponseMessage response = await Client.PutAsJsonAsync("", location);
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<bool>();
            }
            else
            {
                Console.WriteLine("Internal server Error");
            }
            return await result;
        }

        public async Task<bool> Update(Location location)
        {
            Task<bool> result = null;
            HttpResponseMessage response = await Client.PostAsJsonAsync("", location);
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<bool>();
            }
            else
            {
                Console.WriteLine("Internal server Error");
            }
            return await result;
        }

        public async Task<Location> Get(string name)
        {
            Task<Location> result = null;
            HttpResponseMessage response = await Client.GetAsync("/" + name);
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<Location>();
            }
            else
            {
                Console.WriteLine("Internal server Error");
            }
            return await result;
        }

        public async Task<List<Location>> GetAll()
        {
            Task<List<Location>> result = null;
            HttpResponseMessage response = await Client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsAsync<List<Location>>();
            }
            else
            {
                Console.WriteLine("Internal server Error");
            }
            return await result;
        }
    }
}
