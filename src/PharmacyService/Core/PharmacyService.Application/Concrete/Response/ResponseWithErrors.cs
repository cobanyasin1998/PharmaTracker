using PharmacyService.Application.Abstraction.Response;
using System.Net;

namespace PharmacyService.Application.Concrete.Response;

public class ResponseCustom : IResponseCustom
{
    public IEnumerable<ValidationExceptionModel> Errors { get; set; }
        = new List<ValidationExceptionModel>();
    public bool Success { get; set; } = true;
    public string Message { get; set; } = string.Empty;
    public HttpStatusCode HttpStatusCode { get; set; } = HttpStatusCode.OK;
}
