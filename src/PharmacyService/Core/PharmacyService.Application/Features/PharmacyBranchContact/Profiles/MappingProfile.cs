using AutoMapper;
using PharmacyService.Application.Features.PharmacyBranchContact.Commands.Create;
using PharmacyService.Application.Features.PharmacyBranchContact.Commands.Update;
using PharmacyService.Application.Features.PharmacyBranchContact.Queries.GetAll;
using PharmacyService.Application.Features.PharmacyBranchContact.Queries.GetById;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchContact.Profiles;

internal class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PharmacyBranchContactEntity, CreatePharmacyBranchContactCommandRequest>().ReverseMap();
        CreateMap<PharmacyBranchContactEntity, UpdatePharmacyBranchContactCommandRequest>().ReverseMap();
        CreateMap<PharmacyBranchContactEntity, GetByIdPharmacyBranchContactQueryResponse>().ReverseMap();
        CreateMap<List<PharmacyBranchContactEntity>, GetAllPharmacyBranchContactQueryResponse>().ReverseMap();

    }
}
