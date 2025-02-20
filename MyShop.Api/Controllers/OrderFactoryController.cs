using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public OrderFactoryController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [HttpPost("Order/Create")]
        [Authorize(Policy = "UserRole")]
        public async Task<IActionResult> CreateOrder([FromBody] ODetailDto oDetailDtos)
        {
           
            int userId = Convert.ToInt32(User?.FindFirstValue(JwtRegisteredClaimNames.Sub) ?? "0");


            if (oDetailDtos == null)
            {
                return BadRequest("لطفا فیلدهای لازم را وارد نمایید");

            }
            await _orderService.CreateOrder(oDetailDtos,1);

          
            return Ok("سفارش شما با موفقیت ایجاد شد"); 
        }

        //public async Task<IActionResult> ShowCartDetail()
        //{
        //    return Ok();
        //}
    }
}
