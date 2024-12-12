using Microsoft.AspNetCore.Authorization;
using PharmacyService.Application.Features.Pharmacy.Commands.Create;
using PharmacyService.Application.Features.Pharmacy.Commands.Delete;
using PharmacyService.Application.Features.Pharmacy.Commands.Update;
using PharmacyService.Application.Features.Pharmacy.Queries.GetAll;
using PharmacyService.Application.Features.Pharmacy.Queries.GetById;

namespace PharmacyService.Presentation.Controllers;


public class PharmacyController : Coban.Presentation.Controllers.Abstractions.AbstractController<
    CreatePharmacyCommandRequest, 
    UpdatePharmacyCommandRequest, 
    DeletePharmacyCommandRequest,
    GetByIdPharmacyQueryRequest,
    GetAllPharmacyQueryRequest
    >
{
   
}
