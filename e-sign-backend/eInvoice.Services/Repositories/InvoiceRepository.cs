using eInvoice.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly eInvoiceContext dbcontext;
        
        public InvoiceRepository(eInvoiceContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public Invoice GetInvoice(string internalId)
        {
            return dbcontext.Set<Invoice>().SingleOrDefault(x=>x.InteranlId == internalId);
        }
    }
}
