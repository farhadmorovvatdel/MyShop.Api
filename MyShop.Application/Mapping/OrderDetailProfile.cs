using AutoMapper;
using MyShop.Application.Dto.OrderDetail;
using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.Mapping
{
    public class OrderDetailProfile:Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetail, SHowOrderDetail>();
        }
    }
}
