using eInvoice.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Models.DTOModel.Invoices
{
    public class Signature
    {
        public string signatureType { get; set; }
        public string value { get; set; }
    }
}
