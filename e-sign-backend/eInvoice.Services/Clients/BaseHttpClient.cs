using eInvoice.Models.AppSettings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Clients
{
    public class BaseHttpClient
    {
        private HttpClient client;
        private readonly Apis apisSettings;

        public BaseHttpClient(HttpClient client, IOptions<Apis> apisSettings)
        {
            client.BaseAddress = new Uri(apisSettings.Value.BaseAddress);
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apisSettings.Value.ClientId}:{apisSettings.Value.ClientSecret}"))}");
            this.client = client;
            this.apisSettings = apisSettings.Value;
        }

        public async Task GetToken()
        {
            //var jsonContent = JsonConvert.SerializeObject(activity);
            var response = await client.PostAsync("connect/token", new StringContent(string.Empty, Encoding.UTF8, "application/json"));
            var content = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
                throw new Exception(content);
            var DirectLineConversation = JsonConvert.DeserializeObject(content);
        }
    }
}
