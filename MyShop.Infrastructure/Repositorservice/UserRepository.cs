using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Entites;
using MyShop.Domain.Interface;
using MyShop.Infrastructure.Context;
using MyShop.Infrastructure.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyShop.Infrastructure.Repositorservice
{
    public class UserRepository : IUserInterface
    {
        private readonly MyShopContext _context;
        public UserRepository(MyShopContext context)
        {
            _context = context;
        }
        public async Task CreateUser(User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(int Id)
        {
            var user = await GetUserById(Id);
            _context.users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserById(int Id)
        {
            return await _context.users.FindAsync(Id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.users.ToListAsync();
        }

        public Task<User> LoginUser(User User)
        {
            var pass = PasswordHelper.EncodePasswordMd5(User.Password);
            var user =_context.users.Include(u=>u.Role).SingleOrDefault(u=>u.Email.ToLower() ==User.Email.ToLower() && u.Password==pass && u.IsActive==true);
            if (user != null)
            {
                return Task.FromResult(user);
            }
            return Task.FromResult<User>(null);
        }

        public async Task UpdateUser(int Id, User user)
        {
            var User = await GetUserById(Id);
            _context.users.Update(User);
            await _context.SaveChangesAsync();
        }
    }
}
