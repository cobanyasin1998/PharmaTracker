using Microsoft.AspNetCore.Mvc;
using PharmacyService.API.Controllers.Base;
using PharmacyService.Application.Features.Pharmacy.Commands.Create;

namespace PharmacyService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreatePharmacy([FromBody] CreatePharmacyCommandRequest request)
        {
            var response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
