using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthFormService.Application.Features.AuthForm.Commands.Create;



public class CreateAuthFormCommandHandler : IRequestHandler<CreateAuthFormCommandRequest, IResponse<CreateAuthFormCommandResponse, GeneralErrorDto>>
{
   

 

    public async Task<IResponse<CreateAuthFormCommandResponse, GeneralErrorDto>> Handle(CreateAuthFormCommandRequest request, CancellationToken cancellationToken)
    {
        throw new Exception("Not Implemented");
    }
}
