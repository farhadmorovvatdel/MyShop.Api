using AutoMapper;
using MyShop.Application.Dto.User;
using MyShop.Application.Extensions;
using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Mapping
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<User, ShowUserDto>()
                .ForMember(d => d.CreatedDate, op => op.MapFrom(s => s.CreateDate.ShamsiDate().ToPersianNumber()))
                .ForMember(d => d.PhoneNumber, op => op.MapFrom(s => s.PhoneNumber.ToPersianNumber()));
                
           
                
                
                
        }
    }
}
