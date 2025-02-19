using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.JwtService
{
    public interface IJwtService
    {
        string GenerateToken(int UserId, string Email,string Role);
    }
}
