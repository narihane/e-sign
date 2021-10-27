using AutoMapper;
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
        private readonly IMapper mapper;

        public CodesService(SystemApiHttpClient client, IMapper mapper)
        {
            this.client = client;
            this.mapper = mapper;
        }

        public async Task<string> SubmitNewCodes(IFormFile file)
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
            var codesList = JsonConvert.DeserializeObject<List<NewCodeItemsDTO>>(jsonString);
            var mappedCodes = mapper.Map<List<NewCodeItemsDTO>, List<NewCodeItems>>(codesList);
            NewCodesRequest codes = new NewCodesRequest
            {
                items = mappedCodes
            };
            var response = await client.CreateEGSCodeUsage(codes);
            return response;
        }

        public async Task<string> RequestCodeReuse(IFormFile file)
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
            var response = await client.RequestCodeReuse(codes);
            return response;
        }

        public async Task<SearchCodesResponse> Search(string codeName, int pageSize, int pageNumber)
        {
            var codes = await client.SearchCodes(codeName, pageSize, pageNumber);
            return codes;
        }

        public async Task<SearchCodesResponse> SearchPublishedCodes(int? codeLookupValue, string codeName, int pageSize = 10, int pageNumber = 1)
        {
            var codes = await client.SearchPublishedCodes(codeLookupValue, codeName, pageSize, pageNumber);
            return codes;
        }
    }
}
