using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace GroupAuthDefinitionService.Application.Features.GroupAuthDefinition.Queries.GetAll;



public class GetAllGroupAuthDefinitionQueryHandler : IRequestHandler<GetAllGroupAuthDefinitionQueryRequest, IResponse<GetAllGroupAuthDefinitionQueryResponse, GeneralErrorDto>>
{
   
    public async Task<IResponse<GetAllGroupAuthDefinitionQueryResponse, GeneralErrorDto>> Handle(GetAllGroupAuthDefinitionQueryRequest request, CancellationToken cancellationToken)
    {
        throw new Exception("Not Implemented");

    }
}