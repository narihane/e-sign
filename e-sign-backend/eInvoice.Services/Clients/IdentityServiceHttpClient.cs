using eInvoice.Models.AppSettings;
using eInvoice.Models.DTOModel;
using eInvoice.Models.DTOModel.Responses;
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
    public class IdentityServiceHttpClient
    {
        private HttpClient client;
        private readonly Apis apisSettings;

        public IdentityServiceHttpClient(HttpClient client, IOptions<Apis> apisSettings)
        {
            client.BaseAddress = new Uri(apisSettings.Value.IdentityService);
            client.DefaultRequestHeaders.Clear();
            this.client = client;
            this.apisSettings = apisSettings.Value;
        }

        public async Task<GetTokenResponse> GetToken()
        {
            var formParams = new Dictionary<string, string>();
            formParams.Add("grant_type", "client_credentials");
            formParams.Add("client_id", apisSettings.ClientId);
            formParams.Add("client_secret", apisSettings.ClientSecret);

            var response = await client.PostAsync("connect/token", new FormUrlEncodedContent(formParams));
            var content = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
                throw new Exception(content);
            var tokenResponse = JsonConvert.DeserializeObject<GetTokenResponse>(content);
            return tokenResponse;
        }
    }
}
