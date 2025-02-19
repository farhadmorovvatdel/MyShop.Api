using MyShop.Application.Dto.Product;
using MyShop.Application.Vm.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.ProductServices
{
    public interface IProductService
    {
        Task AddProduct(ProductVm productVm);
        Task<List<ProductDto>> GetAllProducts();
        Task <ProductDto> GetProductById(int id);

        Task DeleteProductById(int id);

        Task UpdateProduct(int Id,ProductVm productVm);

    }
}
