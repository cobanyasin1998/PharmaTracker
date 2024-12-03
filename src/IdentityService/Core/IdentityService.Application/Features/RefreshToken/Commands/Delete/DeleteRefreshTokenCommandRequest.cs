using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace RefreshTokenService.Application.Features.RefreshToken.Commands.Delete;

public class DeleteRefreshTokenCommandRequest : IRequest<IResponse<DeleteRefreshTokenCommandResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}