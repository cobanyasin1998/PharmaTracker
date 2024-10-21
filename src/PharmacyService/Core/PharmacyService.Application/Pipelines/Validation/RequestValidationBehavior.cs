using FluentValidation;
using MediatR;

namespace PharmacyService.Application.Pipelines.Validation;

public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
  where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }
    private class ValidationExceptionModel
    {
        public string? Property { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        ValidationContext<object> context = new(request);

        IEnumerable<ValidationExceptionModel> errors = _validators
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

        if (errors.Any())
            throw new Exception();
        TResponse response = await next();
        return response;
    }
}
