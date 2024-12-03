using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthModuleService.Application.Features.AuthModule.Queries.GetAll;



public class GetAllAuthModuleQueryHandler : IRequestHandler<GetAllAuthModuleQueryRequest, IResponse<GetAllAuthModuleQueryResponse, GeneralErrorDto>>
{
    
    public async Task<IResponse<GetAllAuthModuleQueryResponse, GeneralErrorDto>> Handle(GetAllAuthModuleQueryRequest request, CancellationToken cancellationToken)
    {
        throw new Exception("Not Implemented");

    }
}