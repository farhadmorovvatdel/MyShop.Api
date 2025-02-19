using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducst();
        Task<Product> GetById(int id);

        Task DeleteProduct(int id);
        Task UpdateProdcut(int Id,Product product);

        Task CreateProduct(Product product);
       

    }
}
