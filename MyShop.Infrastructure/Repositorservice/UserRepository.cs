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

        public async Task UpdateUser(int Id, User user)
        {
            var User = await GetUserById(Id);
            _context.users.Update(User);
            await _context.SaveChangesAsync();
        }
    }
}
