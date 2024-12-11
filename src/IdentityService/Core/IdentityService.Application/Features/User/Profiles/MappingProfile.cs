using AutoMapper;
using Coban.Identity.Entities.Base;
using IdentityService.Application.Features.User.Commands.Create;
using IdentityService.Application.Features.User.Commands.Update;
using IdentityService.Application.Features.User.Queries.GetAll;

namespace IdentityService.Application.Features.User.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserCommandRequest, UserEntity>();
        CreateMap<UpdateUserCommandRequest, UserEntity>();
        CreateMap<UserEntity, GetAllUserQueryResponseItemDto>();
    }
}