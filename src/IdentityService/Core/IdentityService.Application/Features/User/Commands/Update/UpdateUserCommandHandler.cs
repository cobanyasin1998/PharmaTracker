using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace UserService.Application.Features.User.Commands.Update;



public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, IResponse<UpdateUserCommandResponse, GeneralErrorDto>>
{
   
    public async Task<IResponse<UpdateUserCommandResponse, GeneralErrorDto>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {
        throw new Exception("Not Implemented");

    }
}