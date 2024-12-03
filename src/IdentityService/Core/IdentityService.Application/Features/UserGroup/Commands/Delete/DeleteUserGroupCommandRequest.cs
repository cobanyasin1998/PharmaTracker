using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace UserGroupService.Application.Features.UserGroup.Commands.Delete;

public class DeleteUserGroupCommandRequest : IRequest<IResponse<DeleteUserGroupCommandResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}