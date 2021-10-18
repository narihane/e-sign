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
        private readonly IGenericRepository<Invoice> genericRepo;
        private readonly IInvoiceRepository invoiceRepo;
        private readonly IMapper mapper;
        private readonly SystemApiHttpClient client;

        public DocumentsService(IGenericRepository<Invoice> genericRepo, IInvoiceRepository invoiceRepo, IMapper mapper, SystemApiHttpClient client)
        {
            this.genericRepo = genericRepo;
            this.invoiceRepo = invoiceRepo;
            this.mapper = mapper;
            this.client = client;
        }

        public Invoice GetLocalInvoice(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new Exception("Invoice id missing!");
            }

            var invoice = invoiceRepo.Getinvoice(id);

            if (invoice == null)
            {
                throw new Exception($"No invoice with internal id {id}");
            }
            return invoice;
        }

        public void SaveInvoice(DocumentsContainer document)
        {
            if (document == null || document.documents.Count == 0)
            {
                throw new Exception("No Invoice Added!");
            }
            foreach (var doc in document.documents)
            {
                ////var invoice = mapper.Map<Invoice>(document.documents);
                var invoice = DocumentMapper.MapDocumentToInvoice(doc);

                // perform Validation
                genericRepo.Insert(invoice);
            }
        }

        public async Task<SubmitDocumentsResponse> SubmitDocs(List<string> internalIds)
        {
            var documents = new List<Document>();
            foreach (var id in internalIds)
            {
                var invoice = invoiceRepo.Getinvoice(id);
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
    }
}
