using Microsoft.AspNetCore.Mvc;

namespace Coban.Presentation.Controllers.Abstractions.Base.BaseCRUD;

public interface IUpdateController<TUpdateReq> : IBaseController
{
    Task<IActionResult> Update([FromBody] TUpdateReq request);
}
