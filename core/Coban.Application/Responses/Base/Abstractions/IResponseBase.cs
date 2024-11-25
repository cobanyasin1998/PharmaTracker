using Coban.Application.Responses.Base.Enums;

namespace Coban.Application.Responses.Base.Abstractions;

public interface IResponseBase
{
    bool Success { get; set; }
    string Message { get; set; }
    int HttpStatusCode { get; set; }
    DateTime Timestamp { get; set; }
    ErrorType? ErrorType { get; set; }
}