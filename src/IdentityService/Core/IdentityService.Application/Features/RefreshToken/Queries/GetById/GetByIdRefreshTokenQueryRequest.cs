namespace RefreshTokenService.Application.Features.RefreshToken.Queries.GetById;

public class GetByIdRefreshTokenQueryRequest : IRequest<IResponse<GetByIdRefreshTokenQueryResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}