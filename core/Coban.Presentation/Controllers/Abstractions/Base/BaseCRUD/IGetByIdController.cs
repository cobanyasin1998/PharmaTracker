using Microsoft.AspNetCore.Mvc;

namespace Coban.Presentation.Controllers.Abstractions.Base.BaseCRUD;

public interface IGetByIdController<TGetByIdReq> : IBaseController
{
    Task<IActionResult> GetById([FromBody] TGetByIdReq getByIdRequest);
}
