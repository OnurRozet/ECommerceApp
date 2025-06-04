using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IdentityService.Application.Interfaces;
using IdentityService.Domain.entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace IdentityService.Infrastructure.Services;

public class JwtService(IConfiguration _configuration) : IJwtService
{
    public Task<string> GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim("UserId", user.Id.ToString()),
            new Claim("Name", user.Name),
            new Claim("Email", user.Email),
            new Claim("Role", user.Role.ToString()),
            new Claim("UserName", user.UserName)
        };
        
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JwtConfiguration:Key"]!));
        var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(7),
            signingCredentials: creds
        );
        
        return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));

    }
}