namespace ProductManagementTask.Domain.Abstractions;
public abstract class Entity
{
    public int Id { get; set; }
    public bool IsActive { get; set; } = true;
}
