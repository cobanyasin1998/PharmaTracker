namespace UserService.Application.Features.User.Commands.Delete;

public class DeleteUserCommandRequest : IRequest<IResponse<DeleteUserCommandResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}