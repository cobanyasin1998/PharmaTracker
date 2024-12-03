using AutoMapper;
using IdentityService.Domain.Entities;
using UserGroupService.Application.Features.UserGroup.Commands.Create;
using UserGroupService.Application.Features.UserGroup.Commands.Update;
using UserGroupService.Application.Features.UserGroup.Queries.GetAll;

namespace UserGroupService.Application.Features.UserGroup.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserGroupCommandRequest, UserGroupEntity>();
        CreateMap<UpdateUserGroupCommandRequest, UserGroupEntity>();
        CreateMap<UserGroupEntity, GetAllUserGroupQueryResponseItemDto>();
    }
}