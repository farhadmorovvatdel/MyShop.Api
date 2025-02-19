using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyShop.Application.Dto;
using MyShop.Application.RoleServices;
using MyShop.Infrastructure.Migrations;

namespace MyShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy ="AdminRole")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServiceInterface _roleService;
        public RoleController(IRoleServiceInterface roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<IActionResult> Getroles()
        {
            var roles = await _roleService.GetRoles();
            if (!roles.Any())
            {
                return NotFound("هیچ نقشی وجود ندارد");
            }
            return Ok(roles);
        }
        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetRole([FromRoute] int Id)
        {
            var role= await _roleService.GetRoleById(Id);
            if (role==null)
            {
                return NotFound("نقش مورد نظر یافت نشد");
            }
            return Ok(role);
        }
        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var role = await _roleService.GetRoleById(Id);
            if (role == null)
            {
                return NotFound("نقش مورد نظر یافت نشد");
            }
            await _roleService.DeleteRole(Id);
            return Ok("نقش مورد نظر شما با موفقیت حدف شد");

        }
        [HttpPost("create")]
        public async Task<IActionResult> Createrole([FromBody ] RoleDto model)
        {
            if (model == null|| string.IsNullOrEmpty(model.Name))
            {
                return BadRequest("نام نقش نمیتواند خالی باشد");
            }
            await _roleService.CreateRole(model);
            return Created();
        }
        [HttpPut("update/{Id:int}")]
        public async Task<IActionResult> UpdateRole([FromRoute ] int Id, [FromBody] RoleDto model)
        {
            var role=await _roleService.GetRoleById(Id);
            if (role==null)
            {
                return NotFound("نقش مورد نظر یافت نشد");
            }
            if (model==null|| string.IsNullOrEmpty(model.Name))
            {
                return BadRequest("نام نقش نیمتواند خالی باشد");
            }
            await _roleService.UpdateRole(Id, model);
            return Ok("ویرایش با موفقیت انجام شد");
        }
        [HttpDelete("delete/{Id:int}")]
        public async Task<IActionResult> DeleteRole([FromRoute] int Id)
        {
            var role = await _roleService.GetRoleById(Id);
            if (role == null)
            {
                return NotFound("نقش مورد نظر یافت نشد");
            }
            await _roleService.DeleteRole(Id);
            return Ok("حذف نقش با موفقیت انجام شد");
        }
    }
}
