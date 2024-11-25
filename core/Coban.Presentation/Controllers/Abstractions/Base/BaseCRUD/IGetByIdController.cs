using Microsoft.AspNetCore.Mvc;

namespace Coban.Presentation.Controllers.Abstractions.Base.BaseCRUD;

public interface IGetByIdController<TGetByIdReq, TGetByIdRes> : IBaseController
{
    Task<IActionResult> GetById([FromBody] TGetByIdReq getByIdRequest);
}
