using FluentValidation;
using PersonelServer.DTOs;

namespace PersonelServer.Validators;

public sealed class CreatePersonelDtoValidator : AbstractValidator<CreatePersonelDto>
{
    public CreatePersonelDtoValidator()
    {
        RuleFor(p => p.FirstName).NotEmpty().MinimumLength(3);
        RuleFor(p => p.LastName).NotEmpty().MinimumLength(3);
        RuleFor(p => p.PhoneNumber).NotEmpty().MinimumLength(10).MaximumLength(10);
        RuleFor(p => p.IdentityNumber).NotEmpty().MinimumLength(11).MaximumLength(11);
        RuleFor(p => p.Email).NotEmpty().EmailAddress().MinimumLength(3);
        RuleFor(p => p.Salary).NotEmpty().GreaterThan(17001);
        RuleFor(p => p.StartDate).NotEmpty().GreaterThan(DateOnly.FromDateTime(DateTime.Now.AddDays(-1)));
        RuleFor(p => p.City).NotEmpty();
        RuleFor(p => p.District).NotEmpty();
        RuleFor(p => p.FullAddress).NotEmpty().MinimumLength(3);
    }
}
