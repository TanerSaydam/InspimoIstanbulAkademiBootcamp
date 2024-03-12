using FluentValidation;
using MediatR;

namespace eBiletServer.Application.Behaviors;
public sealed class ValidationBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> validators
    ) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if(!validators.Any()) return await next();

        var context = new ValidationContext<TRequest>(request);

        var validationResult = await Task.WhenAll(validators.Select(s => s.ValidateAsync(context)));
        var failures = validationResult.SelectMany(s => s.Errors).Where(s => s != null).ToList();


        if (failures.Any())
        {            
            throw new ValidationException(failures);
        }

        return await next();
    }
}
