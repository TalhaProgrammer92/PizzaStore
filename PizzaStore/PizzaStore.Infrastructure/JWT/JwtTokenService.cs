using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using PizzaStore.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore.Infrastructure.JWT
{
    public class JwtTokenService
    {
        //public string GenerateToken(User user, string secretKey, int expireMinutes = 60)
        //{
        //    var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
        //    var claims = new[] {
        //        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        //        new Claim(ClaimTypes.Name, user.Username),
        //        new Claim(ClaimTypes.Role, user.Role.ToString())
        //    };
        //    var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
        //    var token = new JwtSecurityToken(issuer: config["Jwt:Issuer"], audience: config["Jwt:Audience"], claims: claims, expires: DateTime.UtcNow.AddMinutes(30), signingCredentials: creds);
        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
    }
}
