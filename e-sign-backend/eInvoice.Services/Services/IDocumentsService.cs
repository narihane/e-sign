using eInvoice.Models.DTOModel.Invoices;
using eInvoice.Models.DTOModel.Responses;
using eInvoice.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Services
{
    public interface IDocumentsService
    {
        void SaveInvoice(DocumentsContainer invoice);

        Task<SubmitDocumentsResponse> SubmitDocs(List<string> internalIds);
    }
}
