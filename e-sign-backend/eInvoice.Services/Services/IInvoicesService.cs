using eInvoice.Models.DTOModel.Invoices;
using eInvoice.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Services
{
    public interface IInvoicesService
    {
        IEnumerable<Invoice> GetAllInvoices();

        Invoice GetLocalInvoice(string Id);

        void SaveInvoice(DocumentsContainer invoice);
    }
}
