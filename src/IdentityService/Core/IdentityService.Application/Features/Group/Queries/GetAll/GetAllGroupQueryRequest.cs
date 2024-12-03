using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace GroupService.Application.Features.Group.Queries.GetAll;

public class GetAllGroupQueryRequest : IRequest<IResponse<GetAllGroupQueryResponse, GeneralErrorDto>>
{
   
}