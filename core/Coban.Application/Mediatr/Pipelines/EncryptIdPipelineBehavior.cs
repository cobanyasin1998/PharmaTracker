using Coban.Application.DataProtection.Abstractions;
using Coban.Application.Responses;
using MediatR;

namespace Coban.Application.Mediatr.Pipelines;

public class EncryptIdPipelineBehavior<TRequest, TResponse>(IDataProtectService _dataProtectService)
    : IPipelineBehavior<TRequest, TResponse>
    where TResponse : class
{

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        TResponse response = await next();

        dynamic dynamicResponse = response;

        if (dynamicResponse?.Data is BaseResponse baseResponse)
            baseResponse.EncId = _dataProtectService.Encrypt(baseResponse.Id);
        return response;
    }
}
