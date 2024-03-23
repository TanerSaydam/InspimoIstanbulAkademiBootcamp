using FluentValidation;

namespace eBiletServer.Application.Features.Routes.CreateRoute;

public sealed class CreateRouteCommandValidator : AbstractValidator<CreateRouteCommand>
{
    public CreateRouteCommandValidator()
    {
        RuleFor(p => p.From).MinimumLength(3);
        RuleFor(p => p.To).MinimumLength(3);        
    }
}
