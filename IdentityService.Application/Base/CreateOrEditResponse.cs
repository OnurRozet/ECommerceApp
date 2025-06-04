namespace IdentityService.Application.Base;

public class CreateOrEditResponse
{
    public int? Id { get; set; }
    public string Guid { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}