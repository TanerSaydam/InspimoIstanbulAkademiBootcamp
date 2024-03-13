using eBiletServer.Domain.Entities;

namespace eBiletServer.Domain.Repositories;
public interface IOutboxSendEmailRepository
{
    Task AddAsync(OutboxSendEmail outboxSendEmail, CancellationToken cancellationToken = default);
    Task UpdateAsync(OutboxSendEmail outboxSendEmail, CancellationToken cancellationToken = default);
    Task<OutboxSendEmail?> GetNotCompletedEmailAsync(CancellationToken cancellationToken = default);
}
