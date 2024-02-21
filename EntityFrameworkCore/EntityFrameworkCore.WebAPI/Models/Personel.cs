namespace EntityFrameworkCore.WebAPI.Models;

public class Personel
{
    public Personel()
    {
        Id = Guid.NewGuid();
    }
   
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => string.Join(" ", FirstName, LastName);
    public string Email { get; set; } = string.Empty;
}
