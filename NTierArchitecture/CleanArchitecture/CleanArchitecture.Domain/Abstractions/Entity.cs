namespace CleanArchitecture.Domain.Abstractions;
public abstract class Entity
{
    protected Entity(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
    public Guid CreatedUserId { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid? UpdatedUserId { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
