using System;
using System.Collections.Generic;

#nullable disable

namespace eInvoice.Models.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public string BankAccountNo { get; set; }
        public string BankAccountIban { get; set; }
        public string SwiftCode { get; set; }
        public string Terms { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
