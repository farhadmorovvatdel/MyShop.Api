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
    public class ProductRepository : IProductRepository
    {
        private readonly MyShopContext _context;
        public ProductRepository(MyShopContext context)
        {
            _context = context;
        }
        public async Task CreateProduct(Product product)
        {
            _context.products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.products.FindAsync(id);
            _context.products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllProducst()
        {
            return await _context.products.Include(p=>p.Category).ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.products.FindAsync(id);
        }

        public Task UpdateProdcut(int Id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
