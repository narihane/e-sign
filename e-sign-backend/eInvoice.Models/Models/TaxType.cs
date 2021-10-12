using System;
using System.Collections.Generic;

#nullable disable

namespace eInvoice.Models.Models
{
    public partial class TaxType
    {
        public int Id { get; set; }
        public string TaxType1 { get; set; }
        public decimal Amount { get; set; }
        public string SubType { get; set; }
        public decimal Rate { get; set; }
        public string InvoiceInternalId { get; set; }

        public virtual Invoice InvoiceInternal { get; set; }
    }
}
