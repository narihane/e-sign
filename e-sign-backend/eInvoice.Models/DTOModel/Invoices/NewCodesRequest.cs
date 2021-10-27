using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Models.DTOModel.Invoices
{
    public class NewCodesRequest
    {
        public List<NewCodeItems> items { get; set; }
    }

    public class NewCodeItems
    {
        public string codeType { get; set; }
        public string parentCode { get; set; }
        public string itemCode { get; set; }
        public string codeName { get; set; }
        public string codeNameAr { get; set; }
        public DateTime activeFrom { get; set; }
        public DateTime? activeTo { get; set; }
        public string description { get; set; }
        public string descriptionAr { get; set; }
        public string requestReason { get; set; }
        public string linkedCode { get; set; }
    }
}
