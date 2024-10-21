using MediatR;
using PharmacyService.Application.BaseRepository.Pharmacy;
using PharmacyService.Domain.Entities;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Create;

public class CreateProductCommandHandler(IPharmacyWriteRepository _pharmacyWriteRepository)
    : IRequestHandler<CreatePharmacyCommandRequest, CreatePharmacyCommandResponse>
{
    public async Task<CreatePharmacyCommandResponse> Handle(CreatePharmacyCommandRequest request, CancellationToken cancellationToken)
    {

        var pharmacyEntity = new PharmacyEntity()
        {
            Name = request.Name,
            Description = request.Description,
            Status = Domain.Enums.EStatus.Active
        };
        await _pharmacyWriteRepository.AddAsync(pharmacyEntity);
        await _pharmacyWriteRepository.SaveAsync();
        return new CreatePharmacyCommandResponse() { Id = pharmacyEntity.Id };
    }
}
