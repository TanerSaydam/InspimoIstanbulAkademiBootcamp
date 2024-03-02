namespace PersonelServer.Models;

public sealed class User
{
    public User()
    {
        Id = Ulid.NewUlid().ToString();
    }
    public string Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ", FirstName, LastName);
    public string Email { get; set; } = string.Empty;
    public byte[] PasswordSalt { get; set; } = new byte[128];
    public byte[] PasswordHash { get; set; } = new byte[64];
}
