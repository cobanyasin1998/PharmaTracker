using Coban.Infrastructure.Exceptions.ExceptionTypes;
using Microsoft.AspNetCore.Http;

namespace Coban.Infrastructure.Exceptions.Abstractions;

public abstract class ExceptionHandler
{
    public Task HandleExceptionAsync(System.Exception exception, HttpContext context) =>
       exception switch
       {
           BusinessRuleException businessRuleException => HandleException(businessRuleException, context),
           ValidationRuleException validationRuleException => HandleException(validationRuleException, context),
           DataProtectKeyException dataProtectKeyException => HandleException(dataProtectKeyException, context),
           BlackListRuleException blackListRuleException => HandleException(blackListRuleException, context),
           _ => HandleException(exception, context)
       };

    protected abstract Task HandleException(BusinessRuleException exception, HttpContext context);
    protected abstract Task HandleException(ValidationRuleException exception, HttpContext context);
    protected abstract Task HandleException(DataProtectKeyException exception, HttpContext context);
    protected abstract Task HandleException(BlackListRuleException exception, HttpContext context);
    protected abstract Task HandleException(System.Exception exception, HttpContext context);

}
