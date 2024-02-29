namespace PersonelServer.Models;

public sealed class Profession
{
    public Profession()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}