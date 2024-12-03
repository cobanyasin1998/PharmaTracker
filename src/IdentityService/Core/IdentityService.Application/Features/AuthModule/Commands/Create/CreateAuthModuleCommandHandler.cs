using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthModuleService.Application.Features.AuthModule.Commands.Create;



public class CreateAuthModuleCommandHandler : IRequestHandler<CreateAuthModuleCommandRequest, IResponse<CreateAuthModuleCommandResponse, GeneralErrorDto>>
{
    
    public async Task<IResponse<CreateAuthModuleCommandResponse, GeneralErrorDto>> Handle(CreateAuthModuleCommandRequest request, CancellationToken cancellationToken)
    {

        throw new Exception("Not Implemented");

    }
}
