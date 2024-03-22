using eBiletServer.Domain.Abstractions;

namespace eBiletServer.Domain.Entities;

public sealed class Route : Entity
{
    public string From { get; set; } = string.Empty;
    public string To {  get; set; } = string.Empty;
    public DateTime Date { get; set; }

    public Guid BusId { get; set; }
    public Bus? Bus { get; set; }
}
