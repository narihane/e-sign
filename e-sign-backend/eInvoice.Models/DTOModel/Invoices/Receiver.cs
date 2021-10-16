using eInvoice.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Models.DTOModel.Invoices
{
    public class Receiver
    {
        // Registration number. For business in Egypt must be registration number.
        // For residents must be national ID. For foreign buyers must be VAT ID of the foreign company.
        // Optional if person buyer and invoice amount less than threshold limit defined.
        // Receiver and issuer cannot be the same.
        public string id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public Address address { get; set; }
    }
}
