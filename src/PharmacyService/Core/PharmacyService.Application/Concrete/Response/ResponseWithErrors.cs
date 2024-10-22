using PharmacyService.Application.Abstraction.Response;

namespace PharmacyService.Application.Concrete.Response;

public class ResponseWithErrors : IResponseWithErrors
{
    public IEnumerable<ValidationExceptionModel> Errors { get; set; }
        = new List<ValidationExceptionModel>();
    public bool Success { get; set; } = true;
    public string Message { get; set; } = string.Empty;
}
