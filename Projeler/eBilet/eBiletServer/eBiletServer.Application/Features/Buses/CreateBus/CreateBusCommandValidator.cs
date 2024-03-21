using FluentValidation;

namespace eBiletServer.Application.Features.Buses.CreateBus;

public sealed class CreateBusCommandValidator : AbstractValidator<CreateBusCommand>
{
    public CreateBusCommandValidator()
    {
        RuleFor(p => p.Model).GreaterThan(1999);
        RuleFor(p => p.Plate).MinimumLength(3);
        RuleFor(p => p.Brand).MinimumLength(3);
    }
}
