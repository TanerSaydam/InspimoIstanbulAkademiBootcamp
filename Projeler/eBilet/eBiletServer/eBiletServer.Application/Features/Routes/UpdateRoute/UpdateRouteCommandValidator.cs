using FluentValidation;

namespace eBiletServer.Application.Features.Routes.UpdateRoute;

public sealed class UpdateRouteCommandValidator : AbstractValidator<UpdateRouteCommand>
{
    public UpdateRouteCommandValidator()
    {
        RuleFor(p => p.From).MinimumLength(3);
        RuleFor(p => p.To).MinimumLength(3);
    }
}



