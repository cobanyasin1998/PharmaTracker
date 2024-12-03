namespace AuthFormService.Application.Features.AuthForm.Commands.Delete;

public class DeleteAuthFormCommandRequest : IRequest<IResponse<DeleteAuthFormCommandResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}