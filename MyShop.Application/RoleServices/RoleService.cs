using AutoMapper;
using MyShop.Application.Dto;
using MyShop.Domain.Entites;
using MyShop.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.RoleServices
{
    public class RoleService : IRoleServiceInterface
    {
        private readonly IRoleInterface _RoleRepository;
        private readonly IMapper _mapper;
        public RoleService(IRoleInterface RoleRepository, IMapper mapper)
        {
            _RoleRepository = RoleRepository;
            _mapper=mapper;
        }
        public async Task CreateRole(RoleDto role)
        {
            var Role = new Role
            {
                Name = role.Name,

            };
            await _RoleRepository.CreateRole(Role);
        }

        public async Task DeleteRole(int id)
        {
           await _RoleRepository.DeleteRole(id);

        }

        public async Task<List<RoleDto>> GetRoles()
        {
            List<Role> roles = await _RoleRepository.GetAllRoles();
            if (!roles.Any())
            {
                return new List<RoleDto>();
            }
            return _mapper.Map<List<RoleDto>>(roles);
        }

        public async Task<RoleDto> GetRoleById(int id)
        {
            var role=await _RoleRepository.GetRoleById(id);
            return _mapper.Map<RoleDto>(role);
        }

        public async Task UpdateRole(int Id, RoleDto role)
        {
            var Role=await _RoleRepository.GetRoleById(Id);
            Role.Name=role.Name;
            await _RoleRepository.UpdateRole(Id,Role);
        }
    }
}
