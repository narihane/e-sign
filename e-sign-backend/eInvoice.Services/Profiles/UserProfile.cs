using AutoMapper;
using eInvoice.Models.DTOModel;
using eInvoice.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eInvoice.Services.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterationModel, User>()
                .ForMember(d => d.Username, a => a.MapFrom(s => s.UserName))
                .ForMember(d => d.Password, a => a.MapFrom(s => s.Password))
                .ForMember(d => d.Role, a => a.MapFrom(s => s.UserRole))
                .ForPath(d => d.Usersdetail.City, a => a.MapFrom(s => s.City))
                .ForPath(d => d.Usersdetail.Country, a => a.MapFrom(s => s.Country))
                .ForPath(d => d.Usersdetail.Email, a => a.MapFrom(s => s.Email))
                .ForPath(d => d.Usersdetail.FirstName, a => a.MapFrom(s => s.FirstName))
                .ForPath(d => d.Usersdetail.LastName, a => a.MapFrom(s => s.LastName))
                .ForPath(d => d.Usersdetail.Phone, a => a.MapFrom(s => s.Phone))
                .ForPath(d => d.Usersdetail.Street, a => a.MapFrom(s => s.Street))
                .ForPath(d => d.Usersdetail.FullName, a => a.MapFrom(s => $"{s.FirstName.Trim()} {s.LastName.Trim()}"))
                .ForPath(d => d.Usersdetail.FullAddress, a => a.MapFrom(s => $"{s.Country}, {s.City},{s.Street}"))
                .ReverseMap();
        }
    }
}
