using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Repositories;
using FluentEmail.Core;
using FluentEmail.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace eBiletServer.Infrastructure.Services;
public sealed class SendFailedEmailBackgroundService(
    IServiceScopeFactory serviceScopeFactory
    ) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            Console.Out.WriteLine("Background service is working...");
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var fluentEmail = scope.ServiceProvider.GetRequiredService<IFluentEmail>();
                var outboxSendEmailRepository = scope.ServiceProvider.GetRequiredService<IOutboxSendEmailRepository>();

                OutboxSendEmail? email =
                    await outboxSendEmailRepository.GetNotCompletedEmailAsync(stoppingToken);               

                if (email is not null)
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
                    }
                }
            }
            await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
        }
    }
}
