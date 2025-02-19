using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyShop.Domain.Jwt;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.JwtService
{
    public class jwtservice : IJwtService
    {
        private readonly JwtSetting _jwtsetting;
        public jwtservice(IOptions<JwtSetting> Jwtsettings)
        {
            _jwtsetting = Jwtsettings.Value;
        }
        public string GenerateToken(int UserId, string Email,string Role)
        {

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub,UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, Email),
                new Claim(ClaimTypes.Role,Role),
                
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtsetting.Key));
            var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken
                (
                issuer: _jwtsetting.Issuer,
                audience: _jwtsetting.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtsetting.ExpiryMinutes),
                signingCredentials: credentials
                );
                return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
