using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace RefreshTokenService.Application.Features.RefreshToken.Commands.Update;

public class UpdateRefreshTokenCommandRequest : IRequest<IResponse<UpdateRefreshTokenCommandResponse, GeneralErrorDto>>
{
   
}