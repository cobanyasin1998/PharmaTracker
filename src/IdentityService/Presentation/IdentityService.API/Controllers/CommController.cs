using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using Coban.Presentation.Controllers.Abstractions;
using IdentityService.Application.Features.Comm.Queries.GetByBasicUserId;
using IdentityService.Application.Features.User.Queries.GetById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.SyncDto.Identity.User;

namespace IdentityService.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CommController : BaseController
    {
        [HttpPost]
        public virtual async Task<IActionResult> GetByUser([FromBody] GetByBasicUserIdQueryRequest getByBasicUserIdQueryRequest)
        {
            IResponse<GetByBasicUserIdQueryResponse, GeneralErrorDto>? response = await Mediator!.Send(getByBasicUserIdQueryRequest);
            return HandleResponse((IResponseBase)response);
        }
    }
}
