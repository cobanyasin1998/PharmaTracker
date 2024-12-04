﻿using Coban.GeneralDto;
using Coban.Infrastructure.Exceptions.ExceptionTypes;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Coban.Application.Pipelines;

public class RequestValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly IServiceProvider _serviceProvider;

    public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IServiceProvider serviceProvider)
    {
        _validators = validators;
        _serviceProvider = serviceProvider;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        ValidationContext<object> context = new(request);

        var validationResults = _validators
            .Select(validator => validator.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(failure => failure != null)
            .ToList();

        if (!validationResults.Any())
            return await next();

        var errorResponse = CreateValidationErrorResponse(validationResults);
        throw new ValidationRuleException("Validasyon Kuralları Hatalı", errorResponse);

    }

    private List<ValidationErrorDto> CreateValidationErrorResponse(IEnumerable<ValidationFailure> failures)
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
