using AutoMapper;
using PharmacyService.Application.Features.PharmacyBranch.Commands.Create;
using PharmacyService.Application.Features.PharmacyBranch.Commands.Update;
using PharmacyService.Application.Features.PharmacyBranch.Queries.GetAll;
using PharmacyService.Application.Features.PharmacyBranch.Queries.GetById;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranch.Profiles;
internal class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PharmacyBranchEntity, CreatePharmacyBranchCommandRequest>().ReverseMap();
        CreateMap<PharmacyBranchEntity, UpdatePharmacyBranchCommandRequest>().ReverseMap();
        CreateMap<PharmacyBranchEntity, GetByIdPharmacyBranchQueryResponse>().ReverseMap();
        CreateMap<List<PharmacyBranchEntity>, GetAllPharmacyBranchQueryResponse>().ReverseMap();

    }
}
