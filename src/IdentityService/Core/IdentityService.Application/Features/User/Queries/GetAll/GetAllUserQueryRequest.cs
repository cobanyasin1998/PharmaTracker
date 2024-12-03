using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace UserService.Application.Features.User.Queries.GetAll;

public class GetAllUserQueryRequest : IRequest<IResponse<GetAllUserQueryResponse, GeneralErrorDto>>
{
   
}