namespace PersonelServer.Models;

public sealed class UserRole
{
    public string UserId { get; set; } = string.Empty;
    public Guid RoleId { get; set; }
    public Role? Role { get; set; }
}