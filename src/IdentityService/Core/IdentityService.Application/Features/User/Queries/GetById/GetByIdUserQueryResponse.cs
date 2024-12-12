using Coban.Application.Responses;

namespace IdentityService.Application.Features.User.Queries.GetById;

public class GetByIdUserQueryResponse : BaseResponse
{
    public string FirstName { get; set; }
}