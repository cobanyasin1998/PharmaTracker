using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Create;
using PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Delete;
using PharmacyService.Application.Features.PharmacyBranchAddress.Commands.Update;
using PharmacyService.Application.Features.PharmacyBranchAddress.Queries.GetAll;
using PharmacyService.Application.Features.PharmacyBranchAddress.Queries.GetById;

namespace PharmacyService.Presentation.Controllers;

public class PharmacyBranchAddressController : Coban.Presentation.Controllers.Abstractions.AbstractController<
  CreatePharmacyBranchAddressCommandRequest, IResponse<CreatePharmacyBranchAddressCommandResponse, GeneralErrorDto>,
  UpdatePharmacyBranchAddressCommandRequest, IResponse<UpdatePharmacyBranchAddressCommandResponse, GeneralErrorDto>,
  DeletePharmacyBranchAddressCommandRequest, IResponse<DeletePharmacyBranchAddressCommandResponse, GeneralErrorDto>,
  GetByIdPharmacyBranchAddressQueryRequest, IResponse<GetByIdPharmacyBranchAddressQueryResponse, GeneralErrorDto>,
  GetAllPharmacyBranchAddressQueryRequest, IResponse<GetAllPharmacyBranchAddressQueryResponse, GeneralErrorDto>
  >
{

}
