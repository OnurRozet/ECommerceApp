using IdentityService.Application.Base;
using IdentityService.Application.DTOs;
using IdentityService.Domain.entities;

namespace IdentityService.Application.Interfaces;

public interface IUserAppService
{
    Task<ServiceResult<CreateOrEditResponse>> RegisterAsync(UserRegisterDto dto);
    Task<ServiceResult<JwtResponse>> LoginAsync(UserLoginDto dto);
}