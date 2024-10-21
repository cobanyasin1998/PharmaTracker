namespace PharmacyService.Application.Abstraction.Response;

public interface IResponseWithErrors
{
    IEnumerable<ValidationExceptionModel> Errors { get; set; }
}

    public class ValidationExceptionModel
{
    public string? Property { get; set; }
    public IEnumerable<string>? Errors { get; set; }
}