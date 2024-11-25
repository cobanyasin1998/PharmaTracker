namespace Coban.Infrastructure.Exceptions.ExceptionTypes;

public class ValidationRuleException : Exception
{
    public ValidationRuleException()
    {
    }
    public ValidationRuleException(string message) : base(message)
    {
    }
    public ValidationRuleException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
