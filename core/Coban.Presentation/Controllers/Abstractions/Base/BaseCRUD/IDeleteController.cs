using Microsoft.AspNetCore.Mvc;

namespace Coban.Presentation.Controllers.Abstractions.Base.BaseCRUD;

public interface IDeleteController<TDeleteReq, TDeleteRes> : IBaseController
{
    Task<IActionResult> Delete([FromBody] TDeleteReq deleteRequest);
}
