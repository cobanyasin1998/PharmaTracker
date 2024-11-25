using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using PharmacyService.Application.Features.Pharmacy.Commands.Create;
using PharmacyService.Application.Features.Pharmacy.Commands.Delete;
using PharmacyService.Application.Features.Pharmacy.Commands.Update;
using PharmacyService.Application.Features.Pharmacy.Queries.GetAll;
using PharmacyService.Application.Features.Pharmacy.Queries.GetById;

namespace PharmacyService.Presentation.Controllers
{

    public class PharmacyController : Coban.Presentation.Controllers.Abstractions.AbstractController<
        CreatePharmacyCommandRequest, IResponse<CreatePharmacyCommandResponse, GeneralErrorDTO>,
        UpdatePharmacyCommandRequest, IResponse<UpdatePharmacyCommandResponse, GeneralErrorDTO>,
        DeletePharmacyCommandRequest, IResponse<DeletePharmacyCommandResponse, GeneralErrorDTO>,
        GetByIdPharmacyQueryRequest, IResponse<GetByIdPharmacyQueryResponse, GeneralErrorDTO>,
        GetAllPharmacyQueryRequest, IResponse<GetAllPharmacyQueryResponse, GeneralErrorDTO>
        >
    {
    }
}
