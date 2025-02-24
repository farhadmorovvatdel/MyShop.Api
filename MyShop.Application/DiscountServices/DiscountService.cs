using AutoMapper;
using MyShop.Application.Dto.DiscountCode;
using MyShop.Domain.Entites;
using MyShop.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _DiscountRepository;
        private readonly IMapper _mapper;
        public DiscountService(IDiscountRepository discountRepository, IMapper mapper)
        {
            _DiscountRepository = discountRepository;
            _mapper = mapper;
        }
        public async Task CreateDiscount(CreateDiscountDto requestDto)
        {
            var discount = new DiscountCode
            {
                Code = requestDto.Code,
                Amount = requestDto.Amount,
                StartDate = requestDto.StartDate,
                EndDate = requestDto.EndDate,
            };
            if (discount.IsValid())
            {
                await _DiscountRepository.CreateDiscount(discount);
            }
            else
            {
                throw new InvalidOperationException("کد تخفیف صحیح نمی باشد");
            }

        }

        public async Task DeleteDiscount(int Id)
        {
           await _DiscountRepository.DeleteDiscount(Id);
        }

        public async Task<List<ShowDiscount>> GetAll()
        {
            var discounts = await _DiscountRepository.GetAll();
            return _mapper.Map<List<ShowDiscount>>(discounts);

        }

        public async Task<ShowDiscount> GetDiscount(int Id)
        {
            var disocunt = await _DiscountRepository.GetDiscountById(Id);
            return _mapper.Map<ShowDiscount>(disocunt);
        }

        public async Task<ShowDiscount> UpdateDsicount(int Id, UpdateDiscountCode dto)
        {
            var DiscountCode = await _DiscountRepository.GetDiscountById(Id);

            DiscountCode.Amount = dto.Amount;
            DiscountCode.StartDate = dto.StartDate;
            DiscountCode.EndDate = dto.EndDate;
            DiscountCode.Code = dto.Code;
            if (DiscountCode.IsValid())
            {
               var discount= await _DiscountRepository.UpdateDiscount(Id,DiscountCode);
                return _mapper.Map<ShowDiscount>(discount);
            }

            else
            {
                throw new InvalidOperationException("فرمت ورودی تاریخ صحیح نمیباشد");
            }
           
        }
    }
}
