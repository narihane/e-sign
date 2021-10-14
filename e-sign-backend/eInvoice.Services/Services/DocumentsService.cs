using eInvoice.Models.DTOModel.Responses;
using eInvoice.Models.Models;
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

        public DocumentsService(IGenericRepository<Invoice> genericRepo, IInvoiceRepository invoiceRepo)
        {
            this.genericRepo = genericRepo;
            this.invoiceRepo = invoiceRepo;
        }

        public void SaveInvoice(Invoice invoice)
        {
            if (invoice == null || string.IsNullOrEmpty(invoice.InteranlId))
            {
                throw new Exception("Invoice Empty!");
            }
            genericRepo.Insert(invoice);
        }

        public SubmitDocumentsResponse SubmitDocs(List<string> internalIds)
        {
            var invoices = new List<Invoice>();
            foreach (var id in internalIds)
            {
                var invoice = invoiceRepo.Getinvoice(id);
                if (invoice != null)
                    invoices.Add(invoice);
            }

        }
    }
}
