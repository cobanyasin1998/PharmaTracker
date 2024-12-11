using Coban.Application.Requests;
using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace IdentityService.Application.Features.User.Queries.GetById;

public class GetByIdUserQueryRequest : BaseRequest, IRequest<IResponse<GetByIdUserQueryResponse, GeneralErrorDto>>
{

}