using FluentValidation;
using MediatR;

namespace CodeTest.Application.CQRS.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any()) return await next();
        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken))
        );
        var failures = validationResults.SelectMany(result => result.Errors)
            .Where(error => error != null)
            .ToList();
            
        if (failures.Any())
        {
            // You can either throw FluentValidation's exception or your own custom exception.
            throw new ValidationException(failures);
        }

        return await next();
    }
}