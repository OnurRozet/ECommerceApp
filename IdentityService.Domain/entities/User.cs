using IdentityService.Application.Enums;

namespace IdentityService.Domain.entities;

public class User :BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordHash { get; set; }
    public RoleEnum Role { get; set; }
}