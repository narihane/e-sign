using eInvoice.Models.DTOModel.Invoices;
using eInvoice.Models.Models;
using System.Collections.Generic;

namespace eInvoice.Services.Helpers
{
    public class DocumentMapper
    {
        // THIS IS UNACCEPTABLE CODE
        // ONLY TEMPORARY DUE TO TIME WINDOW
        // TODO: USE AUTOMAPEER INSTEAD
        public static Document MapInvoiceToDocument(Invoice invoice)
        {
            List<TaxTotal> taxTotals;
            List<TaxableItem> taxableItems;

            MapTaxes(invoice, out taxTotals, out taxableItems);
            var signatures = MapSignatures(invoice);
            var invoiceLines = MapInvoiceLines(taxableItems);

            Document document = new Document
            {
                internalId = invoice.InteranlId,
                dateTimeIssued = invoice.DateIssued,
                delivery = new Models.DTOModel.Invoices.Delivery
                {
                    approach = invoice.Delivery.Approach,
                    countryOfOrigin = invoice.Delivery.CountryOfOrigin,
                    dateValidity = invoice.Delivery.DateValidity,
                    exportPort = invoice.Delivery.ExportPort,
                    grossWeight = invoice.Delivery.GrossWeight,
                    netWeight = invoice.Delivery.NetWeight,
                    packaging = invoice.Delivery.Packaging,
                    terms = invoice.Delivery.Terms
                },
                payment = new Models.DTOModel.Invoices.Payment
                {
                    bankAccountIBAN = invoice.Payment.BankAccountIban,
                    bankAccountNo = invoice.Payment.BankAccountNo,
                    bankAddress = invoice.Payment.BankAddress,
                    bankName = invoice.Payment.BankName,
                    swiftCode = invoice.Payment.SwiftCode,
                    terms = invoice.Payment.Terms
                },
                documentType = invoice.DocumentType,
                documentTypeVersion = invoice.DocumentTypeversion,
                extraDiscountAmount = invoice.ExtraDiscountAmount,
                netAmount = invoice.NetAmount,
                proformaInvoiceNumber = invoice.ProformaInvoiceNumber,
                purchaseOrderDescription = invoice.PurchaseOrderDescription,
                purchaseOrderReference = invoice.PurchaseOrderReference,
                salesOrderDescription = invoice.SalesOrderDescription,
                salesOrderReference = invoice.SalesOrderReference,
                signatures = signatures,
                taxpayerActivityCode = invoice.TaxpayerActivityCode,
                totalAmount = invoice.TotalAmount,
                totalDiscountAmount = invoice.TotalDiscountAmount,
                totalItemsDiscountAmount = invoice.TotalItemsDiscountAmount,
                totalSalesAmount = invoice.TotalSalesAmount,
                issuer = new Models.DTOModel.Invoices.Issuer
                {
                    id = invoice.Issuer.RegistrationNumber,
                    type = invoice.Issuer.Type,
                    name = invoice.Issuer.Name,
                    address = new Address
                    {
                        additionalInformation = invoice.Issuer.AdditionalInformation,
                        branchId = invoice.Issuer.BranchId,
                        buildingNumber = invoice.Issuer.BuildingNumber,
                        country = invoice.Issuer.Country,
                        floor = invoice.Issuer.Floor,
                        governate = invoice.Issuer.Governate,
                        landmark = invoice.Issuer.Landmark,
                        postalCode = invoice.Issuer.PostalCode,
                        regionCity = invoice.Issuer.RegionCity,
                        room = invoice.Issuer.FlatNumber,
                        street = invoice.Issuer.Street
                    },
                },
                receiver = new Models.DTOModel.Invoices.Receiver
                {
                    id = invoice.Receiver.RegistrationNumber,
                    type = invoice.Receiver.Type,
                    name = invoice.Receiver.Name,
                    address = new Address
                    {
                        additionalInformation = invoice.Receiver.AdditionalInformation,
                        branchId = invoice.Receiver.BranchId,
                        buildingNumber = invoice.Receiver.BuildingNumber,
                        country = invoice.Receiver.Country,
                        floor = invoice.Receiver.Floor,
                        governate = invoice.Receiver.Governate,
                        landmark = invoice.Receiver.Landmark,
                        postalCode = invoice.Receiver.PostalCode,
                        regionCity = invoice.Receiver.RegionCity,
                        room = invoice.Receiver.FlatNumber,
                        street = invoice.Receiver.Street
                    },
                },
                taxTotals = taxTotals,
                invoiceLines = invoiceLines
            };

            return document;
        }

        public static Invoice MapDocumentToInvoice(Document document)
        {
            //List<TaxTotal> taxTotals;
            //List<TaxableItem> taxableItems;

            //MapTaxes(invoice, out taxTotals, out taxableItems);
            //var signatures = MapSignatures(invoice);
            //var invoiceLines = MapInvoiceLines(taxableItems);

            //Invoice invoice = new Invoice
            //{
                
            //}

            //return document;
        }

        private static List<InvoiceLine> MapInvoiceLines(List<TaxableItem> taxableItems)
        {
            var invoiceLines = new List<InvoiceLine>();

            foreach (var invoiceLine in invoiceLines)
            {
                var invoiceLineDTO = new InvoiceLine();
                invoiceLineDTO.description = invoiceLine.description;
                invoiceLineDTO.discount = new Discount
                {
                    amount = invoiceLine.discount.amount,
                    rate = invoiceLine.discount.rate
                };
                invoiceLineDTO.internalCode = invoiceLine.internalCode;
                invoiceLineDTO.itemCode = invoiceLine.itemCode;
                invoiceLineDTO.itemsDiscount = invoiceLine.itemsDiscount;
                invoiceLineDTO.itemType = invoiceLine.itemType;
                invoiceLineDTO.netTotal = invoiceLine.netTotal;
                invoiceLineDTO.quantity = invoiceLine.quantity;
                invoiceLineDTO.salesTotal = invoiceLine.salesTotal;
                invoiceLineDTO.taxableItems = taxableItems;
                invoiceLineDTO.total = invoiceLine.total;
                invoiceLineDTO.totalTaxableFees = invoiceLine.totalTaxableFees;
                invoiceLineDTO.unitType = invoiceLine.unitType;
                invoiceLineDTO.unitValue = new Value
                {
                    amountEGP = invoiceLine.unitValue.amountEGP,
                    amountSold = invoiceLine.unitValue.amountSold,
                    currencyExchangeRate = invoiceLine.unitValue.currencyExchangeRate,
                    currencySold = invoiceLine.unitValue.currencySold
                };
                invoiceLineDTO.valueDifference = invoiceLine.valueDifference;
                invoiceLines.Add(invoiceLineDTO);
            }

            return invoiceLines;
        }

        private static void MapTaxes(Invoice invoice, out List<TaxTotal> taxTotals, out List<TaxableItem> taxableItems)
        {
            taxTotals = new List<TaxTotal>();
            taxableItems = new List<TaxableItem>();
            if (invoice.TaxTypes.Count != 0)
            {
                var taxableItemDTO = new TaxableItem();
                var taxTotalDTO = new TaxTotal();

                foreach (var tax in invoice.TaxTypes)
                {
                    taxTotalDTO.amount = tax.Amount;
                    taxTotalDTO.taxType = tax.TaxType1;
                    taxTotals.Add(taxTotalDTO);
                }

                foreach (var taxType in invoice.TaxTypes)
                {
                    taxableItemDTO.amount = taxType.Amount;
                    taxableItemDTO.rate = taxType.Rate;
                    taxableItemDTO.subType = taxType.SubType;
                    taxableItemDTO.taxType = taxType.TaxType1;
                    taxableItems.Add(taxableItemDTO);
                }
            }
        }

        private static List<Models.DTOModel.Invoices.Signature> MapSignatures(Invoice invoice)
        {
            var signatures = new List<Models.DTOModel.Invoices.Signature>();

            foreach (var signature in invoice.Signatures)
            {
                var signatureDTO = new Models.DTOModel.Invoices.Signature();
                signatureDTO.type = signature.Type;
                signatureDTO.value = signature.Value;
                signatures.Add(signatureDTO);
            }

            return signatures;
        }
    }
}
