using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Interface
{
    public interface IDiscountRepository
    {
        Task CreateDiscount(DiscountCode discountCode);
        Task<List<DiscountCode>> GetAll();
        Task<DiscountCode> GetDiscountById (int id);
        Task<DiscountCode> UpdateDiscount(int Id, DiscountCode Dto);
        Task DeleteDiscount(int Id);
       
    }
}
