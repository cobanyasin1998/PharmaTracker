namespace RefreshTokenService.Application.Features.RefreshToken.Queries.GetAll;

public class GetAllRefreshTokenQueryResponse
{
    public List<GetAllRefreshTokenQueryResponseItemDto> RefreshTokens { get; set; }
    public GetAllRefreshTokenQueryResponse(List<GetAllRefreshTokenQueryResponseItemDto> RefreshTokens)
    {
        RefreshTokens = RefreshTokens;
    }
}