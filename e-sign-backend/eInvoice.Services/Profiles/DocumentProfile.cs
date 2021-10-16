using AutoMapper;
using eInvoice.Models.DTOModel.Invoices;
//using eInvoice.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Profiles
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            //CreateMap<Invoice, Documents>()
            //    .IncludeMembers(s=>s.Delivery)
            //     .ForPath(x => x.issuer.address.additionalInformation, x => x.MapFrom(y => y.Company.AdditionalInformation))
            //     .ForPath(x => x.issuer.address.branchId, x => x.MapFrom(y => y.Company.BranchId))
            //     .ForPath(x => x.issuer.address.buildingNumber, x => x.MapFrom(y => y.Company.BuildingNumber))
            //     .ForPath(x => x.issuer.address.country, x => x.MapFrom(y => y.Company.Country))
            //     .ForPath(x => x.issuer.address.floor, x => x.MapFrom(y => y.Company.Floor))
            //     .ForPath(x => x.issuer.address.governate, x => x.MapFrom(y => y.Company.Governate))
            //     .ForPath(x => x.issuer.address.landmark, x => x.MapFrom(y => y.Company.Landmark))
            //     .ForPath(x => x.issuer.address.postalCode, x => x.MapFrom(y => y.Company.PostalCode))
            //     .ForPath(x => x.issuer.address.regionCity, x => x.MapFrom(y => y.Company.RegionCity))
            //     .ForPath(x => x.issuer.address.room, x => x.MapFrom(y => y.Company.FlatNumber))
            //     .ForPath(x => x.issuer.address.street, x => x.MapFrom(y => y.Company.Street))
            //     .ForPath(x => x.issuer.id, x => x.MapFrom(y => y.Company.RegistrationNumber))
            //     .ForPath(x => x.issuer.name, x => x.MapFrom(y => y.Company.Name))
            //     .ForPath(x => x.issuer.type, x => x.MapFrom(y => y.Company.Type))

            //     .ForPath(x => x.receiver.address.additionalInformation, x => x.MapFrom(y => y.Company.AdditionalInformation))
            //     .ForPath(x => x.receiver.address.branchId, x => x.MapFrom(y => y.Company.BranchId))
            //     .ForPath(x => x.receiver.address.buildingNumber, x => x.MapFrom(y => y.Company.BuildingNumber))
            //     .ForPath(x => x.receiver.address.country, x => x.MapFrom(y => y.Company.Country))
            //     .ForPath(x => x.receiver.address.floor, x => x.MapFrom(y => y.Company.Floor))
            //     .ForPath(x => x.receiver.address.governate, x => x.MapFrom(y => y.Company.Governate))
            //     .ForPath(x => x.receiver.address.landmark, x => x.MapFrom(y => y.Company.Landmark))
            //     .ForPath(x => x.receiver.address.postalCode, x => x.MapFrom(y => y.Company.PostalCode))
            //     .ForPath(x => x.receiver.address.regionCity, x => x.MapFrom(y => y.Company.RegionCity))
            //     .ForPath(x => x.receiver.address.room, x => x.MapFrom(y => y.Company.FlatNumber))
            //     .ForPath(x => x.receiver.address.street, x => x.MapFrom(y => y.Company.Street))
            //     .ForPath(x => x.receiver.id, x => x.MapFrom(y => y.Company.RegistrationNumber))
            //     .ForPath(x => x.receiver.name, x => x.MapFrom(y => y.Company.Name))
            //     .ForPath(x => x.receiver.type, x => x.MapFrom(y => y.Company.Type))

            //     .ForMember(x => x.documentType, x => x.MapFrom(y => y.DocumentType))
            //     .ForMember(x => x.documentTypeVersion, x => x.MapFrom(y => y.DocumentTypeversion))
            //     .ForMember(x => x.dateTimeIssued, x => x.MapFrom(y => y.DateIssued))
            //     .ForMember(x => x.taxpayerActivityCode, x => x.MapFrom(y => y.TaxpayerActivityCode))
            //     .ForMember(x => x.internalId, x => x.MapFrom(y => y.InteranlId))
            //     .ForMember(x => x.purchaseOrderReference, x => x.MapFrom(y => y.PurchaseOrderReference))
            //     .ForMember(x => x.purchaseOrderDescription, x => x.MapFrom(y => y.PurchaseOrderDescription))
            //     .ForMember(x => x.salesOrderReference, x => x.MapFrom(y => y.SalesOrderReference))
            //     .ForMember(x => x.salesOrderDescription, x => x.MapFrom(y => y.SalesOrderDescription))
            //     .ForMember(x => x.proformaInvoiceNumber, x => x.MapFrom(y => y.ProformaInvoiceNumber))

            //     .ForPath(x => x.payment.bankAccountIBAN, x => x.MapFrom(y => y.Payment.BankAccountIban))
            //     .ForPath(x => x.payment.bankAccountNo, x => x.MapFrom(y => y.Payment.BankAccountNo))
            //     .ForPath(x => x.payment.bankAddress, x => x.MapFrom(y => y.Payment.BankAddress))
            //     .ForPath(x => x.payment.bankName, x => x.MapFrom(y => y.Payment.BankName))
            //     .ForPath(x => x.payment.swiftCode, x => x.MapFrom(y => y.Payment.SwiftCode))
            //     .ForPath(x => x.payment.terms, x => x.MapFrom(y => y.Payment.Terms))

            //     .ForPath(x => x.delivery.approach, x => x.MapFrom(y => y.Delivery.Approach))
            //     .ForPath(x => x.delivery.countryOfOrigin, x => x.MapFrom(y => y.Delivery.CountryOfOrigin))
            //     .ForPath(x => x.delivery.dateValidity, x => x.MapFrom(y => y.Delivery.DateValidity))
            //     .ForPath(x => x.delivery.exportPort, x => x.MapFrom(y => y.Delivery.ExportPort))
            //     .ForPath(x => x.delivery.grossWeight, x => x.MapFrom(y => y.Delivery.GrossWeight))
            //     .ForPath(x => x.delivery.netWeight, x => x.MapFrom(y => y.Delivery.NetWeight))
            //     .ForPath(x => x.delivery.packaging, x => x.MapFrom(y => y.Delivery.Packaging))
            //     .ForPath(x => x.delivery.terms, x => x.MapFrom(y => y.Delivery.Terms))

            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.description), x => x.MapFrom(y => y.Products.Select(src => src.Description)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.itemType), x => x.MapFrom(y => y.Products.Select(src => src.ItemType)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.itemCode), x => x.MapFrom(y => y.Products.Select(src => src.ItemCode)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.unitType), x => x.MapFrom(y => y.Products.Select(src => src.UnitType)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.quantity), x => x.MapFrom(y => y.Products.Select(src => src.Quantity)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.unitValue.currencySold), x => x.MapFrom(y => y.Products.Select(src => src.CurrencySold)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.unitValue.amountEGP), x => x.MapFrom(y => y.Products.Select(src => src.AmountEgp)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.unitValue.amountSold), x => x.MapFrom(y => y.Products.Select(src => src.AmountSold)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.unitValue.currencyExchangeRate), x => x.MapFrom(y => y.Products.Select(src => src.CurrencyExchangeRate)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.unitValue.currencySold), x => x.MapFrom(y => y.Products.Select(src => src.CurrencySold)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.salesTotal), x => x.MapFrom(y => y.Products.Select(src => src.SalesTotal)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.total), x => x.MapFrom(y => y.Products.Select(src => src.Total)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.valueDifference), x => x.MapFrom(y => y.Products.Select(src => src.ValueDifference)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.totalTaxableFees), x => x.MapFrom(y => y.Products.Select(src => src.TotalTaxableFees)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.netTotal), x => x.MapFrom(y => y.Products.Select(src => src.NetTotal)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.itemsDiscount), x => x.MapFrom(y => y.Products.Select(src => src.ItemsDiscount)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.discount.amount), x => x.MapFrom(y => y.Products.Select(src => src.DiscountAmount)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.discount.rate), x => x.MapFrom(y => y.Products.Select(src => src.DiscountRate)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.taxableItems.Select(d => d.taxType)), x => x.MapFrom(y => y.TaxTypes.Select(src => src.TaxType1)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.taxableItems.Select(d => d.subType)), x => x.MapFrom(y => y.TaxTypes.Select(src => src.SubType)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.taxableItems.Select(d => d.rate)), x => x.MapFrom(y => y.TaxTypes.Select(src => src.Rate)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.taxableItems.Select(d => d.amount)), x => x.MapFrom(y => y.TaxTypes.Select(src => src.Amount)))
            //     //.ForMember(x => x.invoiceLines.Select(dest => dest.internalCode), x => x.MapFrom(y => y.Products.Select(src => src.InternalCode)))

            //     //.ForMember(x => x.totalSalesAmount, x => x.MapFrom(y => y.TotalSalesAmount))
            //     //.ForMember(x => x.totalDiscountAmount, x => x.MapFrom(y => y.TotalDiscountAmount))
            //     //.ForMember(x => x.netAmount, x => x.MapFrom(y => y.NetAmount))
            //     ////.ForMember(x => x.taxTotals.Select(dest => dest.taxType), x => x.MapFrom(y => y.TaxTypes.Select(src => src.TaxType1)))
            //     ////.ForMember(x => x.taxTotals.Select(dest => dest.amount), x => x.MapFrom(y => y.TaxTypes.Select(src => src.Amount)))
            //     //.ForMember(x => x.extraDiscountAmount, x => x.MapFrom(y => y.ExtraDiscountAmount))
            //     //.ForMember(x => x.totalItemsDiscountAmount, x => x.MapFrom(y => y.TotalItemsDiscountAmount))
            //     //.ForMember(x => x.totalAmount, x => x.MapFrom(y => y.TotalAmount))
            //     //.ForMember(x => x.signatures.Select(dest => dest.type), x => x.MapFrom(y => y.Signatures.Select(src => src.Type)))
            //     //.ForMember(x => x.signatures.Select(dest => dest.value), x => x.MapFrom(y => y.Signatures.Select(src => src.Value)))
            //     .ReverseMap();

            //CreateMap<Models.Models.Delivery, Documents>()
            //    .ReverseMap();
        }
    }
}
