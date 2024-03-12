using eBiletServer.Domain.Abstractions;

namespace eBiletServer.Domain.Entities;

public sealed class Bilet : Entity
{    
    public Guid RotaId { get; set; }
    public Rota? Rota { get; set; }
    public Guid AppUserId {  get; set; }
    public AppUser? AppUser { get; set; }
}
