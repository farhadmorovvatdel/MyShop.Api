using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using MyShop.Application.DiscountServices;
using MyShop.Application.Dto.DiscountCode;
using System.Diagnostics.Contracts;

namespace MyShop.Api.Controllers
{
    [Route("api/Discount/Admin")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        /// <summary>
        /// ایجاد کد تخفیف
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto dto)
        {

            if (dto == null)
            {
                return BadRequest("لطفا فیلدهای ورودی را وارد نمایید");
            }
            try
            {
                await _discountService.CreateDiscount(dto);
                return Ok("کد تخفیف ایجاد شد");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// مشاهده کد تخفیف
        /// </summary>
        /// <returns></returns>
        [HttpGet("ShowDiscount")]
        public async Task<IActionResult> ShowDiscount()
        {
            var dsicounts = await _discountService.GetAll();
            if(!dsicounts.Any())
            {
                return NotFound("کد تخفیفی وجود ندارد");
            }
            return Ok(dsicounts);
        }
        /// <summary>
        /// گرفتن کد تخفف با ایدی
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("detail/{Id:int}")]
        public async Task<IActionResult> GetDiscount(int Id)
        {
           var discount=await _discountService.GetDiscount(Id);
            if(discount == null)
            {
                return NotFound("کد تخفیف مورد نظر یافت نشد");
            }
            return Ok(discount);
        }
        /// <summary>
        /// ویرایش کد تخفیف
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>

        [HttpPut("update/{Id:int}")]
        public async Task<IActionResult> UpdateDisocunt([FromRoute] int Id, [FromBody] UpdateDiscountCode dto)
        {
            if(dto == null)
            {
                return BadRequest("لطفا فیلدهای ورودی را وارد نمایید");
            }
            var code=await _discountService.GetDiscount(Id);
            if(code == null)
            {
                return NotFound("کد تخفیف مورد نظر یافت نشد");
            }
            try
            {
               var update= await _discountService.UpdateDsicount(Id, dto);
                return Ok(update);
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        /// <summary>
        /// حذف کد تعفیف
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("Delete/{Id:int}")]
        public async Task<IActionResult> DeleteDiscount([FromRoute] int Id)
        {
            var discount=await _discountService.GetDiscount(Id);
            if (discount == null)
            {
                return NotFound("کد تخفیفی یافت نشد");
            }
            await _discountService.DeleteDiscount(Id);
            return Ok("کد تخفیف مورد نظر حذف شد");    
            
        }
    }
}
