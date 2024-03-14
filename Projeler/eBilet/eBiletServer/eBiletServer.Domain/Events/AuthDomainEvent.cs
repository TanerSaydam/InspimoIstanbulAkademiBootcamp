using MediatR;

namespace eBiletServer.Domain.Events;
public sealed class AuthDomainEvent : INotification
{
    public string Email { get; }
    public string EmailConfirmCode { get; }
    public AuthDomainEvent(string email, string emailConfirmCode)
    {
        Email = email;
        EmailConfirmCode = emailConfirmCode;
    }  
}
