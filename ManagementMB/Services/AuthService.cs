using ManagementMB.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using ManagementMB.Infrastructure;
using ManagementMB.Contracts;
using ManagementMB.Models;

namespace ManagementMB.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;
        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public  Task<TokenInfo> Login(string username, string password)
        {
            var user =  _context.Workers.SingleOrDefault(x => x.UserName == username && x.Password == password);

            return  GeneratedJWT(user);
        }

        public  Task<TokenInfo> RefreshToken(string refreshToken)
        {
            var user =  _context.Users.SingleOrDefault(x => x.RefreshToken == refreshToken);

            return  GeneratedJWT(user);
        }

        async Task<TokenInfo> GeneratedJWT(User user)
        {
            if (user is null)
                throw new ArgumentException("Invalid username or password.");

            if (user.IsBlocked)
                throw new ArgumentException("User does not have access to login.");

            var userRoles = new string[] { user.Role };

            var claims = new List<Claim> {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName)
            };

            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);
            var refreshToken = Guid.NewGuid().ToString();

            user.RefreshToken = refreshToken;
            _context.Update(user);
            await _context.SaveChangesAsync();

            return new TokenInfo { AccessToken = accessToken, RefreshToken = refreshToken };
        }
    }
}

