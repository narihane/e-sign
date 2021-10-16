using System;
using System.Collections.Generic;

#nullable disable

namespace eInvoice.Models.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            Products = new HashSet<Product>();
            Signatures = new HashSet<Signature>();
            SubmittedDocs = new HashSet<SubmittedDoc>();
            TaxTypes = new HashSet<TaxType>();
        }

        public string InteranlId { get; set; }
        public int IssuerId { get; set; }
        public int ReceiverId { get; set; }
        public string DocumentType { get; set; }
        public string DocumentTypeversion { get; set; }
        public DateTime DateIssued { get; set; }
        public string PurchaseOrderReference { get; set; }
        public string PurchaseOrderDescription { get; set; }
        public string SalesOrderReference { get; set; }
        public string SalesOrderDescription { get; set; }
        public string ProformaInvoiceNumber { get; set; }
        public int? PaymentId { get; set; }
        public int? DeliveryId { get; set; }
        public decimal TotalSalesAmount { get; set; }
        public decimal TotalDiscountAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal ExtraDiscountAmount { get; set; }
        public decimal TotalItemsDiscountAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string TaxpayerActivityCode { get; set; }

        public virtual Delivery Delivery { get; set; }
        public virtual Issuer Issuer { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Receiver Receiver { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Signature> Signatures { get; set; }
        public virtual ICollection<SubmittedDoc> SubmittedDocs { get; set; }
        public virtual ICollection<TaxType> TaxTypes { get; set; }
    }
}
