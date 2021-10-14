using AutoMapper;
using eInvoice.Models.DTOModel.Invoices;
using eInvoice.Models.Models;
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
          CreateMap<Invoice, Document>()
               .ForMember(x => x.issuer.address.additionalInformation, x => x.MapFrom(y => y.Company.AdditionalInformation))
               .ForMember(x => x.issuer.address.branchId, x => x.MapFrom(y => y.Company.BranchId))
               .ForMember(x => x.issuer.address.buildingNumber, x => x.MapFrom(y => y.Company.BuildingNumber))
               .ForMember(x => x.issuer.address.country, x => x.MapFrom(y => y.Company.Country))
               .ForMember(x => x.issuer.address.floor, x => x.MapFrom(y => y.Company.Floor))
               .ForMember(x => x.issuer.address.governate, x => x.MapFrom(y => y.Company.Governate))
               .ForMember(x => x.issuer.address.landmark, x => x.MapFrom(y => y.Company.Landmark))
               .ForMember(x => x.issuer.address.postalCode, x => x.MapFrom(y => y.Company.PostalCode))
               .ForMember(x => x.issuer.address.regionCity, x => x.MapFrom(y => y.Company.RegionCity))
               .ForMember(x => x.issuer.address.room, x => x.MapFrom(y => y.Company.FlatNumber))
               .ForMember(x => x.issuer.address.street, x => x.MapFrom(y => y.Company.Street))
               .ForMember(x => x.issuer.id, x => x.MapFrom(y => y.Company.RegistrationNumber))
               .ForMember(x => x.issuer.name, x => x.MapFrom(y => y.Company.Name))
               .ForMember(x => x.issuer.type, x => x.MapFrom(y => y.Company.Type))
               .ForMember(x => x.receiver.address.additionalInformation, x => x.MapFrom(y => y.Company.AdditionalInformation))
               .ForMember(x => x.receiver.address.branchId, x => x.MapFrom(y => y.Company.BranchId))
               .ForMember(x => x.receiver.address.buildingNumber, x => x.MapFrom(y => y.Company.BuildingNumber))
               .ForMember(x => x.receiver.address.country, x => x.MapFrom(y => y.Company.Country))
               .ForMember(x => x.receiver.address.floor, x => x.MapFrom(y => y.Company.Floor))
               .ForMember(x => x.receiver.address.governate, x => x.MapFrom(y => y.Company.Governate))
               .ForMember(x => x.receiver.address.landmark, x => x.MapFrom(y => y.Company.Landmark))
               .ForMember(x => x.receiver.address.postalCode, x => x.MapFrom(y => y.Company.PostalCode))
               .ForMember(x => x.receiver.address.regionCity, x => x.MapFrom(y => y.Company.RegionCity))
               .ForMember(x => x.receiver.address.room, x => x.MapFrom(y => y.Company.FlatNumber))
               .ForMember(x => x.receiver.address.street, x => x.MapFrom(y => y.Company.Street))
               .ForMember(x => x.receiver.id, x => x.MapFrom(y => y.Company.RegistrationNumber))
               .ForMember(x => x.receiver.name, x => x.MapFrom(y => y.Company.Name))
               .ForMember(x => x.receiver.type, x => x.MapFrom(y => y.Company.Type))

               .ForMember(x => x.documentType, x => x.MapFrom(y => y.DocumentType))
               .ForMember(x => x.documentTypeVersion, x => x.MapFrom(y => y.DocumentTypeversion))
               .ForMember(x => x.dateTimeIssued, x => x.MapFrom(y => y.DateIssued))
               .ForMember(x => x.taxpayerActivityCode, x => x.MapFrom(y => y.TaxpayerActivityCode))
               .ForMember(x => x.internalId, x => x.MapFrom(y => y.InteranlId))
               .ForMember(x => x.purchaseOrderReference, x => x.MapFrom(y => y.PurchaseOrderReference))
               .ForMember(x => x.purchaseOrderDescription, x => x.MapFrom(y => y.PurchaseOrderDescription))
               .ForMember(x => x.salesOrderReference, x => x.MapFrom(y => y.SalesOrderReference))
               .ForMember(x => x.salesOrderDescription, x => x.MapFrom(y => y.SalesOrderDescription))
               .ForMember(x => x.proformaInvoiceNumber, x => x.MapFrom(y => y.ProformaInvoiceNumber))
               //.ForMember(x => x.payment., x => x.MapFrom(y => y.InteranlId))
               //.ForMember(x => x.internalId, x => x.MapFrom(y => y.InteranlId))
               //.ForMember(x => x.internalId, x => x.MapFrom(y => y.InteranlId))




        }
    }
}
