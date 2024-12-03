namespace RefreshTokenService.Application.Features.RefreshToken.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateRefreshTokenCommandRequest, RefreshTokenEntity>();
        CreateMap<UpdateRefreshTokenCommandRequest, RefreshTokenEntity>();
        CreateMap<RefreshTokenEntity, GetAllRefreshTokenQueryResponseItemDto>();
        CreateMap<RefreshTokenEntity, GetByIdRefreshTokenQueryResponseItemDto>();
    }
}