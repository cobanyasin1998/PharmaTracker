using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthDefinitionService.Application.Features.AuthDefinition.Commands.Delete;

public class DeleteAuthDefinitionCommandRequest : IRequest<IResponse<DeleteAuthDefinitionCommandResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}