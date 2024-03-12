using eBiletServer.Domain.Abstractions;

namespace eBiletServer.Domain.Entities;
public sealed class Otobus : Entity
{
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Plate { get; set; } = string.Empty;
    public int YolcuKapasitesi { get; set; }
}

