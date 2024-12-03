using AuthModuleService.Application.Features.AuthModule.Commands.Create;
using AuthModuleService.Application.Features.AuthModule.Commands.Update;
using AuthModuleService.Application.Features.AuthModule.Queries.GetAll;
using AutoMapper;
using IdentityService.Domain.Entities;

namespace AuthModuleService.Application.Features.AuthModule.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateAuthModuleCommandRequest, AuthModuleEntity>();
        CreateMap<UpdateAuthModuleCommandRequest, AuthModuleEntity>();
        CreateMap<AuthModuleEntity, GetAllAuthModuleQueryResponseItemDto>();
    }
}