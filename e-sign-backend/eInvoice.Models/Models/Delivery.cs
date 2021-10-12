using System;
using System.Collections.Generic;

#nullable disable

namespace eInvoice.Models.Models
{
    public partial class Delivery
    {
        public Delivery()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string Approach { get; set; }
        public string Packaging { get; set; }
        public string DateValidity { get; set; }
        public string ExportPort { get; set; }
        public string CountryOfOrigin { get; set; }
        public decimal? GrossWeight { get; set; }
        public decimal? NetWeight { get; set; }
        public string Terms { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
