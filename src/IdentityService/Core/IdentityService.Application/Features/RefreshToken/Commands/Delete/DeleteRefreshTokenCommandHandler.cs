using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace RefreshTokenService.Application.Features.RefreshToken.Commands.Delete;



public class DeleteRefreshTokenCommandHandler : IRequestHandler<DeleteRefreshTokenCommandRequest, IResponse<DeleteRefreshTokenCommandResponse, GeneralErrorDto>>
{
  
    public async Task<IResponse<DeleteRefreshTokenCommandResponse, GeneralErrorDto>> Handle(DeleteRefreshTokenCommandRequest request, CancellationToken cancellationToken)
    {

        throw new Exception("Not Implemented");

    }
}