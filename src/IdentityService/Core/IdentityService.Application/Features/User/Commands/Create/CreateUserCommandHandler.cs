using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace UserService.Application.Features.User.Commands.Create;



public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, IResponse<CreateUserCommandResponse, GeneralErrorDto>>
{
   

    public async Task<IResponse<CreateUserCommandResponse, GeneralErrorDto>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {


        throw new Exception("Not Implemented");

    }
}
