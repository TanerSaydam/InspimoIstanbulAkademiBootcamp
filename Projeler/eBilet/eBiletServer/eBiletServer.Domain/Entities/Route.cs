using eBiletServer.Domain.Abstractions;

namespace eBiletServer.Domain.Entities;

public sealed class Route : Entity
{
    public string From { get; set; } = string.Empty;
    public string To {  get; set; } = string.Empty;
    public DateTime Date { get; set; }

    public Guid OtobusId { get; set; }
    public Bus? Buses { get; set; }
}
