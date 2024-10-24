using PharmacyService.Application.Concrete.Response;

namespace PharmacyService.Application.Features.Pharmacy.Commands.Create;

public class CreatePharmacyCommandResponse : ResponseCustom
{
    public long Id { get; set; }
}
