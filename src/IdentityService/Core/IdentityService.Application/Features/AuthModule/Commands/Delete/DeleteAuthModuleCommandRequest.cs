namespace AuthModuleService.Application.Features.AuthModule.Commands.Delete;

public class DeleteAuthModuleCommandRequest : IRequest<IResponse<DeleteAuthModuleCommandResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}