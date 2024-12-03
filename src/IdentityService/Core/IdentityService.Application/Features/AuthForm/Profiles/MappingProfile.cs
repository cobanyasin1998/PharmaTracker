using AuthFormService.Application.Features.AuthForm.Commands.Create;
using AuthFormService.Application.Features.AuthForm.Commands.Update;
using AuthFormService.Application.Features.AuthForm.Queries.GetAll;
using AutoMapper;
using IdentityService.Domain.Entities;

namespace AuthFormService.Application.Features.AuthForm.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateAuthFormCommandRequest, AuthFormEntity>();
        CreateMap<UpdateAuthFormCommandRequest, AuthFormEntity>();
        CreateMap<AuthFormEntity, GetAllAuthFormQueryResponseItemDto>();
    }
}