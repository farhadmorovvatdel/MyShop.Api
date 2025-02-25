using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyShop.Application.Dto;
using MyShop.Application.Dto.User;
using MyShop.Application.JwtService;
using MyShop.Application.UserService;
using MyShop.Application.Vm.User;
using MyShop.Domain.Entites;
using MyShop.Infrastructure.Migrations;
using System.Security.Claims;

namespace MyShop.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServiceInterface _userService;
        private readonly IJwtService _jwtService;
        public UserController(IUserServiceInterface userService,IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;   
        }
        [Authorize(Policy = "AdminRole")]
        [HttpPost("Admin/create")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            await _userService.CreatUser(model);
            return Created();
        }
        [Authorize(Policy = "AdminRole")]
        [HttpGet("Admin/user/{Id:int}")]
        public async Task<IActionResult> GetUser([FromRoute] int Id)
        {
            var user=await _userService.GetUserById(Id);
            if (user == null)
            {
                return NotFound("کاربر مورد نظر یافت نشد");
            }
            return Ok(user);
        }
        [Authorize(Policy ="AdminRole")]
        [HttpGet("Admin/users")]
        public async Task<IActionResult> GetAllUsers()
        {
            
            var users=await _userService.GetUsers();
            if (!users.Any())
            {
                return NotFound("هیچ کاربری وجود ندارد");
            }
            return Ok(users);
        }
        [Authorize(Policy = "AdminRole")]
        [HttpPut("Admin/Update/{Id:int}")]
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
        [Authorize(Policy = "AdminRole")]
        [HttpDelete("Admin/Delete/{Id:int}")]
        public async Task<IActionResult> AdminDeleteUser([FromRoute] int Id)
        {
            var user = await _userService.GetUserById(Id);
            if (user == null)
            {
                return NotFound("کاربر مورد نظر یافت نشد");
            }
            await _userService.AdminDeleteUser(Id);
            return Ok("کاربر مورد نظر با موفقیت حذف شد");

        }
        [HttpPost("User/Login")]
        public async Task<IActionResult> UserLogin([FromBody] LoginUserVm uservm)
        {
            if (uservm == null)
            {
                return BadRequest("فیلدهای ورودی را وارد نمایید");
            }
            var user = await _userService.LoginUser(uservm);
            if (user == null)
            {
                return NotFound("کاربری با مشخصات فوق یافت نشد");
            }
            var rolname=user.Role.Name;
            var token= _jwtService.GenerateToken(user.Id, user.Email,rolname);
            return Ok(new { Token = token });
        }
        [Authorize(Policy="UserRole")]
        [HttpGet("User/Profile")]
        public async Task<IActionResult> UserProfile()
        {
            var userId = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            if (userId == 0)
            {
                return Unauthorized();
            }
            var user=await _userService.GetUserById(userId);
            return Ok(user);

        }
       
    }
}
