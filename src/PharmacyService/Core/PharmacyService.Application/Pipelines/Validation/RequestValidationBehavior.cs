﻿using FluentValidation;
using MediatR;
using PharmacyService.Application.Abstraction.Response;

namespace PharmacyService.Application.Pipelines.Validation;

public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IResponseCustom, new()
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
                resultSelector: (propertyName, errorGroup) =>
                    new ValidationExceptionModel
                    {
                        Property = propertyName,
                        Errors = errorGroup
                            .Select(e => e.ErrorMessage)
                            .Distinct()
                            .ToList()
                    }
            ).ToList();

        TResponse response = new TResponse();

        if (errors.Any())
        {
            response.Errors = errors;
            response.Success = false;
            response.Message = "İşlem Başarısız"; // todo Daha sonra dil desteği eklenecek
            response.HttpStatusCode = System.Net.HttpStatusCode.BadRequest;
            return response;
        }
        response.Message = "İşlem Başarılı";
        return await next();

    }
}
