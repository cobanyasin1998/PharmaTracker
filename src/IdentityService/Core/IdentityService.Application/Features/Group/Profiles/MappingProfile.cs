using AutoMapper;
using GroupService.Application.Features.Group.Commands.Create;
using GroupService.Application.Features.Group.Commands.Update;
using GroupService.Application.Features.Group.Queries.GetAll;
using IdentityService.Domain.Entities;

namespace GroupService.Application.Features.Group.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateGroupCommandRequest, GroupEntity>();
        CreateMap<UpdateGroupCommandRequest, GroupEntity>();
        CreateMap<GroupEntity, GetAllGroupQueryResponseItemDto>();
    }
}