﻿using Coban.Application.Responses.Base.Concretes;
using Coban.Application.Responses.Base.Enums;
using Coban.GeneralDto;
using Coban.Infrastructure.Exceptions.Abstractions;
using Coban.Infrastructure.Exceptions.ExceptionTypes;
using Microsoft.AspNetCore.Http;

namespace Coban.Infrastructure.Exceptions.Concretes;

public class HttpExceptionHandler : ExceptionHandler
{
    protected override Task HandleException(BusinessRuleException exception, HttpContext context)
    {
        Response<object, GeneralErrorDTO> response =  Response<object, GeneralErrorDTO>.CreateFailure(
            errors: new List<GeneralErrorDTO>
            {
                new GeneralErrorDTO(ErrorMessage: exception.Message,Details: exception.InnerException?.Message)
            },
            message: exception.Message,
            errorType: ErrorType.BusinessRuleViolation,
            httpStatusCode: 400
            );

        return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));

    }

    protected override Task HandleException(ValidationRuleException exception, HttpContext context)
    {
        Response<object, GeneralErrorDTO> response = Response<object, GeneralErrorDTO>.CreateFailure(
             errors: new List<GeneralErrorDTO>
             {
                new GeneralErrorDTO(ErrorMessage: exception.Message,Details: exception.InnerException?.Message)
             },
             message: exception.Message,
             errorType: ErrorType.BusinessRuleViolation,
             httpStatusCode: 400
             );

        return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
    }

    protected override Task HandleException(Exception exception, HttpContext context)
    {
        Response<object, GeneralErrorDTO> response = Response<object, GeneralErrorDTO>.CreateFailure(
           errors: new List<GeneralErrorDTO>
           {
                new GeneralErrorDTO(ErrorMessage: exception.Message,Details: exception.InnerException?.Message)
           },
           message: exception.Message,
           errorType: ErrorType.BusinessRuleViolation,
           httpStatusCode: 400
           );

        return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
    }
}
