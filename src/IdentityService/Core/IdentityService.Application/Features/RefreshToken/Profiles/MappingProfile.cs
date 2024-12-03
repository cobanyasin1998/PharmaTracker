using AutoMapper;
using IdentityService.Domain.Entities;
using RefreshTokenService.Application.Features.RefreshToken.Commands.Create;
using RefreshTokenService.Application.Features.RefreshToken.Commands.Update;
using RefreshTokenService.Application.Features.RefreshToken.Queries.GetAll;

namespace RefreshTokenService.Application.Features.RefreshToken.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateRefreshTokenCommandRequest, RefreshTokenEntity>();
        CreateMap<UpdateRefreshTokenCommandRequest, RefreshTokenEntity>();
        CreateMap<RefreshTokenEntity, GetAllRefreshTokenQueryResponseItemDto>();
    }
}