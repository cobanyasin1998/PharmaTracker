using AutoMapper;
using MediatR;
using PharmacyService.Application.BaseRepository.Pharmacy;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Create;

public class CreateProductCommandHandler(IPharmacyWriteRepository _pharmacyWriteRepository,IMapper _mapper)
    : IRequestHandler<CreatePharmacyCommandRequest, CreatePharmacyCommandResponse>
{

    public async Task<CreatePharmacyCommandResponse> Handle(CreatePharmacyCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<CreatePharmacyCommandRequest, PharmacyEntity>(request);
        await _pharmacyWriteRepository.AddAsync(entity);
        await _pharmacyWriteRepository.SaveAsync();
        return new CreatePharmacyCommandResponse() { Id = entity.Id };
    }
}
