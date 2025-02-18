using AutoMapper;
using MyShop.Application.Dto.User;
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
            CreateMap<User,ShowUserDto>();
        }
    }
}
