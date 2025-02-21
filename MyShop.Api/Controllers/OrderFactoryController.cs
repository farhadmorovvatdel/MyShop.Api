using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.JsonWebTokens;
using MyShop.Application.Dto.OrderDetail;
using MyShop.Application.OrderServices;
using System.Security.Claims;

namespace MyShop.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OrderFactoryController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IHttpContextAccessor _contextAccessor;
        public OrderFactoryController(IOrderService orderService, IHttpContextAccessor contextAccessor)
        {
            _orderService = orderService;
            _contextAccessor = contextAccessor;
        }

        [HttpPost("Order/Create")]
        [Authorize(Policy = "UserRole")]
        public async Task<IActionResult> CreateOrder([FromBody] ODetailDto oDetailDtos)
        {

            //int userId = Convert.ToInt32(User?.FindFirstValue(JwtRegisteredClaimNames.Sub) ?? "0");
            int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            if (oDetailDtos == null)
            {
                return BadRequest("لطفا فیلدهای لازم را وارد نمایید");

            }
            await _orderService.CreateOrder(oDetailDtos,UserId);

          
            return Ok("سفارش شما با موفقیت ایجاد شد");
        }
        [Authorize(Policy ="UserRole")]
        [HttpGet("Order/Detail")]
        public async Task<IActionResult> ShowCartDetail()
        {
            
            var user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            int userId = Convert.ToInt32(user);
            
            var UserOrderDetail = await _orderService.GetUserOrderDeatil(userId);
            return Ok(UserOrderDetail);
        }
        [Authorize(Policy = "UserRole")]
        [HttpDelete("Order/Delete")]
        public async Task<IActionResult> DeletOrder()
        {
            int UserId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            if (UserId == null)
            {
                return Unauthorized();
            }
            var Order=await _orderService.ExistOrderUser(UserId);
            if (Order == null)
            {
                return NotFound("سفارش فعال برای این کاربر وجود ندارد");
            }
            await _orderService.DeteletUserOrder(Order.Id,UserId);
            return Ok("سفارش شما با موفقیت حذف شد");
        }
    }
}
