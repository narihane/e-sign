using AutoMapper;
using eInvoice.Models.DTOModel.Invoices;
using eInvoice.Models.DTOModel.Responses;
using eInvoice.Models.Models;
using eInvoice.Services.Clients;
using eInvoice.Services.Helpers;
using eInvoice.Services.Helpers.ECertificate;
using eInvoice.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Services
{
    public class DocumentsService : IDocumentsService
    {
        private readonly IInvoiceRepository invoiceRepo;
        private readonly IMapper mapper;
        private readonly SystemApiHttpClient client;

        public DocumentsService(IInvoiceRepository invoiceRepo, IMapper mapper, SystemApiHttpClient client)
        {
            this.invoiceRepo = invoiceRepo;
            this.mapper = mapper;
            this.client = client;
        }

        public async Task<SubmitDocumentsResponse> SubmitDocs(List<string> internalIds)
        {
            var documents = new List<Document>();
            foreach (var id in internalIds)
            {
                var invoice = invoiceRepo.GetInvoice(id);
                if (invoice != null)
                {
                    ////var document = mapper.Map<Document>(invoice);
                    var document = DocumentMapper.MapInvoiceToDocument(invoice);
                    document = SignatureCreater.CreateSignature(document);
                    documents.Add(document);
                }
            }
            DocumentsContainer docs = new DocumentsContainer
            {
                documents = documents
            };
            var submittedDocs = await client.SubmitDocuments(docs);
            return submittedDocs;
        }

        public async Task<GetRecentDocumentsResponse> GetDocuments(int pageSize, int pageNumber)
        {
            var docs = await client.GetDocuments(pageSize, pageNumber);
            return docs;
        }
    }
}
