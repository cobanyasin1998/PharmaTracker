using Microsoft.AspNetCore.Mvc;

namespace Coban.Presentation.Controllers.Abstractions.Base.BaseCRUD;

public interface IGetAllController<TGetAllReq, TGetAllRes> : IBaseController
{
    Task<IActionResult> GetAll([FromBody] TGetAllReq request);
}