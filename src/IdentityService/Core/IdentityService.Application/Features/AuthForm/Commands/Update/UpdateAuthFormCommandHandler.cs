using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthFormService.Application.Features.AuthForm.Commands.Update;



public class UpdateAuthFormCommandHandler : IRequestHandler<UpdateAuthFormCommandRequest, IResponse<UpdateAuthFormCommandResponse, GeneralErrorDto>>
{
   
    public async Task<IResponse<UpdateAuthFormCommandResponse, GeneralErrorDto>> Handle(UpdateAuthFormCommandRequest request, CancellationToken cancellationToken)
    {

        throw new Exception("Not Implemented");

    }
}