namespace UserGroupService.Application.Features.UserGroup.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserGroupCommandRequest, UserGroupEntity>();
        CreateMap<UpdateUserGroupCommandRequest, UserGroupEntity>();
        CreateMap<UserGroupEntity, GetAllUserGroupQueryResponseItemDto>();
        CreateMap<UserGroupEntity, GetByIdUserGroupQueryResponseItemDto>();
    }
}