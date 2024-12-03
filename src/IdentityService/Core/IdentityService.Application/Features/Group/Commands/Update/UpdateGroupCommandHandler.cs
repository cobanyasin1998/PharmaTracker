using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace GroupService.Application.Features.Group.Commands.Update;



public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommandRequest, IResponse<UpdateGroupCommandResponse, GeneralErrorDto>>
{
  
    public async Task<IResponse<UpdateGroupCommandResponse, GeneralErrorDto>> Handle(UpdateGroupCommandRequest request, CancellationToken cancellationToken)
    {

        throw new Exception("Not Implemented");

    }
}