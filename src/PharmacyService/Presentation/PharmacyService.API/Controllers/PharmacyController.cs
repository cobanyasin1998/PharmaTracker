using MediatR;
using PharmacyService.API.Controllers.Base;
using PharmacyService.Application.Features.Pharmacy.Commands.Create;
using PharmacyService.Application.Features.Pharmacy.Commands.Update;
using PharmacyService.Application.Features.Pharmacy.Queries.GetById;

namespace PharmacyService.API.Controllers
{
    public class PharmacyController : AbstractController<CreatePharmacyCommandRequest, UpdatePharmacyCommandRequest, GetByIdPharmacyQueryRequest, CreatePharmacyCommandResponse>
    {
    }
}
