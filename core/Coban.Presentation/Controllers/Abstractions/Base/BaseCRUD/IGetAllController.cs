using Microsoft.AspNetCore.Mvc;

namespace Coban.Presentation.Controllers.Abstractions.Base.BaseCRUD;

public interface IGetAllController<TGetAllReq> : IBaseController
{
    Task<IActionResult> GetAll([FromBody] TGetAllReq request);
}