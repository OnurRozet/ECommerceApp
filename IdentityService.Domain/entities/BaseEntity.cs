using System.Runtime.InteropServices.JavaScript;

namespace IdentityService.Domain.entities;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedDate { get; set; }
    public int CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public int? DeletedBy { get; set; }
}