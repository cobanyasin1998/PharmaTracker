using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace RefreshTokenService.Application.Features.RefreshToken.Commands.Update;



public class UpdateRefreshTokenCommandHandler : IRequestHandler<UpdateRefreshTokenCommandRequest, IResponse<UpdateRefreshTokenCommandResponse, GeneralErrorDto>>
{
    public async Task<IResponse<UpdateRefreshTokenCommandResponse, GeneralErrorDto>> Handle(UpdateRefreshTokenCommandRequest request, CancellationToken cancellationToken)
    {

        throw new Exception("Not Implemented");
    }
}