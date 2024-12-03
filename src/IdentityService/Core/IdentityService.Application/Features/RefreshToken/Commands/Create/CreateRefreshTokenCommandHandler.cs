using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace RefreshTokenService.Application.Features.RefreshToken.Commands.Create;



public class CreateRefreshTokenCommandHandler : IRequestHandler<CreateRefreshTokenCommandRequest, IResponse<CreateRefreshTokenCommandResponse, GeneralErrorDto>>
{
    

    public async Task<IResponse<CreateRefreshTokenCommandResponse, GeneralErrorDto>> Handle(CreateRefreshTokenCommandRequest request, CancellationToken cancellationToken)
    {

        throw new Exception("Not Implemented");

    }
}
