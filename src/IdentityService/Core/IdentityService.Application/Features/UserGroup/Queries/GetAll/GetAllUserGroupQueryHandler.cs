using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace UserGroupService.Application.Features.UserGroup.Queries.GetAll;



public class GetAllUserGroupQueryHandler : IRequestHandler<GetAllUserGroupQueryRequest, IResponse<GetAllUserGroupQueryResponse, GeneralErrorDto>>
{
   
    public async Task<IResponse<GetAllUserGroupQueryResponse, GeneralErrorDto>> Handle(GetAllUserGroupQueryRequest request, CancellationToken cancellationToken)
    {
        throw new Exception("Not Implemented");

    }
}