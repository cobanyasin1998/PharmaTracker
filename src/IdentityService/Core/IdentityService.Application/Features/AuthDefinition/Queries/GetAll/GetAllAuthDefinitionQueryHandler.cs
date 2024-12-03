using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthDefinitionService.Application.Features.AuthDefinition.Queries.GetAll;
public class GetAllAuthDefinitionQueryHandler : IRequestHandler<GetAllAuthDefinitionQueryRequest, IResponse<GetAllAuthDefinitionQueryResponse, GeneralErrorDto>>
{
   
    public async Task<IResponse<GetAllAuthDefinitionQueryResponse, GeneralErrorDto>> Handle(GetAllAuthDefinitionQueryRequest request, CancellationToken cancellationToken)
    {
        throw new Exception("Not Implemented");

    }
}