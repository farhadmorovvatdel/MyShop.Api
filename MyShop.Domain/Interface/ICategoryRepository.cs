using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Interface
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int Id);   
        
        Task<Category> CreateAsyncCategory(Category category);

        Task UpdateAsyncCategory(int Id,Category category);

        Task DeleteAsyncCategory(int Id);
       
    }
}
