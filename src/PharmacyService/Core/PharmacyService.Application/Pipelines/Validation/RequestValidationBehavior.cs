using FluentValidation;
using MediatR;
using PharmacyService.Application.Abstraction.Response;

namespace PharmacyService.Application.Pipelines.Validation;

public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IResponseWithErrors, new()
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        ValidationContext<object> context = new(request);

        var errors = _validators
            .Select(validator => validator.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(failure => failure != null)
            .GroupBy(
                keySelector: p => p.PropertyName,
                resultSelector: (propertyName, errors) =>
                    new ValidationExceptionModel
                    {
                        Property = propertyName,
                        Errors = errors.Select(e => e.ErrorMessage)
                    }
            ).ToList();

        TResponse response = new TResponse();

        if (errors.Any())
        {
            response.Errors = errors;
            return response; 
        }

        return await next();
    }
}
