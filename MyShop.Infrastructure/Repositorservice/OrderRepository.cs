using Microsoft.EntityFrameworkCore;
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
    public class OrderRepository : IOrderInterface
    {
        private readonly MyShopContext _context;
        public OrderRepository(MyShopContext context)
        {
            _context = context;
        }

        public async Task<Order> CheckExitsOrders(int UserId)
        {
            Order order=await _context.orders.Include(o=>o.Deatils).FirstOrDefaultAsync(o=>o.UserId==UserId && o.IsPay==false);
            return order;
            
        }

       
        public async Task<Order> CreateOrder(Order order)
        {
           
            await _context.orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;

        }

        public async Task DeleteOrders(int OrderId,int UserId)
        {
            var CurrentOrder = await _context.orders.FirstOrDefaultAsync(o => o.UserId == UserId &&o.Id==OrderId && o.IsPay == false);
            if (CurrentOrder != null)
            {
                _context.orders.Remove(CurrentOrder);
                await _context.SaveChangesAsync();
            }
            //throw new Exception("سفارشی وجود ندارد");
                
        }

        public async Task<Order> GetOrdersById(int Id)
        {
            var order = await _context.orders.FindAsync(Id);
            return order;
        }

        public async Task<List<Order>> GetUserOrder(int UserId)
        {
            return await _context.orders.Include(c=>c.Deatils).Where(c=>c.UserId==UserId && c.IsPay==false).ToListAsync();
        }

        public async Task UpdateOrder(Order order)
        {
           
            _context.orders.Update(order);
            await _context.SaveChangesAsync();

        }
    }
}
