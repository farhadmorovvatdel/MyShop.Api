using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
        public ProductService(IProductRepository productRepository, IMapper mapper)
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
            var product = await _productRepository.GetById(id);
        }

        public async Task<List<ProductDto>> FilterProduct(string? catname, decimal? startprice, decimal? endprice)
        {
            var products = await _productRepository.FilterProducts(catname, startprice, endprice);
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {

            var products = await _productRepository.GetAllProducst();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await _productRepository.GetById(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> GetProductByName(string name)
        {
            var product=await _productRepository.GetProductByName(name);
            return _mapper.Map<ProductDto>(product);    
        }

        public async Task<List<ProductDto>> GetProductCategory(string categoryName)
        {
            var products = await _productRepository.GetProductsWithCategory(categoryName);
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<int> GetProductId(int id)
        {
            return await _productRepository.GetProductId(id);
            
        }

        public async Task<List<ProductDto>> SearchProdcuts(string search)
        {
            var products = await _productRepository.SearchProducts(search);
            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task UpdateProduct(int Id, ProductVm productVm)
        {


            var product = await _productRepository.GetById(Id);

            product.Name = productVm.Name;
            product.Price = productVm.Price;
            product.CategoryId = productVm.CategoryId;
            product.ProductImage = productVm.ProductImage;
            product.Description = productVm.Description;


            await _productRepository.UpdateProdcut(Id, product);
        }
    }
}
