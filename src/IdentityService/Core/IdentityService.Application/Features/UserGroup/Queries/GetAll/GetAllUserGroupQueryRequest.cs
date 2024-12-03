using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace UserGroupService.Application.Features.UserGroup.Queries.GetAll;

public class GetAllUserGroupQueryRequest : IRequest<IResponse<GetAllUserGroupQueryResponse, GeneralErrorDto>>
{
   
}