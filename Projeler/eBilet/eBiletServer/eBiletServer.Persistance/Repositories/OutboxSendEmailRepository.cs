using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Repositories;
using eBiletServer.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace eBiletServer.Persistance.Repositories;
internal sealed class OutboxSendEmailRepository(
    ApplicationDbContext context) : IOutboxSendEmailRepository
{
    public async Task AddAsync(OutboxSendEmail outboxSendEmail, CancellationToken cancellationToken = default)
    {
        await context.AddAsync(outboxSendEmail, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<OutboxSendEmail?> GetNotCompletedEmailAsync(CancellationToken cancellationToken = default)
    {
        return await context.OutboxSendEmails.Where(p => !p.IsItCompleted && p.TryCount < 3).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task UpdateAsync(OutboxSendEmail outboxSendEmail, CancellationToken cancellationToken = default)
    {
        context.Update(outboxSendEmail);
        await context.SaveChangesAsync(cancellationToken);
    }
}
