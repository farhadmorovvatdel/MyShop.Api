using MyShop.Application.Dto.DiscountCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.DiscountServices
{
    public interface IDiscountService
    {
        Task CreateDiscount(CreateDiscountDto requestDto);
        Task<List<ShowDiscount>> GetAll();
        Task<ShowDiscount> GetDiscount(int Id);
        Task<ShowDiscount> UpdateDsicount(int Id, UpdateDiscountCode dto);
        Task DeleteDiscount(int Id);
    }
}
