using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthModuleService.Application.Features.AuthModule.Commands.Update;



public class UpdateAuthModuleCommandHandler : IRequestHandler<UpdateAuthModuleCommandRequest, IResponse<UpdateAuthModuleCommandResponse, GeneralErrorDto>>
{
    
    public async Task<IResponse<UpdateAuthModuleCommandResponse, GeneralErrorDto>> Handle(UpdateAuthModuleCommandRequest request, CancellationToken cancellationToken)
    {
        throw new Exception("Not Implemented");

    }
}