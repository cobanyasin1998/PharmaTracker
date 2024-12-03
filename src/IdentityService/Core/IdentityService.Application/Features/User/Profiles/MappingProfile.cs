using AutoMapper;
using IdentityService.Domain.Entities;
using UserService.Application.Features.User.Commands.Create;
using UserService.Application.Features.User.Commands.Update;
using UserService.Application.Features.User.Queries.GetAll;

namespace UserService.Application.Features.User.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserCommandRequest, UserEntity>();
        CreateMap<UpdateUserCommandRequest, UserEntity>();
        CreateMap<UserEntity, GetAllUserQueryResponseItemDto>();
    }
}