using PharmacyService.Application.Abstraction.Response;

namespace PharmacyService.Application.Concrete.Response;

public class ResponseWithErrors : IResponseWithErrors
{
    public IEnumerable<ValidationExceptionModel> Errors { get; set; } 
        = new List<ValidationExceptionModel>();
}
