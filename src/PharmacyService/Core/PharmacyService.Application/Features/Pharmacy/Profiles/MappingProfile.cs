using AutoMapper;
using Coban.Application.Services.Abstractions;
using PharmacyService.Application.Features.Pharmacy.Commands.Create;
using PharmacyService.Application.Features.Pharmacy.Commands.Update;
using PharmacyService.Application.Features.Pharmacy.Queries.GetAll;
using PharmacyService.Application.Features.Pharmacy.Queries.GetById;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.Pharmacy.Profiles;

internal class MappingProfile : Profile
{
    public MappingProfile( )
    {
        CreateMap<PharmacyEntity, CreatePharmacyCommandRequest>().ReverseMap();
        CreateMap<PharmacyEntity, UpdatePharmacyCommandRequest>().ReverseMap();
        CreateMap<PharmacyEntity, GetByIdPharmacyQueryResponse>().ReverseMap();
        CreateMap<List<PharmacyEntity>, GetAllPharmacyQueryResponse>().ReverseMap();



    }
}
