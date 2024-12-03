namespace RefreshTokenService.Application.Features.RefreshToken.Commands.Delete;

public class DeleteRefreshTokenCommandRequest : IRequest<IResponse<DeleteRefreshTokenCommandResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}