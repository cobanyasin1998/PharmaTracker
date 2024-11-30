using Microsoft.AspNetCore.Mvc;

namespace Coban.Presentation.Controllers.Abstractions.Base.BaseCRUD;

public interface ICreateController<TCreateReq> : IBaseController
{
    Task<IActionResult> Create([FromBody] TCreateReq request);
}
