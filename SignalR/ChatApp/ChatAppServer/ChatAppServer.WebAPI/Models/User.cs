using ChatAppServer.WebAPI.Enums;

namespace ChatAppServer.WebAPI.Models;

public sealed class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Password {  get; set; } = string.Empty;
    public string AvatarUrl {  get; set; } = string.Empty;
    public UserStatusEnum Status { get; set; } = UserStatusEnum.Offline;
}
