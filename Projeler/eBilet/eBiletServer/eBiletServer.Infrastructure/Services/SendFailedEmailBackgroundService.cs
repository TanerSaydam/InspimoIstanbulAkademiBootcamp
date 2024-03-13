using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Repositories;
using FluentEmail.Core;
using FluentEmail.Core.Models;
using Microsoft.Extensions.Hosting;

namespace eBiletServer.Infrastructure.Services;
public sealed class SendFailedEmailBackgroundService(
    IOutboxSendEmailRepository outboxSendEmailRepository,
    IFluentEmail fluentEmail) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            OutboxSendEmail? email = 
                await outboxSendEmailRepository.GetNotCompletedEmailAsync(stoppingToken);

            if(email is not null)
            {
                if (email.TryCount >= 3) continue;
                try
                {
                    SendResponse sendResponse = await fluentEmail
                     .To(email.To)
                     .Subject(email.Subject)
                     .Body(email.Body, true)
                     .SendAsync(stoppingToken);

                    email.IsItCompleted = true;
                    await outboxSendEmailRepository.UpdateAsync(email, stoppingToken);

                }
                catch (Exception)
                {
                    email.TryCount += 1;
                    await outboxSendEmailRepository.UpdateAsync(email, stoppingToken);
                    await Task.Delay(2000);
                }
            }
        }
    }
}
