using System;
using System.Collections.Generic;

#nullable disable

namespace eInvoice.Models.Models
{
    public partial class Signature
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string InvoiceInternalId { get; set; }

        public virtual Invoice InvoiceInternal { get; set; }
    }
}
