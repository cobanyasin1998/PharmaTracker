using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace GroupAuthDefinitionService.Application.Features.GroupAuthDefinition.Commands.Delete;

public class DeleteGroupAuthDefinitionCommandRequest : IRequest<IResponse<DeleteGroupAuthDefinitionCommandResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}