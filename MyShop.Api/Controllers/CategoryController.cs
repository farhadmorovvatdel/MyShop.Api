using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.OpenApi.Writers;
using MyShop.Application.CategoryService;
using MyShop.Application.Dto;
using System.Net.NetworkInformation;

namespace MyShop.Api.Controllers
{
    [Route("api/Admin/")]
    [ApiController]
    //[Authorize(Policy = "AdminRole")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryServiceInterface _categoryService;

        public CategoryController(CategoryServiceInterface categoryService)
        {
            _categoryService = categoryService;
        }
        /// <summary>
        /// لیست دسته بندی ها
        /// </summary>
        /// <returns></returns>
        [HttpGet("Category")]
        public async Task<IActionResult> ShowCategories()
        {
            var cats = await _categoryService.GetCategoriesAsync();
            return Ok(cats);
        }
        /// <summary>
        /// گرفتن دسته بندی با ایدی
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("Category/{Id:int}")]
        public async Task<IActionResult> GetCategory([FromRoute] int Id)
        {
            var cat = await _categoryService.GetCategoryByIdAsync(Id);
            if (cat == null)
            {
                return NotFound("دسته بندی مورد نظر یافت نشد");
            }
            return Ok(cat);
        }
        /// <summary>
        /// ایجاد دسته بندی
        /// </summary>
        /// <param name="categoryDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryDto)
        {
            var cat = await _categoryService.CreateCategory(categoryDto);
            return Ok(cat);
        }/// <summary>
        /// حذف دسته بندی 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("Category/delete/{Id:int}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int Id)
        {
            var cat = await _categoryService.GetCategoryByIdAsync(Id);
            if (cat == null) return NotFound("دسته بندی مورد نظر یافت نشد");
            await _categoryService.DeleteCategoryAsync(Id);
            return NoContent();
        }/// <summary>
        /// ویرایش دسته بندی
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="categoryDto"></param>
        /// <returns></returns>
        [HttpPut("Category/update/{Id:int}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int Id, [FromBody] CategoryDto categoryDto)
        {
            var cat = await _categoryService.GetCategoryByIdAsync(Id);
            if (cat == null) return NotFound("دسته بندی مورد نظر یافت نشد");
            await _categoryService.UpdateCategoryAsync(Id, categoryDto);
            return NoContent();
        }
    }
}
