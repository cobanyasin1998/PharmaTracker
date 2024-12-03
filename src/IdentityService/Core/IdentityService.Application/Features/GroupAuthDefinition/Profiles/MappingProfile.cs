using AutoMapper;
using GroupAuthDefinitionService.Application.Features.GroupAuthDefinition.Commands.Create;
using GroupAuthDefinitionService.Application.Features.GroupAuthDefinition.Commands.Update;
using GroupAuthDefinitionService.Application.Features.GroupAuthDefinition.Queries.GetAll;
using IdentityService.Domain.Entities;

namespace GroupAuthDefinitionService.Application.Features.GroupAuthDefinition.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateGroupAuthDefinitionCommandRequest, GroupAuthDefinitionEntity>();
        CreateMap<UpdateGroupAuthDefinitionCommandRequest, GroupAuthDefinitionEntity>();
        CreateMap<GroupAuthDefinitionEntity, GetAllGroupAuthDefinitionQueryResponseItemDto>();
    }
}