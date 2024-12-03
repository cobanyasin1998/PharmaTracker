using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace GroupService.Application.Features.Group.Commands.Delete;



public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommandRequest, IResponse<DeleteGroupCommandResponse, GeneralErrorDto>>
{
  
    public async Task<IResponse<DeleteGroupCommandResponse, GeneralErrorDto>> Handle(DeleteGroupCommandRequest request, CancellationToken cancellationToken)
    {
        throw new Exception("Not Implemented");

    }
}