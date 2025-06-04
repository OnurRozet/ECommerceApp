using DevOne.Security.Cryptography.BCrypt;
using IdentityService.Application.Base;
using IdentityService.Application.DTOs;
using IdentityService.Application.Interfaces;
using IdentityService.Domain.entities;

namespace IdentityService.Infrastructure.Services;

public class UserAppService(IUserRepository _userRepository, IJwtService _jwtService) : IUserAppService
{
    public async Task<ServiceResult<CreateOrEditResponse>> RegisterAsync(UserRegisterDto dto)
    {
        var existUser = await _userRepository.GetByEmailAsync(dto.Email);
        if (existUser is not null) return ServiceResult<CreateOrEditResponse>.Error(new CreateOrEditResponse()
        {
            Message = "User already exists"
        }.ToString()!);

        var user = new User()
        {
            Email = dto.Email,
            Name = dto.Name,
            Surname = dto.Surname,
            Role = dto.Role,
            UserName = dto.UserName,
            Password = dto.Password,
            PasswordHash = BCryptHelper.HashPassword(dto.Password, BCryptHelper.GenerateSalt())
        };
        
        await _userRepository.AddAsync(user);
        return ServiceResult<CreateOrEditResponse>.Success(new CreateOrEditResponse()
        {
            Id = user.Id,
        });
    }

    public async Task<ServiceResult<JwtResponse>> LoginAsync(UserLoginDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);
        if (user == null || !BCryptHelper.CheckPassword(dto.Password, user.PasswordHash))
        {
            ServiceResult<JwtResponse>.Error("Invalid username or password");
        }
        
        var token = await _jwtService.GenerateToken(user);
        
        return ServiceResult<JwtResponse>.Success(new JwtResponse()
        {
            UserId = user.Id,
            UserName = user?.UserName,
            Token = token
        });
    }
}