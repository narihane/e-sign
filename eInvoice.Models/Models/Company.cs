using System;
using System.Collections.Generic;

#nullable disable

namespace eInvoice.Models.Models
{
    public partial class Company
    {
        public Company()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string RegistrationNumber { get; set; }
        public string Name { get; set; }
        public string BranchId { get; set; }
        public string Country { get; set; }
        public string Governate { get; set; }
        public string RegionCity { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string PostalCode { get; set; }
        public string Floor { get; set; }
        public string FlatNumber { get; set; }
        public string Landmark { get; set; }
        public string AdditionalInformation { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
