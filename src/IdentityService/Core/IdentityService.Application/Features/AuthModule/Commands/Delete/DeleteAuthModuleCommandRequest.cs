using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthModuleService.Application.Features.AuthModule.Commands.Delete;

public class DeleteAuthModuleCommandRequest : IRequest<IResponse<DeleteAuthModuleCommandResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}