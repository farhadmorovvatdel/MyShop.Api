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
            return await _context.products.Include(p => p.Category).ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.products.FindAsync(id);
        }

        public async Task<List<Product>> GetProductsWithCategory(string catname)
        {
            return await _context.products.Include(p => p.Category).Where(

                p => p.Category.Name == catname).ToListAsync();
        }

        public async Task<List<Product>> SearchProducts(string search)
        {
            return await _context.products.Include(p=>p.Category).
                Where(p=> p.Name.Contains(search) || p.Description.Contains(search)).ToListAsync();
        }

        public async Task UpdateProdcut(int Id, Product product)
        {
            var Product = await _context.products.FindAsync(Id);
            _context.products.Update(Product);
            await _context.SaveChangesAsync();
        }
        public Task<List<Product>> FilterProducts(string? catname, decimal? startprice, decimal? endprice)
        {
            var products=_context.products.AsQueryable();
            if(catname == null && startprice !=null && endprice !=null)
            {
                products = products.Where(p => p.Price >= startprice && p.Price <= endprice);
            }
            else if(catname != null && startprice != null && endprice != null)
            {
                products = products.Where(p=>p.Category.Name ==catname &&  p.Price >= startprice && p.Price <= endprice);
            }
            else if(catname != null &&  startprice==null && endprice == null)
            {
                products=products.Where(p=>p.Category.Name==catname);
            }
            else
            {
                products = products;
            }
            return products.ToListAsync();
        }

        public async Task<Product> GetProductByName(string name)
        {
            var product= await _context.products.SingleOrDefaultAsync(p => p.Name == name);
            return product;

        }

        public async Task<int> GetProductId(int id)
        {
           var product= await _context.products.FindAsync(id);
            return product.Id;
        }
    }
}
