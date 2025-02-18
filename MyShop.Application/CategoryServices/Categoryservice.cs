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
    }
}
