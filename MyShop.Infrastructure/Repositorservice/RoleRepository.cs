using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Entites;
using MyShop.Domain.Interface;
using MyShop.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositorservice
{
    public class RoleRepository : IRoleInterface
    {
        private readonly MyShopContext _context;
        public RoleRepository(MyShopContext context)
        {
            _context = context;
        }
        public async Task CreateRole(Role role)
        {
            _context.roles.Add(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRole(int Id)
        {
            var role = await GetRoleById(Id);
            _context.roles.Remove(role);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await _context.roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await _context.roles.FindAsync(id);

        }

        public async Task UpdateRole(int Id, Role role)
        {
            var Role = await GetRoleById(Id);
            _context.roles.Update(role);
            await _context.SaveChangesAsync();
        }
    }
}
