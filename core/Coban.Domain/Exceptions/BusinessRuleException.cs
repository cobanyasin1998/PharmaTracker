﻿namespace Coban.Infrastructure.Exceptions.ExceptionTypes;

public class BusinessRuleException : Exception
{
    public BusinessRuleException()
    {
    }
    public BusinessRuleException(string message) : base(message)
    {
    }
    public BusinessRuleException(string message, Exception innerException) : base(message, innerException)
    {
    }
}