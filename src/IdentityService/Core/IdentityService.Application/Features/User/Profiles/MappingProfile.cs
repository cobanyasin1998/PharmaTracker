namespace UserService.Application.Features.User.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserCommandRequest, UserEntity>();
        CreateMap<UpdateUserCommandRequest, UserEntity>();
        CreateMap<UserEntity, GetAllUserQueryResponseItemDto>();
        CreateMap<UserEntity, GetByIdUserQueryResponseItemDto>();
    }
}