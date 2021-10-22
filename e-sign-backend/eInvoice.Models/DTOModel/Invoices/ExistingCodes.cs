using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Models.DTOModel.Invoices
{
    public class ExistingCodes
    {
        public List<ExistingCodeItems> items { get; set; }
    }

    public class ExistingCodeItems
    {
        public string codetype { get; set; }
        public string itemCode { get; set; }
        public string comment { get; set; }
    }
}
