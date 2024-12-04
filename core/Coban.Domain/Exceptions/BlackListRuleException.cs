namespace Coban.Infrastructure.Exceptions.ExceptionTypes;


public class BlackListRuleException : Exception
{
    public BlackListRuleException()
    {
    }
    public BlackListRuleException(string message) : base(message)
    {
    }
    public BlackListRuleException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
