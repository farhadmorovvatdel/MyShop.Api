using MyShop.Domain.Entites;
using MyShop.Domain.Interface;
using MyShop.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositorservice
{
    public class OrderDetailRepository : IOrderDetailRepository
    { 
        private readonly MyShopContext _context;
        public OrderDetailRepository(MyShopContext context)
        {
            _context = context;
        }

        

        public async Task<OrderDetail> CreateOrderDetail(OrderDetail orderDetail)
        {
            await _context.ordersDetail.AddAsync(orderDetail);
            await _context.SaveChangesAsync();
            return orderDetail;
            
        }

        public async Task UpdateOrderDetail(OrderDetail orderDetail)
        {
            _context.ordersDetail.Update(orderDetail);
            await _context.SaveChangesAsync();
        }
    }
}
