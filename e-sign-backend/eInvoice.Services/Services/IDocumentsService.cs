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
       Task<SubmitDocumentsResponse> SubmitDocs(List<string> internalIds);
       Task<GetRecentDocumentsResponse> GetDocuments(int pageSize, int pageNumber);
    }
}
