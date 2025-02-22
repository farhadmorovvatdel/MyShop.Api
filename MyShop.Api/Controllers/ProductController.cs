using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MyShop.Application.CommentServices;
using MyShop.Application.Dto.Comment;
using MyShop.Application.Dto.Like;
using MyShop.Application.LikeServices;
using MyShop.Application.ProductServices;
using MyShop.Application.Vm.Product;
using MyShop.Domain.Entites;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace MyShop.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILIkeService _likeService;
        private readonly ICommentService _commentService;
        public ProductController(IProductService productService, ILIkeService lIkeService,ICommentService commentService)
        {
            _productService = productService;
            _likeService = lIkeService;
            _commentService = commentService;
        }
        [HttpGet("Admin/Products")]
        public async Task<IActionResult> ShowProducts()
        {
            var products = await _productService.GetAllProducts();
            if (!products.Any())
            {
                return NotFound("هیچ محصولی یافت نشد");
            }
            return Ok(products);
        }
        [HttpPost("Admin/product/create")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductVm model)
        {
            if (model == null)
            {
                return BadRequest("فیلدهای ورود صحیح نمی باشد");
            }
            await _productService.AddProduct(model);
            return Ok("محصول با موئفقیت ایجاد شد");
        }
        [HttpGet("Admin/Product/{Id:int}")]
        public async Task<IActionResult> GetProduct([FromRoute] int Id)
        {
            var product = await _productService.GetProductById(Id);
            if (product == null)
            {
                return NotFound("محصول مورد نظر شما یافت نشد");
            }
            return Ok(product);
        }
        [HttpPut("Admin/Product/Update/{Id:int}")]
        public async Task<IActionResult> UpdateProdcut([FromRoute] int Id, ProductVm model)
        {
            if (model == null)
            {
                return BadRequest("فیلدهای ورود صحیح نمی باشد");
            }
            var Product = await _productService.GetProductById(Id);
            if (Product == null)
            {
                return NotFound("محصول مورد نظر یافت نشد");
            }
            await _productService.UpdateProduct(Id, model);
            return Ok("ویرایش محصول با موفقیت انجام شد");
        }
        [HttpDelete("Admin/Product/Delete/{Id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int Id)
        {
            var product = await _productService.GetProductById(Id);
            if (product == null)
            {
                return NotFound("محصول مورد نظر یافت نشد");
            }
            await _productService.DeleteProductById(Id);
            return Ok("محصول مورد نظر با موفقیت حذف شد");
        }

        [HttpGet("Product/search")]
        public async Task<IActionResult> GetProductByCategory([FromQuery] string catname)
        {
            var products = await _productService.GetProductCategory(catname);
            if (!products.Any())
            {
                return NotFound("محصولی مطابق درخواست شما یافت نشد");
            }
            return Ok(products);
        }

        [HttpGet("AllProducts/query")]
        public async Task<IActionResult> ShowAllProducts(string? search)
        {
            var products = await _productService.SearchProdcuts(search);
            if (string.IsNullOrEmpty(search))
            {
                var product = await _productService.GetAllProducts();
                return Ok(product);
            }

            if (!products.Any())
            {
                return NotFound("محصولی مطابق فیلتر شما یافت نشد");
            }
            return Ok(products);
        }
        [HttpGet("Products/filter")]
        public async Task<IActionResult> FilterProduct([FromQuery] string? catname, decimal? startprice, decimal? endprice)
        {
            var products = await _productService.FilterProduct(catname, startprice, endprice);
            if (!products.Any())
            {
                return NotFound("محصولی مطابق فیلتر شما یافت نشد");
            }
            return Ok(products);
        }
        [HttpGet("Products/detail/{productname}")]
        public async Task<IActionResult> ShowProductDeatil([FromRoute] string productname)
        {
            var product = await _productService.GetProductByName(productname);
            if (product == null)
            {
                return NotFound("محصول مورد نظر یافت نشد");
            }
            return Ok(product);
        }
        [Authorize(Policy = "UserRole")]
        [HttpPost("Product/Like")]
        public async Task<IActionResult> LikePost([FromBody] LikeDto like)
        {
            int productId = await _productService.GetProductId(like.ProductId);
            if (productId == 0)
            {
                return NotFound("محصول مورد نظر یافت نشد");
            }

            int userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            if (userId == 0)
            {
                return Unauthorized();
            }
            var LikedProduct=await _likeService.CheckExistsLike(like);

                
            if (LikedProduct == null)
            {
                await _likeService.LikePost(like);
                return Ok("لایک پست");
            }
            await _likeService.RemoveProductLike(like);
            return Ok("انلایک پست");


        }
        [Authorize(Policy ="UserRole")]
        [HttpPost("Product/Comment/Create")]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto commentDto)
        {
            int UserId= Convert.ToInt32(User.Claims.FirstOrDefault(c=>c.Type==ClaimTypes.NameIdentifier)?.Value);
            if (UserId == 0)
            {
                return Unauthorized();
            }
            var comment=await _commentService.AddComment(UserId, commentDto);
            return Ok(comment);
        }
        [Authorize(Policy = "UserRole")]
        [HttpPut("Product/Comment/Update")]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentDto commentDto)
        {
            int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            if (UserId == 0)
            {
                return Unauthorized();
            }
            var updaetcomment=await _commentService.UpdateComment(UserId,commentDto);
            return Ok(updaetcomment);
        }
        [Authorize(Policy = "UserRole")]
        [HttpDelete("Product/Comment/Delete")]
        public async Task<IActionResult> DeleteComment([FromBody] DeleteComment deleteDto)
        {
            int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            if (UserId == 0)
            {
                return Unauthorized();
            }
            var comment =await _commentService.GetCommentById(deleteDto.CommentId,UserId,deleteDto.ProductId);
            if (comment == null)
            {
                return NotFound("کامنتی یافت نشد");
            }
            await _commentService.DeleteComment(comment.Id);
            return Ok("کامنت شما با موفقیت حذف شد");
           
        }


    }

}
