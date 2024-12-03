using AuthDefinitionService.Application.Features.AuthDefinition.Commands.Create;
using AuthDefinitionService.Application.Features.AuthDefinition.Commands.Update;
using AuthDefinitionService.Application.Features.AuthDefinition.Queries.GetAll;
using AutoMapper;
using IdentityService.Domain.Entities;

namespace AuthDefinitionService.Application.Features.AuthDefinition.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateAuthDefinitionCommandRequest, AuthDefinitionEntity>();
        CreateMap<UpdateAuthDefinitionCommandRequest, AuthDefinitionEntity>();
        CreateMap<AuthDefinitionEntity, GetAllAuthDefinitionQueryResponseItemDto>();
        
    }
}