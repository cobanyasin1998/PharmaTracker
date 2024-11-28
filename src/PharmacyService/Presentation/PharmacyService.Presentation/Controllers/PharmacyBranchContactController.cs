using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using PharmacyService.Application.Features.PharmacyBranchContact.Commands.Create;
using PharmacyService.Application.Features.PharmacyBranchContact.Commands.Delete;
using PharmacyService.Application.Features.PharmacyBranchContact.Queries.GetAll;
using PharmacyService.Application.Features.PharmacyBranchContact.Queries.GetById;

namespace PharmacyService.Presentation.Controllers;

public class PharmacyBranchContactController : Coban.Presentation.Controllers.Abstractions.AbstractController<
   CreatePharmacyBranchContactCommandRequest, IResponse<CreatePharmacyBranchContactCommandResponse, GeneralErrorDto>,
   DeletePharmacyBranchContactCommandRequest, IResponse<DeletePharmacyBranchContactCommandResponse, GeneralErrorDto>,
   DeletePharmacyBranchContactCommandRequest, IResponse<DeletePharmacyBranchContactCommandResponse, GeneralErrorDto>,
   GetByIdPharmacyBranchContactQueryRequest, IResponse<GetByIdPharmacyBranchContactQueryResponse, GeneralErrorDto>,
   GetAllPharmacyBranchContactQueryRequest, IResponse<GetAllPharmacyBranchContactQueryResponse, GeneralErrorDto>
   >
{

}
