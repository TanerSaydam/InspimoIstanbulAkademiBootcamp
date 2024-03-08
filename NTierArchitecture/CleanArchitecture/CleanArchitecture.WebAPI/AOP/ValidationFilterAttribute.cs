using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArchitecture.WebAPI.AOP;
public class ValidationFilterAttribute<T> : Attribute, IActionFilter
    where T : IValidator, new()
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var request = context.ActionArguments.First().Value;

        T data = new();

        var validationContext = new ValidationContext<object>(request);

        ValidationResult validationResult = data.Validate(validationContext);
        if (!validationResult.IsValid)
        {
            List<string> errors = validationResult.Errors.Select(s => s.ErrorMessage).ToList();
            throw new ArgumentException(string.Join("\n", errors));
        }         
    }
}
