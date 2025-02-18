using MyShop.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.RoleServices
{
    public interface IRoleServiceInterface
    {
        Task CreateRole(RoleDto role);

        Task<List<RoleDto>> GetRoles();

        Task<RoleDto> GetRoleById(int id);

        Task DeleteRole(int id);
        Task UpdateRole(int Id, RoleDto role);
    }
}
