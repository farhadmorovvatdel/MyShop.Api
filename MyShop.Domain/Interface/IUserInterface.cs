using MyShop.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Domain.Interface
{
    public interface IUserInterface
    {
        Task<List<User>> GetUsers();
        Task CreateUser(User user);
        Task<User> GetUserById (int id);
        
        Task UpdateUser(int Id,User user);

        Task DeleteUser(int Id);
        Task<User> LoginUser(User user);
       
    }
}
