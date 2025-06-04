namespace IdentityService.Application.Base;

public class JwtResponse
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Token { get; set; }
}