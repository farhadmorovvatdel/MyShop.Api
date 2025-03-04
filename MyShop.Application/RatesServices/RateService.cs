using AutoMapper;
using MyShop.Application.Dto.Rate;
using MyShop.Domain.Entites;
using MyShop.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.RatesServices
{
    public class RateService : IRateService
    {
        private readonly IRateRepository _rateRepository;
        private readonly IMapper _mapper;
        public RateService(IRateRepository rateRepository,IMapper mapper)
        {
            _rateRepository = rateRepository;
            _mapper = mapper;
        }
        public async Task AddRate(int UserId,CreateRateDto RateDto)
        {
            var NewRate = new Rate
            {
                UserId = UserId,
                ProductId = RateDto.ProductId,
                RateNumber = RateDto.Ratenumber
            };
            await _rateRepository.AddRate(NewRate);
        }

        public async Task<double> GetRateAverage(int ProductId)
        {
            return await _rateRepository.ShowAverageRate(ProductId);
        }

        public async Task<ShowRateDto> GetRateDto(int UserId,GetRateDto GetRateDto)
        {
           var rate=await _rateRepository.GetRate(UserId,GetRateDto.ProductId);
            return _mapper.Map<ShowRateDto>(rate);
           
        }

        public async Task<bool> GetUserRate(int UserId, int ProductId)
        {
            return await _rateRepository.CheckUserRate(UserId, ProductId);
        }
    }
}
