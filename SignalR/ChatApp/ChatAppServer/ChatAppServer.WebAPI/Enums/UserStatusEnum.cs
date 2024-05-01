using Ardalis.SmartEnum;

namespace ChatAppServer.WebAPI.Enums;

public sealed class UserStatusEnum : SmartEnum<UserStatusEnum>
{
    public static readonly UserStatusEnum Online = new("online", 1);
    public static readonly UserStatusEnum Offline = new("offline", 2);

    public UserStatusEnum(string name, int value) : base(name, value)
    {
    }
}
