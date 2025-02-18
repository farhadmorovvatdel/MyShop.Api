using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Interface
{
    public interface IRoleInterface
    {
        Task CreateRole(Role role);
        Task<List<Role>> GetAllRoles();
        Task<Role> GetRoleById(int id);

        Task DeleteRole(int Id);

        Task UpdateRole(int Id, Role role);
    }
}
