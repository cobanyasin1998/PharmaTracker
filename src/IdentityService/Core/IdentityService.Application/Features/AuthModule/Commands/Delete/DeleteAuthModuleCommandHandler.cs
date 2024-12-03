using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthModuleService.Application.Features.AuthModule.Commands.Delete;



public class DeleteAuthModuleCommandHandler : IRequestHandler<DeleteAuthModuleCommandRequest, IResponse<DeleteAuthModuleCommandResponse, GeneralErrorDto>>
{
   
    public async Task<IResponse<DeleteAuthModuleCommandResponse, GeneralErrorDto>> Handle(DeleteAuthModuleCommandRequest request, CancellationToken cancellationToken)
    {

        throw new Exception("Not Implemented");

    }
}