using AutoMapper;
using eInvoice.Models.DTOModel.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Profiles
{
    public class CodesProfile : Profile
    {
        public CodesProfile()
        {
            CreateMap<NewCodeItemsDTO, NewCodeItems>()
                .ForMember(d => d.activeFrom, a => a.MapFrom(s => s.ActiveFrom))
                .ForMember(d => d.activeTo, a => a.MapFrom(s => s.ActiveTo))
                .ForMember(d => d.codeName, a => a.MapFrom(s => s.CodeName))
                .ForMember(d => d.codeNameAr, a => a.MapFrom(s => s.CodeName2Ar))
                .ForMember(d => d.codeType, a => a.MapFrom(s => s.CodeType))
                .ForMember(d => d.itemCode, a => a.MapFrom(s => s.ItemCode))
                .ForMember(d => d.parentCode, a => a.MapFrom(s => s.GPCItemLinked))
                .ForMember(d => d.description, a => a.MapFrom(s => !string.IsNullOrWhiteSpace(s.Description) ? s.Description : string.Empty))
                .ForMember(d => d.descriptionAr, a => a.MapFrom(s => !string.IsNullOrWhiteSpace(s.DescriptionAr) ? s.DescriptionAr : string.Empty))
                .ForMember(d => d.linkedCode, a => a.MapFrom(s => !string.IsNullOrWhiteSpace(s.EGSRelatedCode) ? s.EGSRelatedCode : string.Empty))
                .ForMember(d => d.requestReason, a => a.MapFrom(s => !string.IsNullOrWhiteSpace(s.RequestReason) ? s.RequestReason : string.Empty))
                .ReverseMap();
        }
    }
}
