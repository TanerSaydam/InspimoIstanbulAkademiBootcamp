using EntityFrameworkCore.WebAPI.DTOs;
using FluentValidation;

namespace EntityFrameworkCore.WebAPI.Validators;

public class CreatePersonelDtoValidator : AbstractValidator<CreatePersonelDto>
{
    public CreatePersonelDtoValidator()
    {
        RuleFor(p => p.FirstName)
            .NotEmpty()
            .WithMessage("Ad alanı boş olamaz")
            .MinimumLength(3)
            .WithMessage("Ad alanı en az 3 karakter olmalıdır");

        RuleFor(p => p.LastName)
            .NotEmpty()
            .MinimumLength(3);

        RuleFor(p => p.Email)
            .NotEmpty()
            .MinimumLength(3)
            .EmailAddress(); 
    }
}
