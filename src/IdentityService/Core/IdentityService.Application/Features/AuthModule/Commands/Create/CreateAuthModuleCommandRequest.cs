using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthModuleService.Application.Features.AuthModule.Commands.Create;

public class CreateAuthModuleCommandRequest : IRequest<IResponse<CreateAuthModuleCommandResponse, GeneralErrorDto>>
{
   
}