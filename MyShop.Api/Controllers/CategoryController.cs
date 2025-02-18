using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using MyShop.Application.CategoryService;
using System.Net.NetworkInformation;

namespace MyShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryServiceInterface _categoryService;

        public CategoryController(CategoryServiceInterface categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> ShowCategories()
        {
            var cats = await _categoryService.GetCategoriesAsync();
            return Ok(cats);
        }
        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetCategory([FromRoute] int Id)
        {
            var cat =await _categoryService.GetCategoryByIdAsync(Id);
            if (cat == null)
            {
                return NotFound("دسته بندی مورد نظر یافت نشد");
            }
            return Ok(cat);
        }
    }
}
