using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Models.DTOModel.Invoices
{
    public class NewCodesDTO
    {
        public List<NewCodeItemsDTO> items { get; set; }
    }

    public class NewCodeItemsDTO
    {
        public string CodeType { get; set; }
        public string GPCItemLinked { get; set; }
        public string ItemCode { get; set; }
        public string CodeName { get; set; }
        public string CodeName2Ar { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime? ActiveTo { get; set; }
        public string Description { get; set; }
        public string DescriptionAr { get; set; }
        public string RequestReason { get; set; }
        public string EGSRelatedCode { get; set; }
    }
}
