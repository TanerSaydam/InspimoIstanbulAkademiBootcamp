using eBiletServer.Domain.Entities;
using eBiletServer.Domain.Repositories;
using eBiletServer.Prestantion.Abstractions;
using FluentEmail.Core;
using FluentEmail.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace eBiletServer.Prestantion.Controllers;
public sealed class TestController : ApiController
{
    private readonly IFluentEmail _fluentEmail;
    private readonly IOutboxSendEmailRepository _outboxSendEmailRepository;
    public TestController(IMediator mediator, IFluentEmail fluentEmail, IOutboxSendEmailRepository outboxSendEmailRepository) : base(mediator)
    {
        _fluentEmail = fluentEmail;
        _outboxSendEmailRepository = outboxSendEmailRepository;
    }

    [HttpGet]
    public IActionResult CheckAPI()
    {
        return Ok(new { Message = "API Çalışıyor..." });
    }

    [HttpGet]
    public async Task<IActionResult> SendTestEmailBy3FailOptions(CancellationToken cancellationToken)
    {
        int tryCount = 0;
        Exception exception = new();
        while (true)
        {
            try
            {
                SendResponse sendResponse = await _fluentEmail
                     .To("info@test.com")
                     .Subject("Test Mail")
                     .Body("<h1>Test Maili</h1>", true)
                     .SendAsync(cancellationToken);

                return Ok(new { Message = "Send test email is successful" });
            }
            catch (Exception ex)
            {
                var delay = new Random().Next(500,2000);
                await Task.Delay(delay);

                tryCount++;
                Console.Out.WriteLine(ex.Message);

                exception = ex;
                if (tryCount > 3) break;
            }
        }

        return BadRequest(new { ErrorMessage = exception.Message });
    }

    [HttpGet]
    public async Task<IActionResult> SendTestEmailByOutboxPattern(CancellationToken cancellationToken)
    {
        try
        {

            OutboxSendEmail outboxSendEmail = new()
            {
                To = "info@test.com",
                Subject = "Test Mail",
                Body = "<h1>Test Maili</h1>"
            };

            await _outboxSendEmailRepository.AddAsync(outboxSendEmail, cancellationToken);

            SendResponse sendResponse = await _fluentEmail
                 .To(outboxSendEmail.To)
                 .Subject(outboxSendEmail.Subject)
                 .Body(outboxSendEmail.Body, true)
                 .SendAsync(cancellationToken);

            outboxSendEmail.IsItCompleted = true;
            await _outboxSendEmailRepository.UpdateAsync(outboxSendEmail, cancellationToken);

            return Ok(new { Message = "Send test email is successful" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { ErrorMessage = ex.Message });
        }        
    }
}
