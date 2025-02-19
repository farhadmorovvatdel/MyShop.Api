using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Application.ProductServices;

namespace MyShop.Api.Controllers
{
    [Route("api/Admin")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("Products")]
        public async Task<IActionResult> ShowProducts()
        {
            var products = await _productService.GetAllProducts();  
            if (!products.Any())
            {
                return NotFound("هیچ محصولی یافت نشد");
            } 
            return Ok(products);
        }
    }
        
}
