using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;
using SharedLibrary.SyncDto.Identity.User;

namespace IdentityService.Application.Features.Comm.Queries.GetByBasicUserId;

public class GetByBasicUserIdQueryRequest : IRequest<IResponse<GetByBasicUserIdQueryResponse, GeneralErrorDto>>
{
    public long UserId { get; set; }
}
