using AutoMapper;
using MyShop.Application.CategoryService;
using MyShop.Application.Dto;
using MyShop.Domain.Entites;
using MyShop.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.CategoryServices
{

    public class Categoryservice : CategoryServiceInterface
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        public Categoryservice(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> CreateCategory(CategoryDto categoryDto)
        {
            var cat = new Category()
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description,
            };
            await _categoryRepository.CreateAsyncCategory(cat);
            return _mapper.Map<CategoryDto>(cat);

        }

        public async Task<Result> DeleteCategoryAsync(int Id)
        {
            var cat=await _categoryRepository.GetCategoryByIdAsync(Id);
            if (cat == null)
            {
                return Result.Failure("دسته بندی مورد نظر یافت نشد");
            }
            await _categoryRepository.DeleteAsyncCategory(Id);
            return Result.Success();
        }

        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            var res =await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<List<CategoryDto>>(res);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int Id)
        {
            var cat=await _categoryRepository.GetCategoryByIdAsync(Id);
            
            return _mapper.Map<CategoryDto>(cat);
        }

        public async Task<Result> UpdateCategoryAsync(int Id,CategoryDto categoryDto)
        {
            var cat=await _categoryRepository.GetCategoryByIdAsync(Id);
            if (cat==null)
            {
                return Result.Failure("دسته بندی مورد نظر یافت نشد");
            }
            cat.Name = categoryDto.Name;
            cat.Description = categoryDto.Description;
            await _categoryRepository.UpdateAsyncCategory(Id,cat);
            return Result.Success();
        }
    }
}
