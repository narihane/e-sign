using eInvoice.Models.DTOModel.Invoices;
using eInvoice.Models.Models;
using eInvoice.Services.Helpers;
using eInvoice.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Services
{
    public class InvoicesService : IInvoicesService
    {
        private readonly IGenericRepository<Invoice> genericRepo;
        private readonly IInvoiceRepository invoiceRepo;

        public InvoicesService(IGenericRepository<Invoice> genericRepo, IInvoiceRepository invoiceRepo)
        {
            this.genericRepo = genericRepo;
            this.invoiceRepo = invoiceRepo;
        }

        public IEnumerable<Invoice> GetAllInvoices()
        {
            var invoices = genericRepo.GetAll();

            return invoices;
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

        public string SaveInvoice(DocumentsContainer document)
        {
            if (document == null || document.documents.Count == 0)
            {
                throw new Exception("No Invoice Added!");
            }
            var doc = document.documents.First();
            if (string.IsNullOrWhiteSpace(doc.internalId))
            {
                doc.internalId = Guid.NewGuid().ToString();
            }

            ////var invoice = mapper.Map<Invoice>(document.documents);
            var invoice = DocumentMapper.MapDocumentToInvoice(doc);

            // perform Validation

            genericRepo.Insert(invoice);
            return invoice.InteranlId;

        }
    }
}
