using Coban.GeneralDto;
using Coban.Infrastructure.Exceptions.ExceptionTypes;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Coban.Application.Mediatr.Pipelines;

public class RequestValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> _validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        ValidationContext<object> context = new(request);

        List<ValidationFailure> validationResults = _validators
            .Select(validator => validator.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(failure => failure != null)
            .ToList();

        if (!validationResults.Any())
            return await next();

        List<ValidationErrorDto> errorResponse = CreateValidationErrorResponse(validationResults);
        throw new ValidationRuleException("Validasyon Kuralları Hatalı", errorResponse);

    }

    private static List<ValidationErrorDto> CreateValidationErrorResponse(IEnumerable<ValidationFailure> failures)
    {
        List<ValidationErrorDto> errors = failures
            .GroupBy(failure => failure.PropertyName)
            .Select(group => new ValidationErrorDto(
                Field: group.Key,
                ErrorMessage: group.First().ErrorMessage,
                InvalidValue: group.First().AttemptedValue?.ToString()))
            .ToList();

        return errors;
    }
}
