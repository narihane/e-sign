using eInvoice.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Models.DTOModel.Invoices
{
    public class Document
    {
        public Issuer issuer { get; set; }
        public Receiver receiver { get; set; }
        public string documentType { get; set; }
        public string documentTypeVersion { get; set; }
        public DateTime dateTimeIssued { get; set; }
        public string taxpayerActivityCode { get; set; }
        public string internalId { get; set; }
        public string purchaseOrderReference { get; set; }
        public string purchaseOrderDescription { get; set; }
        public string salesOrderReference { get; set; }
        public string salesOrderDescription { get; set; }
        
        // Max 50 chars
        public string proformaInvoiceNumber { get; set; }
        public Payment payment { get; set; }
        public Delivery delivery { get; set; }
        public List<InvoiceLine> invoiceLines { get; set; }
        public decimal totalSalesAmount { get; set; }
        public decimal totalDiscountAmount { get; set; }
        public decimal netAmount { get; set; }

        // props to be filled from TaxableItems
        public List<TaxTotal> taxTotals { get; set; }
        public decimal extraDiscountAmount { get; set; }
        public decimal totalItemsDiscountAmount { get; set; }
        public decimal totalAmount { get; set; }
        public List<Signature> signatures { get; set; }
    }
}
