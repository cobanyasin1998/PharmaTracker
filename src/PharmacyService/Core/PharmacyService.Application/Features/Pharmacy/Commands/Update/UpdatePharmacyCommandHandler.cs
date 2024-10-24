using AutoMapper;
using MediatR;
using PharmacyService.Application.BaseRepository.Pharmacy;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Update;

public class UpdatePharmacyCommandHandler(IPharmacyWriteRepository _pharmacyWriteRepository, IMapper _mapper)
    : IRequestHandler<UpdatePharmacyCommandRequest, UpdatePharmacyCommandResponse>
{

    public async Task<UpdatePharmacyCommandResponse> Handle(UpdatePharmacyCommandRequest request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<UpdatePharmacyCommandRequest, PharmacyEntity>(request);
        _pharmacyWriteRepository.Update(entity);
        await _pharmacyWriteRepository.SaveAsync();
        return new UpdatePharmacyCommandResponse() { Id = entity.Id };
    }
}

