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
        Task<List<ShowProductDto>> GetAllProducts();
        Task <ShowProductDto> GetProductById(int id);
        Task<int> GetProductId(int id);
        Task DeleteProductById(int id);

        Task UpdateProduct(int Id,ProductVm productVm);

        Task<List<ShowProductDto>> GetProductCategory(string categoryName);
        Task<List<ShowProductDto>> SearchProdcuts(string search);

        Task<List<ShowProductDto>> FilterProduct(string? catname, decimal? startprice, decimal? endprice);
        Task<ShowProductDto> GetProductByName(string name);
    }
}
