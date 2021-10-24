using eInvoice.Models.DTOModel.Invoices;
using eInvoice.Models.DTOModel.Responses;
using eInvoice.Models.Models;
using eInvoice.Services.Clients;
using eInvoice.Services.Helpers;
using eInvoice.Services.Repositories;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Services
{
    public class CodesService : ICodesService
    {
        private readonly SystemApiHttpClient client;

        public CodesService(SystemApiHttpClient client)
        {
            this.client = client;
        }

        public async Task SubmitNewCodes(IFormFile file)
        {
            if (file == null)
            {
                throw new Exception("No File Uploaded!");
            }

            var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            var fileBytes = memoryStream.ToArray();
            var data = ExcelReader.ReadCodesFromFile(fileBytes);
            var jsonString = JsonConvert.SerializeObject(data);
            var codesList = JsonConvert.DeserializeObject<List<NewCodeItems>>(jsonString);
            NewCodes codes = new NewCodes
            {
                items = codesList
            };
            await client.CreateEGSCodeUsage(codes);
        }

        public async Task RequestCodeReuse(IFormFile file)
        {
            if (file == null)
            {
                throw new Exception("No File Uploaded!");
            }

            var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            var fileBytes = memoryStream.ToArray();
            var data = ExcelReader.ReadCodesFromFile(fileBytes);
            var jsonString = JsonConvert.SerializeObject(data);
            var codesList = JsonConvert.DeserializeObject<List<ExistingCodeItems>>(jsonString);
            ExistingCodes codes = new ExistingCodes
            {
                items = codesList
            };
            await client.RequestCodeReuse(codes);
        }

        public async Task<SearchCodesResponse> Search(string codeName, int pageSize, int pageNumber)
        {
            var codes = await client.SearchCodes(codeName, pageSize, pageNumber);
            return codes;
        }
    }
}
