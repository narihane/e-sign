using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Models.DTOModel.Invoices
{
    public class TaxTotal
    {
        public string taxType { get; set; }
        public decimal amount { get; set; }
    }
}
