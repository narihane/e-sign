using eInvoice.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Models.DTOModel.Invoices
{
    public class Issuer
    {
        public string type { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public Address address { get; set; }
    }

    public class Address
    {
        public string branchId { get; set; }
        public string country { get; set; }
        public string governate { get; set; }
        public string regionCity { get; set; }
        public string street { get; set; }
        public string buildingNumber { get; set; }
        public string postalCode { get; set; }
        public string floor { get; set; }
        public string room { get; set; }
        public string landmark { get; set; }
        public string additionalInformation { get; set; }
    }
}
