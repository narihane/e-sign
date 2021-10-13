using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Models.DTOModel.Invoices
{
    public class TaxableItem
    {
        public string taxType { get; set; }
        public decimal amount { get; set; }
        public string subType { get; set; }
        public decimal rate { get; set; }
    }
}
