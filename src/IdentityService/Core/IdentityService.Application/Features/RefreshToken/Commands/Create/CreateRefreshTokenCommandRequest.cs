using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace RefreshTokenService.Application.Features.RefreshToken.Commands.Create;

public class CreateRefreshTokenCommandRequest : IRequest<IResponse<CreateRefreshTokenCommandResponse, GeneralErrorDto>>
{
   
}