using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthFormService.Application.Features.AuthForm.Commands.Delete;



public class DeleteAuthFormCommandHandler : IRequestHandler<DeleteAuthFormCommandRequest, IResponse<DeleteAuthFormCommandResponse, GeneralErrorDto>>
{
  
    public async Task<IResponse<DeleteAuthFormCommandResponse, GeneralErrorDto>> Handle(DeleteAuthFormCommandRequest request, CancellationToken cancellationToken)
    {
        throw new Exception("Not Implemented");

    }
}