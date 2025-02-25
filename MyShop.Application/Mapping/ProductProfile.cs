using AutoMapper;
using MyShop.Application.Dto.Product;
using MyShop.Application.Extensions;
using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Mapping
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(des => des.Created, op => op.MapFrom(s => s.Created.ShamsiDate().ToPersianNumber()));
                //.ForMember(des => des.Price, op => op.MapFrom(s => s.Price.ToRial().ToPersianNumber()));
        }
    }
}
