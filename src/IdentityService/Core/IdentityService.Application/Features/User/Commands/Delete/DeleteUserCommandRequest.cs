using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace UserService.Application.Features.User.Commands.Delete;

public class DeleteUserCommandRequest : IRequest<IResponse<DeleteUserCommandResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}