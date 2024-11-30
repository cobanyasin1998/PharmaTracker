using PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Create;
using PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Delete;
using PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Update;
using PharmacyService.Application.Features.PharmacyBranchAddress.Queries.GetAll;
using PharmacyService.Application.Features.PharmacyBranchAddress.Queries.GetById;

namespace PharmacyService.Presentation.Controllers;

public class PharmacyBranchAddressController : Coban.Presentation.Controllers.Abstractions.AbstractController<
  CreatePharmacyBranchAddressCommandRequest,
  UpdatePharmacyBranchAddressCommandRequest, 
  DeletePharmacyBranchAddressCommandRequest, 
  GetByIdPharmacyBranchAddressQueryRequest,
  GetAllPharmacyBranchAddressQueryRequest
  >
{

}
