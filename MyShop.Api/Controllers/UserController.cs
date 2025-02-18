using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyShop.Application.Dto;
using MyShop.Application.Dto.User;
using MyShop.Application.UserService;
using MyShop.Domain.Entites;
using MyShop.Infrastructure.Migrations;

namespace MyShop.Api.Controllers
{
    [Route("api/Admin")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServiceInterface _userService;
        public UserController(IUserServiceInterface userService)
        {
            _userService = userService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            await _userService.CreatUser(model);
            return Created();
        }

        [HttpGet("user/{Id:int}")]
        public async Task<IActionResult> GetUser([FromRoute] int Id)
        {
            var user=await _userService.GetUserById(Id);
            if (user == null)
            {
                return NotFound("کاربر مورد نظر یافت نشد");
            }
            return Ok(user);
        }
        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            
            var users=await _userService.GetUsers();
            if (!users.Any())
            {
                return NotFound("هیچ کاربری وجود ندارد");
            }
            return Ok(users);
        }
        [HttpPut("Update/{Id:int}")]
        public async Task<IActionResult> AdminUpdateUser([FromRoute] int Id, [FromBody] UpdateUserDto model)
        {
            var user= await _userService.GetUserById(Id);
            if (user == null)
            {
                return NotFound("کاربر مورد نظر یافت نشد");
            }
            if (model == null)
            {
                return BadRequest("فیلدهای ورودی صحیح نمی باشند");
            }
            await _userService.AdminUpdateUser(Id, model);
            return Ok("ویرایش با موفقیت انجام شد");

        }
       
    }
}
