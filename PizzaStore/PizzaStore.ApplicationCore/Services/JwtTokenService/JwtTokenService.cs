using Microsoft.IdentityModel.Tokens;
using PizzaStore.ApplicationCore.Interfaces.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PizzaStore.ApplicationCore.Services.JwtTokenService
{
    public class JwtTokenService : ITokenService
    {
        private readonly string _secretKey;
        private readonly int _expiryMinutes;

        public JwtTokenService()
        {
            // In a real-world app, use appsettings.json or environment variables.
            _secretKey = "SuperSecretKeyForPizzaStore123!"; // Must be at least 16 chars
            _expiryMinutes = 60;
        }

        public string GenerateToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }),
                Expires = DateTime.UtcNow.AddMinutes(_expiryMinutes),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public ClaimsPrincipal? ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_secretKey);

            try
            {
                var parameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero
                };

                var principal = tokenHandler.ValidateToken(token, parameters, out _);
                return principal;
            }
            catch
            {
                return null;
            }
        }
    }
}
