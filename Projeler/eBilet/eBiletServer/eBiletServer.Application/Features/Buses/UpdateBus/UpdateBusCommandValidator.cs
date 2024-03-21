using eBiletServer.Application.Features.Buses.UpdateBus;
using FluentValidation;

namespace eBiletServer.Application.Features.Buses.CreateBus;

public sealed class UpdateBusCommandValidator : AbstractValidator<UpdateBusCommand>
{
    public UpdateBusCommandValidator()
    {
        RuleFor(p => p.Model).GreaterThan(1999);
        RuleFor(p => p.Plate).MinimumLength(3);
        RuleFor(p => p.Brand).MinimumLength(3);
    }
}
