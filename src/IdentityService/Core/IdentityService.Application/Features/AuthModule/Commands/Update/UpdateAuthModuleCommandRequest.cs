using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthModuleService.Application.Features.AuthModule.Commands.Update;

public class UpdateAuthModuleCommandRequest : IRequest<IResponse<UpdateAuthModuleCommandResponse, GeneralErrorDto>>
{
   
}