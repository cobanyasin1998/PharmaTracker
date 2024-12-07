namespace Coban.Domain.Exceptions;


public class MaintenanceServiceUnavailableException : Exception
{
    public MaintenanceServiceUnavailableException()
    {
    }
    public MaintenanceServiceUnavailableException(string message) : base(message)
    {
    }
    public MaintenanceServiceUnavailableException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
