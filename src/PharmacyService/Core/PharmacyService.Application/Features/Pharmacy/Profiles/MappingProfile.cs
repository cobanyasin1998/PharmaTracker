using AutoMapper;
using PharmacyService.Application.Features.Pharmacy.Commands.Create;
using PharmacyService.Application.Features.Pharmacy.Commands.Update;
using PharmacyService.Application.Features.Pharmacy.Queries.GetAll;
using PharmacyService.Application.Features.Pharmacy.Queries.GetById;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.Pharmacy.Profiles;

internal class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<PharmacyEntity, CreatePharmacyCommandRequest>().ReverseMap();
        CreateMap<PharmacyEntity, GetByIdPharmacyQueryResponse>().ReverseMap();
        CreateMap<List<PharmacyEntity>, GetAllPharmacyQueryResponse>().ReverseMap();


        CreateMap<UpdatePharmacyCommandRequest, PharmacyEntity>()
           .ForMember(dest => dest.Id, opt => opt.Ignore())
           .ForMember(dest => dest.CreatedTime, opt => opt.Ignore())
           .ForMember(dest => dest.CreatedUserId, opt => opt.Ignore())
           .ForMember(dest => dest.UpdatedTime, opt => opt.Ignore())
           .ForMember(dest => dest.UpdatedUserId, opt => opt.Ignore());

           
    }
}
