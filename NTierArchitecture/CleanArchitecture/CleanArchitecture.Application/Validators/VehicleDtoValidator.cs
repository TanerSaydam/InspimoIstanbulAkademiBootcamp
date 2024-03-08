using CleanArchitecture.Domain.DTOs;
using FluentValidation;

namespace CleanArchitecture.Application.Validators;
public sealed class VehicleDtoValidator : AbstractValidator<VehicleDto>
{
    public VehicleDtoValidator()
    {
        RuleFor(p => p.Year).GreaterThan(2000);
        RuleFor(p => p.Brand).MinimumLength(3);
        RuleFor(p => p.Model).MinimumLength(3);
    }
}