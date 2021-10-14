using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Models.AppSettings
{
    public class Apis
    {
        public string IdentityService { get; set; }
        public string SystemApi { get; set; }
        public string InvoicingApi { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
