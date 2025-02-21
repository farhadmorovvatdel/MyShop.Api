using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Interface
{
    public interface IOrderInterface
    {
        Task<Order> CreateOrder(Order order);

        Task DeleteOrders(int Id);

        Task<Order> GetOrdersById(int Id);

        Task UpdateOrder(Order order);
        Task<Order> CheckExitsOrders(int UserId);
        
        Task<List<Order>> GetUserOrder(int UserId);
    }
}
