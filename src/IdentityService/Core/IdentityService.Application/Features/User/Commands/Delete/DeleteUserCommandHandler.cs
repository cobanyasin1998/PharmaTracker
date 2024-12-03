using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace UserService.Application.Features.User.Commands.Delete;



public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, IResponse<DeleteUserCommandResponse, GeneralErrorDto>>
{
   
    public async Task<IResponse<DeleteUserCommandResponse, GeneralErrorDto>> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
    {

        throw new Exception("Not Implemented");

    }
}