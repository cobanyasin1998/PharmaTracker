namespace Coban.Application.Services.Exceptions;

public class DataProtectKeyException:Exception
{
    public DataProtectKeyException()
    {
    }
    public DataProtectKeyException(string message) : base(message)
    {
    }
    public DataProtectKeyException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
