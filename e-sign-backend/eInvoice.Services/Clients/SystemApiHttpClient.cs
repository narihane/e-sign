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
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Clients
{
    public class SystemApiHttpClient
    {
        private HttpClient client;
        private readonly Apis apisSettings;
        private readonly IHttpContextAccessor context;

        public SystemApiHttpClient(HttpClient client, IOptions<Apis> apisSettings, IHttpContextAccessor context)
        {
            client.BaseAddress = new Uri(apisSettings.Value.SystemApi);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", context.HttpContext.Request.Headers[HeaderNames.Authorization].FirstOrDefault().ToString());
            client.DefaultRequestHeaders.Add("accept", "application/json");
            this.client = client;
            this.apisSettings = apisSettings.Value;
            this.context = context;
        }


        public async Task<SubmitDocumentsResponse> SubmitDocuments(DocumentsContainer documents)
        {
            var jsonContent = JsonConvert.SerializeObject(documents);
            var response = await client.PostAsync("test", new StringContent(jsonContent, Encoding.UTF8, "application/json"));

            //var response = await client.PostAsync("/api/v1/documentsubmissions", new StringContent(jsonContent, Encoding.UTF8, "application/json"));
            if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new UnauthorizedAccessException(response.ReasonPhrase);
            }
            var content = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
            var submittedDoc = JsonConvert.DeserializeObject<SubmitDocumentsResponse>(content);
            return submittedDoc;
        }

        public async Task<GetRecentDocumentsResponse> GetDocuments(int pageSize, int pageNumber)
        {
            client.DefaultRequestHeaders.Add("PageSize", $"{pageSize}");
            client.DefaultRequestHeaders.Add("PageNo", $"{pageNumber}");
            var response = await client.GetAsync($"api/v1/documents/recent");
            if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new UnauthorizedAccessException(response.ReasonPhrase);
            }
            var content = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
            var documents = JsonConvert.DeserializeObject<GetRecentDocumentsResponse>(content);
            return documents;
        }

        public async Task CreateEGSCodeUsage(NewCodes codes)
        {
            var jsonContent = JsonConvert.SerializeObject(codes);
            var response = await client.PostAsync("api/v1/codetypes/requests/codes", new StringContent(jsonContent, Encoding.UTF8, "application/json"));
            if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new UnauthorizedAccessException(response.ReasonPhrase);
            }
            var content = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }

        public async Task RequestCodeReuse(ExistingCodes codes)
        {
            var jsonContent = JsonConvert.SerializeObject(codes);
            var response = await client.PutAsync("api/v1/codetypes/requests/codeusages", new StringContent(jsonContent, Encoding.UTF8, "application/json"));
            if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new UnauthorizedAccessException(response.ReasonPhrase);
            }
            var content = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
        }

        public async Task<SearchCodesResponse> SearchCodes(string codeName, int pageSize, int pageNumber)
        {
            var queryString = $"?CodeName={codeName}&PageSize={pageSize}&PageNumber={pageNumber}";
            var response = await client.GetAsync($"api/v1/codetypes/requests/my{queryString}");
            if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new UnauthorizedAccessException(response.ReasonPhrase);
            }
            var content = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
            var codes = JsonConvert.DeserializeObject<SearchCodesResponse>(content);
            return codes;
        }

        public async Task<GetNotificationsResponse> GetNotifications(DateTime? dateFrom, DateTime? dateTo, string? type, string? status, string? channel, int pageSize, int pageNumber)
        {
            var queryString = $"?pageSize={pageSize}&pageNo={pageNumber}&dateFrom={dateFrom}&dateTo={dateTo}&type={type}&status={status}&channel={channel}";
            var response = await client.GetAsync($"api/v1/notifications/taxpayer{queryString}");
            if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new UnauthorizedAccessException(response.ReasonPhrase);
            }
            var content = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(content);
            }
            var notifications = JsonConvert.DeserializeObject<GetNotificationsResponse>(content);
            return notifications;
        }
    }
}
