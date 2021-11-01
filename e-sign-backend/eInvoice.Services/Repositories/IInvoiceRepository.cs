using eInvoice.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Repositories
{
    public interface IInvoiceRepository
    {
        Invoice GetInvoice(string internalId);
    }
}
