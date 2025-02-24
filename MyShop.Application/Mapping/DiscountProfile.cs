using AutoMapper;
using MyShop.Application.Dto.DiscountCode;
using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Mapping
{
    public class DiscountProfile:Profile
    {
        public DiscountProfile()
        {
            CreateMap<DiscountCode, ShowDiscount>();            
        }
    }
}
