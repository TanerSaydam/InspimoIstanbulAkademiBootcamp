using eBiletServer.Domain.Abstractions;

namespace eBiletServer.Domain.Entities;

public sealed class Rota : Entity
{
    public string Kalkis { get; set; } = string.Empty;
    public string Varis {  get; set; } = string.Empty;
    public DateTime KalkisTarihi { get; set; }

    public Guid OtobusId { get; set; }
    public Otobus? Otobus { get; set; }
}
