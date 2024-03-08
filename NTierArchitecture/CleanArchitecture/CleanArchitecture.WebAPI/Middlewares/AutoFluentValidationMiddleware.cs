
using CleanArchitecture.Application.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Xml;

namespace CleanArchitecture.WebAPI.Middlewares;

public class AutoFluentValidationMiddleware(
    IServiceProvider serviceProvider) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var endpoint = context.GetEndpoint();
        if (endpoint != null)
        {
            var actionDescriptor = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();
            if (actionDescriptor != null)
            {
                var parameters = actionDescriptor.Parameters;
                foreach (var parameter in parameters)
                {
                    var assembly = typeof(VehicleDtoValidator).Assembly;

                    var validatorType = assembly.GetTypes()
                            .FirstOrDefault(t => t.BaseType != null
                                    && t.BaseType.IsGenericType
                                    && t.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>)
                                    && t.BaseType.GetGenericArguments()[0] == parameter.ParameterType);


                    if (validatorType != null)
                    {
                        var validator = serviceProvider.GetService(validatorType) as IValidator;
                        if (validator != null)
                        {
                            var argumentValue = await context.Request.ReadFromJsonAsync(parameter.ParameterType);
                            var validationContext = new ValidationContext<object>(argumentValue);
                            var validationResult = await validator.ValidateAsync(validationContext);

                            if (!validationResult.IsValid)
                            {
                                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                await context.Response.WriteAsJsonAsync(validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}
