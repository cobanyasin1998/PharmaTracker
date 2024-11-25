using Coban.Application.Responses.Base.Abstractions;
using Coban.Application.Responses.Base.Enums;
using Coban.Consts;
using System.Text.Json.Serialization;

namespace Coban.Application.Responses.Base.Concretes;

public class Response<TData, TErrorDTO> : IResponse<TData, TErrorDTO>
{
    #region Properties
    public TData Data { get; set; }
    public List<TErrorDTO> Errors { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    [JsonIgnore]
    public int HttpStatusCode { get; set; }
    public DateTime Timestamp { get; set; }
    public ErrorType? ErrorType { get; set; }

    #endregion

    #region Constructor Methods
    private Response(TData data)
    {
        Data = data;
        Errors = new List<TErrorDTO>();
        Success = true;
        Timestamp = DateTime.UtcNow;
        Message = GeneralOperationConsts.OperationSuccessfull;
        HttpStatusCode = 200;
        ErrorType = null;
    }

    private Response(List<TErrorDTO> errors, string message, ErrorType errorType, int httpStatusCode = 500)
    {
        Errors = errors;
        Message = message;
        ErrorType = errorType;
        HttpStatusCode = httpStatusCode;
        Success = false;
        Timestamp = DateTime.UtcNow;
    }
    #endregion

    #region Static Methods
    public static Response<TData, TErrorDTO> CreateSuccess(TData? data)
    {
        return new Response<TData, TErrorDTO>(data);
    }

    public static Response<TData, TErrorDTO> CreateFailure(
        List<TErrorDTO> errors,
        string message,
        ErrorType errorType,
        int httpStatusCode = 500
        )
    {
        return new Response<TData, TErrorDTO>(errors, message, errorType, httpStatusCode);
    }
    #endregion


}
