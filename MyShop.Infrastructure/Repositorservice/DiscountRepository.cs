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
    public class DiscountRepository : IDiscountRepository
    {
        private readonly MyShopContext _context;
        public DiscountRepository(MyShopContext context)
        {
            _context = context;
        }
        public async Task CreateDiscount(DiscountCode discountCode)
        {
            await _context.discounts.AddAsync(discountCode);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDiscount(int Id)
        {
            var discocunt=await GetDiscountById(Id);    
            _context.discounts.Remove(discocunt);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DiscountCode>> GetAll()
        {
            return await _context.discounts.ToListAsync();
        }

        public async Task<DiscountCode> GetDiscountById(int id)
        {
            return await _context.discounts.FindAsync(id);
        }

        public async Task<DiscountCode> UpdateDiscount(int Id, DiscountCode Dto)
        {
            var disocunt=await GetDiscountById(Id);
            _context.discounts.Update(disocunt);
            await _context.SaveChangesAsync();
            return disocunt;
          
        }
        
        
    }
}
