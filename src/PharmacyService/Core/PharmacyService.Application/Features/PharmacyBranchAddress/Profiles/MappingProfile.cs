using AutoMapper;
using PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Create;
using PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Update;
using PharmacyService.Application.Features.PharmacyBranchAddress.Queries.GetAll;
using PharmacyService.Application.Features.PharmacyBranchAddress.Queries.GetById;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.PharmacyBranchAddress.Profiles;

internal class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PharmacyBranchAddressEntity, CreatePharmacyBranchAddressCommandRequest>().ReverseMap();
        CreateMap<PharmacyBranchAddressEntity, UpdatePharmacyBranchAddressCommandRequest>().ReverseMap();
        CreateMap<PharmacyBranchAddressEntity, GetByIdPharmacyBranchAddressQueryResponse>().ReverseMap();
        CreateMap<List<PharmacyBranchAddressEntity>, GetAllPharmacyBranchAddressQueryResponse>().ReverseMap();

    }
}
