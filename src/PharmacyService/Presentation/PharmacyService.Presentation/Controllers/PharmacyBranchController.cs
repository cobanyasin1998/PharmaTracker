using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using PharmacyService.Application.Features.PharmacyBranch.Commands.Create;
using PharmacyService.Application.Features.PharmacyBranch.Commands.Delete;
using PharmacyService.Application.Features.PharmacyBranch.Commands.Update;
using PharmacyService.Application.Features.PharmacyBranch.Queries.GetAll;
using PharmacyService.Application.Features.PharmacyBranch.Queries.GetById;

namespace PharmacyService.Presentation.Controllers;

public class PharmacyBranchController : Coban.Presentation.Controllers.Abstractions.AbstractController<
  CreatePharmacyBranchCommandRequest, IResponse<CreatePharmacyBranchCommandResponse, GeneralErrorDto>,
  UpdatePharmacyBranchCommandRequest, IResponse<UpdatePharmacyBranchCommandResponse, GeneralErrorDto>,
  DeletePharmacyBranchCommandRequest, IResponse<DeletePharmacyBranchCommandResponse, GeneralErrorDto>,
  GetByIdPharmacyBranchQueryRequest, IResponse<GetByIdPharmacyBranchQueryResponse, GeneralErrorDto>,
  GetAllPharmacyBranchQueryRequest, IResponse<GetAllPharmacyBranchQueryResponse, GeneralErrorDto>
  >
{
   
}
