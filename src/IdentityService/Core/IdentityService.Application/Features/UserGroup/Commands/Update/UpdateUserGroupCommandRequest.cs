using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace UserGroupService.Application.Features.UserGroup.Commands.Update;

public class UpdateUserGroupCommandRequest : IRequest<IResponse<UpdateUserGroupCommandResponse, GeneralErrorDto>>
{
   
}