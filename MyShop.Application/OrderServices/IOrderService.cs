using MyShop.Application.Dto.OrderDetail;
using MyShop.Application.Dto.User;
using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.OrderServices
{
    public interface IOrderService
    {
    Task CreateOrder(ODetailDto oDetailDtos, int UserId);

       
    }
}
