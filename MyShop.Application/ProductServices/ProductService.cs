using AutoMapper;
using MyShop.Application.Dto.Product;
using MyShop.Application.Vm.Product;
using MyShop.Domain.Entites;
using MyShop.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task AddProduct(ProductVm productVm)
        {
            var product = new Product()
            {
                Name = productVm.Name,
                Price = productVm.Price,
                CategoryId = productVm.CategoryId,
                ProductImage = productVm.ProductImage,
                Description = productVm.Description,
            };
            await _productRepository.CreateProduct(product);
        }

        public async Task DeleteProductById(int id)
        {
            var product= await _productRepository.GetById(id);
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
           
            var products = await _productRepository.GetAllProducst();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public Task<ProductDto> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(int Id, ProductVm productVm)
        {
            throw new NotImplementedException();
        }
    }
}
