using eInvoice.Models.AppSettings;
using eInvoice.Models.DTOModel.Invoices;
using eInvoice.Models.DTOModel.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Clients
{
    public class SystemApiHttpClient
    {
        private HttpClient client;
        private readonly Apis apisSettings;
        private readonly HttpContext context;

        public SystemApiHttpClient(HttpClient client, IOptions<Apis> apisSettings, HttpContext context)
        {
            client.BaseAddress = new Uri(apisSettings.Value.SystemApi);
            client.DefaultRequestHeaders.Add("Authorization", context.Request.Headers[HeaderNames.Authorization].ToString());
            client.DefaultRequestHeaders.Add("accept", "application/json");
            this.client = client;
            this.apisSettings = apisSettings.Value;
            this.context = context;
        }


        public async Task<SubmitDocumentsResponse> SubmitDocuments(List<Document> documents)
        {
            var jsonContent = JsonConvert.SerializeObject(documents);
            var response = await client.PostAsync("/api/v1/documentsubmissions", new StringContent(jsonContent, Encoding.UTF8, "application/json"));
            var content = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
                throw new Exception(content);
            var submittedDoc = JsonConvert.DeserializeObject<SubmitDocumentsResponse>(content);
            return submittedDoc;
        }


    }
}
