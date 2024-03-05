namespace PersonelServer.DTOs;

public sealed record CreateUserRoleDto(
    string UserId,
    Guid RoleId);
