using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Interface
{
    public interface IRateRepository
    {
        Task AddRate(Rate rate);
        Task<Rate> GetRate(int UserId,int ProductId);
        Task<bool> CheckUserRate(int UserId,int ProductId);
        Task<double> ShowAverageRate(int ProductId);
    }
}
