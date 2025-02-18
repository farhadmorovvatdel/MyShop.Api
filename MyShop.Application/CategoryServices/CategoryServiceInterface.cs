using MyShop.Application.Dto;
using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.CategoryService
{
    public interface CategoryServiceInterface
    {
        Task<List<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int Id);

        Task<Result> UpdateCategoryAsync(int Id, CategoryDto categoryDto);

        Task<Result> DeleteCategoryAsync(int Id);
        Task<CategoryDto> CreateCategory(CategoryDto categoryDto);
    }
}
