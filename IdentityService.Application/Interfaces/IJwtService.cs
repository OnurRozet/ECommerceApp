using IdentityService.Domain.entities;

namespace IdentityService.Application.Interfaces;

public interface IJwtService
{
    Task<string> GenerateToken(User user);
}