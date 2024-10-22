using AutoMapper;
using PharmacyService.Application.Features.Pharmacy.Commands.Create;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.Pharmacy.Profiles;

internal class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PharmacyEntity, CreatePharmacyCommandRequest>().ReverseMap();
    }
}
