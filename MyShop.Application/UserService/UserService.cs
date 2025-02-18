using MyShop.Application.Dto;
using MyShop.Domain.Entites;
using MyShop.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShop.Application.Security;
using MyShop.Application.Dto.User;
using AutoMapper;

namespace MyShop.Application.UserService
{

    public class UserService : IUserServiceInterface
    {
        private readonly IUserInterface _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserInterface userInterface, IMapper mapper)
        {
            _userRepository = userInterface;
            _mapper = mapper;
        }


        public async Task AdminUpdateUser(int Id, UpdateUserDto userdto)
        {
            var user = await _userRepository.GetUserById(Id);
            user.Name = userdto.Name;
            user.PhoneNumber = userdto.PhoneNumber;
            user.Family = userdto.Family;
            userdto.Image = userdto.Image;
            user.IsActive = userdto.IsActive;
            await _userRepository.UpdateUser(Id, user);

        }


        public async Task CreatUser(UserDto user)
        {
            var User = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = PasswordHelper.EncodePasswordMd5(user.Password),
                PhoneNumber = user.PhoneNumber,
                Family = user.Family,
                RoleId = 2,
                IsActive = true
            };
            await _userRepository.CreateUser(User);

        }

        public async Task<ShowUserDto> GetUserById(int Id)
        {
            var user= await _userRepository.GetUserById(Id);
            return _mapper.Map<ShowUserDto>(user);
        }

        public async Task<List<ShowUserDto>> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            return _mapper.Map<List<ShowUserDto>>(users);

        }




    }
}
