using Coban.GeneralDto;

namespace Coban.Infrastructure.Exceptions.ExceptionTypes;

public class ValidationRuleException : Exception
{
    public List<ValidationErrorDto> ErrorDetails { get; } = [];

    public ValidationRuleException()
    {
    }

    public ValidationRuleException(string message) : base(message)
    {
    }

    public ValidationRuleException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public ValidationRuleException(string message, List<ValidationErrorDto> errorDetails) : base(message)
    {
        ErrorDetails = errorDetails;
    }
}
