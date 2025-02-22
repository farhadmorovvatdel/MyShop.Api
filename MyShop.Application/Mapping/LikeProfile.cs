using AutoMapper;
using MyShop.Application.Dto.Like;
using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Mapping
{
    public class LikeProfile:Profile
    {
        public LikeProfile()
        {
            CreateMap<Like,LIkeDetailDto>();
        }
    }
}
