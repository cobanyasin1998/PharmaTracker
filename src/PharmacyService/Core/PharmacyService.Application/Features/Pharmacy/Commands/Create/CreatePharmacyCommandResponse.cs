using PharmacyService.Application.Concrete.Response;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Create;

public class CreatePharmacyCommandResponse : ResponseWithErrors
{
    public long Id { get; set; }
}
