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
    public class RateRepository : IRateRepository
    {
        private readonly MyShopContext _context;
        public RateRepository(MyShopContext context)
        {
            _context = context;
        }
        public async Task AddRate(Rate rate)
        {
           await _context.rates.AddAsync(rate);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckUserRate(int UserId, int ProductId)
        {
            return await _context.rates.AnyAsync(r=>r.UserId==UserId && r.ProductId==ProductId);
        }

        public async Task<Rate> GetRate(int UserId, int ProductId)
        {
            var rate=await _context.rates.FirstOrDefaultAsync(r=>r.ProductId==ProductId && r.UserId==UserId);
            return rate;
        }

        public async Task<double> ShowAverageRate(int ProductId)
        {
            return await _context.rates.Where(r=>r.ProductId!=ProductId).AverageAsync(r=>r.RateNumber);
        }
    }
}
