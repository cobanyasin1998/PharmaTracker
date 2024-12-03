using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace UserGroupService.Application.Features.UserGroup.Commands.Create;

public class CreateUserGroupCommandRequest : IRequest<IResponse<CreateUserGroupCommandResponse, GeneralErrorDto>>
{
   
}