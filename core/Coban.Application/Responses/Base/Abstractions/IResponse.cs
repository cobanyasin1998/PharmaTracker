namespace Coban.Application.Responses.Base.Abstractions;

public interface IResponse<TData, TErrorDTO> : IResponseBase
{
    TData Data { get; set; }
    List<TErrorDTO> Errors { get; set; }

}