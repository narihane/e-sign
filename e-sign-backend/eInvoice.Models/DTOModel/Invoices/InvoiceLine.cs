using eInvoice.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Models.DTOModel.Invoices
{
    public class InvoiceLine
    {
        public string description { get; set; }
        public string itemType { get; set; }
        public string itemCode { get; set; }
        public string unitType { get; set; }
        public decimal quantity { get; set; }
        public Value unitValue { get; set; }
        public decimal salesTotal { get; set; }
        public decimal total { get; set; }
        public decimal valueDifference { get; set; }
        public decimal totalTaxableFees { get; set; }
        public decimal netTotal { get; set; }
        public decimal itemsDiscount { get; set; }
        public Discount? discount { get; set; }
        public List<TaxableItem>? taxableItems { get; set; }
        public string internalCode { get; set; }
    }

    public class Value
    {
        public string currencySold { get; set; }
        public decimal amountEGP { get; set; }
        public decimal? amountSold { get; set; }
        public decimal? currencyExchangeRate { get; set; }
    }

    public class Discount
    {
        public decimal? rate { get; set; }
        public decimal? amount { get; set; }
    }
}
