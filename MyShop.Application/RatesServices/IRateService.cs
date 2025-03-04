using MyShop.Application.Dto.Rate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.RatesServices
{
    public interface IRateService
    {
        Task AddRate(int UserId,CreateRateDto RateDto);
        Task<ShowRateDto> GetRateDto(int UserId,GetRateDto GetRateDto);
        Task<bool> GetUserRate(int UserId,int ProductId);
        Task<double> GetRateAverage(int ProductId);
    }
}
