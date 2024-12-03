namespace GroupAuthDefinitionService.Application.Features.GroupAuthDefinition.Commands.Delete;

public class DeleteGroupAuthDefinitionCommandRequest : IRequest<IResponse<DeleteGroupAuthDefinitionCommandResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}