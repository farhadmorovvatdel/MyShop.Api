using AutoMapper;
using MyShop.Application.Dto.DiscountCode;
using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Application.Extensions;

namespace MyShop.Application.Mapping
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<DiscountCode, ShowDiscount>()
             .ForMember(d => d.StartDate, opt => opt.MapFrom(sr => sr.StartDate.ShamsiDate().ToPersianNumber()))
             .ForMember(d => d.EndDate, opt => opt.MapFrom(sr => sr.EndDate.ShamsiDate().ToPersianNumber()));
             
        }
    }
}
