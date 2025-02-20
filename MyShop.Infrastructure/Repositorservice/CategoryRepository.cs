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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyShopContext _context;
        public CategoryRepository(MyShopContext context)
        {
            _context = context;
        }
        public async Task<Category> CreateAsyncCategory(Category category)
        {
            await _context.categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteAsyncCategory(int Id)
        {
            var category = await _context.categories.FindAsync(Id);
            _context.categories.Remove(category);
            await _context.SaveChangesAsync();

        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int Id)
        {
            return await _context.categories.FindAsync(Id);
        }

        

        public async Task UpdateAsyncCategory(int Id, Category category)
        {
            var cat = await _context.categories.FindAsync(Id);
            _context.categories.Update(cat);
            await _context.SaveChangesAsync();
        }
    }
}
