using MyShop.Application.Dto;
using MyShop.Application.Dto.User;
using MyShop.Application.Vm.User;
using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.UserService
{
    public interface IUserServiceInterface
    {
        Task CreatUser(UserDto user);
        Task<List<ShowUserDto>> GetUsers();
        Task AdminUpdateUser(int Id,UpdateUserDto user);
        Task<ShowUserDto> GetUserById(int Id);
        Task AdminDeleteUser (int Id);
        Task<User> LoginUser(LoginUserVm loginUserVm);
    }
}
