using eBiletServer.Domain.Abstractions;

namespace eBiletServer.Domain.Entities;
public sealed class OutboxSendEmail : Entity
{
    public string To { get; set; } =string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public bool IsItCompleted { get; set; } = false;
    public int TryCount { get; set; } = 0;
}
