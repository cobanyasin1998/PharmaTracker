namespace Coban.Infrastructure.Exceptions.ExceptionTypes;

public class ValidationRuleException : Exception
{
    // Hata detaylarını taşımak için bir property
    public object ErrorDetails { get; }

    // Parametresiz constructor
    public ValidationRuleException()
    {
    }

    // Sadece mesaj ile çalışan constructor
    public ValidationRuleException(string message) : base(message)
    {
    }

    // Mesaj ve inner exception içeren constructor
    public ValidationRuleException(string message, Exception innerException) : base(message, innerException)
    {
    }

    // Mesaj ve hata detayları içeren constructor
    public ValidationRuleException(string message, object errorDetails) : base(message)
    {
        ErrorDetails = errorDetails;
    }
}
