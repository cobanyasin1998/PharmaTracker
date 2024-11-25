using Coban.Presentation.Controllers.Abstractions.Base;
using Microsoft.AspNetCore.Mvc;

namespace Coban.Presentation.Controllers.Abstractions.Base.BaseCRUD;

public interface IUpdateController<TUpdateReq, TUpdateRes> : IBaseController
{
    Task<IActionResult> Update([FromBody] TUpdateReq request);
}
