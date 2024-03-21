using eBiletServer.Domain.Abstractions;

namespace eBiletServer.Domain.Entities;
public sealed class Bus : Entity
{
    public string Brand { get; set; } = string.Empty;
    public int Model { get; set; }
    public string Plate { get; set; } = string.Empty;
}

