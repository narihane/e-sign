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
            //var signatures = MapSignatures(invoice);
            var invoiceLines = MapInvoiceLines(invoice, taxableItems);

            Document document = new Document
            {
                internalId = invoice.InteranlId,
                dateTimeIssued = invoice.DateIssued,
                documentType = invoice.DocumentType,
                documentTypeVersion = invoice.DocumentTypeversion,
                extraDiscountAmount = invoice.ExtraDiscountAmount,
                netAmount = invoice.NetAmount,
                proformaInvoiceNumber = invoice.ProformaInvoiceNumber,
                purchaseOrderDescription = invoice.PurchaseOrderDescription,
                purchaseOrderReference = invoice.PurchaseOrderReference,
                salesOrderDescription = invoice.SalesOrderDescription,
                salesOrderReference = invoice.SalesOrderReference,
                //signatures = signatures,
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
            if (invoice.Delivery != null)
            {
                document.delivery = new Models.DTOModel.Invoices.Delivery
                {
                    approach = invoice.Delivery?.Approach,
                    countryOfOrigin = invoice.Delivery?.CountryOfOrigin,
                    dateValidity = invoice.Delivery?.DateValidity,
                    exportPort = invoice.Delivery?.ExportPort,
                    grossWeight = invoice.Delivery?.GrossWeight,
                    netWeight = invoice.Delivery?.NetWeight,
                    packaging = invoice.Delivery?.Packaging,
                    terms = invoice.Delivery?.Terms
                };
            }

            if (invoice.Payment != null)
            {
                document.payment = new Models.DTOModel.Invoices.Payment
                {
                    bankAccountIBAN = invoice.Payment?.BankAccountIban,
                    bankAccountNo = invoice.Payment?.BankAccountNo,
                    bankAddress = invoice.Payment?.BankAddress,
                    bankName = invoice.Payment?.BankName,
                    swiftCode = invoice.Payment?.SwiftCode,
                    terms = invoice.Payment?.Terms
                };
            }

            return document;
        }

        public static Invoice MapDocumentToInvoice(Document document)
        {
            List<Product> products = new List<Product>();
            List<TaxType> taxTypes = new List<TaxType>();
            List<Models.Models.Signature> signatures = new List<Models.Models.Signature>();

            foreach (var esignature in document.signatures)
            {
                var signature = new Models.Models.Signature
                {
                    Type = esignature.signatureType,
                    Value = esignature.value,
                    InvoiceInternalId = document.internalId
                };
                signatures.Add(signature);
            }

            foreach (var invoiceLine in document.invoiceLines)
            {
                if (invoiceLine.taxableItems.Count != 0)
                {
                    foreach (var item in invoiceLine.taxableItems)
                    {
                        var taxType = new TaxType();
                        taxType.Amount = item.amount;
                        taxType.Rate = item.rate;
                        taxType.SubType = item.subType;
                        taxType.TaxType1 = item.taxType;
                        taxType.InvoiceInternalId = document.internalId;
                        taxTypes.Add(taxType);
                    }
                }
                var product = new Product
                {
                    AmountEgp = invoiceLine.unitValue.amountEGP,
                    AmountSold = invoiceLine.unitValue.amountSold,
                    CurrencyExchangeRate = invoiceLine.unitValue.currencyExchangeRate,
                    CurrencySold = invoiceLine.unitValue.currencySold,
                    Description = invoiceLine.description,
                    DiscountAmount = invoiceLine.discount?.amount,
                    DiscountRate = invoiceLine.discount?.rate,
                    InternalCode = invoiceLine.internalCode,
                    ItemCode = invoiceLine.itemCode,
                    ItemsDiscount = invoiceLine.itemsDiscount,
                    ItemType = invoiceLine.itemType,
                    NetTotal = invoiceLine.netTotal,
                    Quantity = invoiceLine.quantity,
                    SalesTotal = invoiceLine.salesTotal,
                    Total = invoiceLine.total,
                    TotalTaxableFees = invoiceLine.totalTaxableFees,
                    UnitType = invoiceLine.unitType,
                    ValueDifference = invoiceLine.valueDifference,
                    InvoiceInternalId = document.internalId
                };
                products.Add(product);
            }

            Invoice invoice = new Invoice
            {
                Issuer = new Models.Models.Issuer
                {
                    AdditionalInformation = document.issuer.address.additionalInformation,
                    BranchId = document.issuer.address.branchId,
                    BuildingNumber = document.issuer.address.buildingNumber,
                    Country = document.issuer.address.country,
                    FlatNumber = document.issuer.address.room,
                    Governate = document.issuer.address.governate,
                    Floor = document.issuer.address.floor,
                    Landmark = document.issuer.address.landmark,
                    Name = document.issuer.name,
                    PostalCode = document.issuer.address.postalCode,
                    RegionCity = document.issuer.address.regionCity,
                    RegistrationNumber = document.issuer.id,
                    Street = document.issuer.address.street,
                    Type = document.issuer.type,
                },
                Receiver = new Models.Models.Receiver
                {
                    AdditionalInformation = document.receiver.address?.additionalInformation,
                    BranchId = document.receiver.address?.branchId,
                    BuildingNumber = document.receiver.address?.buildingNumber,
                    Country = document.receiver.address?.country,
                    FlatNumber = document.receiver.address?.room,
                    Governate = document.receiver.address?.governate,
                    Floor = document.receiver.address?.floor,
                    Landmark = document.receiver.address?.landmark,
                    Name = document.receiver.name,
                    PostalCode = document.receiver.address?.postalCode,
                    RegionCity = document.receiver.address?.regionCity,
                    RegistrationNumber = document.receiver.id,
                    Street = document.receiver.address?.street,
                    Type = document.receiver.type,
                },
                DateIssued = document.dateTimeIssued,
                DocumentType = document.documentType,
                DocumentTypeversion = document.documentTypeVersion,
                ExtraDiscountAmount = document.extraDiscountAmount,
                InteranlId = document.internalId,
                NetAmount = document.netAmount,
                ProformaInvoiceNumber = document.proformaInvoiceNumber,
                PurchaseOrderDescription = document.purchaseOrderDescription,
                PurchaseOrderReference = document.purchaseOrderReference,
                SalesOrderDescription = document.salesOrderDescription,
                SalesOrderReference = document.salesOrderReference,
                TaxpayerActivityCode = document.taxpayerActivityCode,
                TotalAmount = document.totalAmount,
                TotalDiscountAmount = document.totalDiscountAmount,
                TotalItemsDiscountAmount = document.totalItemsDiscountAmount,
                TotalSalesAmount = document.totalSalesAmount,
                TaxTypes = taxTypes,
                Products = products,
                Signatures = signatures
            };

            if (document.delivery != null)
            {
                invoice.Delivery = new Models.Models.Delivery
                {
                    Approach = document.delivery?.approach,
                    CountryOfOrigin = document.delivery?.countryOfOrigin,
                    DateValidity = document.delivery?.dateValidity,
                    ExportPort = document.delivery?.exportPort,
                    GrossWeight = document.delivery?.grossWeight,
                    NetWeight = document.delivery?.netWeight,
                    Packaging = document.delivery?.packaging,
                    Terms = document.delivery?.terms
                };
            }

            if (document.payment != null)
            {
                invoice.Payment = new Models.Models.Payment
                {
                    BankAccountIban = document.payment?.bankAccountIBAN,
                    BankAccountNo = document.payment?.bankAccountNo,
                    BankAddress = document.payment?.bankAddress,
                    BankName = document.payment?.bankName,
                    SwiftCode = document.payment?.swiftCode,
                    Terms = document.payment?.terms,
                };
            }

            return invoice;
        }

        private static List<InvoiceLine> MapInvoiceLines(Invoice invoice, List<TaxableItem> taxableItems)
        {
            var invoiceLines = new List<InvoiceLine>();

            foreach (var product in invoice.Products)
            {
                var invoiceLineDTO = new InvoiceLine();
                invoiceLineDTO.description = product.Description;
                if ((product.DiscountAmount != 0 || product.DiscountAmount != null) && (product.DiscountRate != 0 || product.DiscountRate != null))
                    invoiceLineDTO.discount = new Discount
                    {
                        amount = product.DiscountAmount,
                        rate = product.DiscountRate
                    };
                invoiceLineDTO.internalCode = product.InternalCode;
                invoiceLineDTO.itemCode = product.ItemCode;
                invoiceLineDTO.itemsDiscount = product.ItemsDiscount;
                invoiceLineDTO.itemType = product.ItemType;
                invoiceLineDTO.netTotal = product.NetTotal;
                invoiceLineDTO.quantity = product.Quantity;
                invoiceLineDTO.salesTotal = product.SalesTotal;
                invoiceLineDTO.total = product.Total;
                invoiceLineDTO.totalTaxableFees = product.TotalTaxableFees;
                invoiceLineDTO.unitType = product.UnitType;
                invoiceLineDTO.unitValue = new Value
                {
                    amountEGP = product.AmountEgp,
                    amountSold = product.AmountSold,
                    currencyExchangeRate = product.CurrencyExchangeRate,
                    currencySold = product.CurrencySold
                };
                invoiceLineDTO.valueDifference = product.ValueDifference;
                invoiceLineDTO.taxableItems = taxableItems;

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
                signatureDTO.signatureType = signature.Type;
                signatureDTO.value = signature.Value;
                signatures.Add(signatureDTO);
            }

            return signatures;
        }
    }
}
