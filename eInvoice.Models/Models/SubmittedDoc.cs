using System;
using System.Collections.Generic;

#nullable disable

namespace eInvoice.Models.Models
{
    public partial class SubmittedDoc
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string LongId { get; set; }
        public string InvoiceInternalId { get; set; }

        public virtual Invoice InvoiceInternal { get; set; }
    }
}
