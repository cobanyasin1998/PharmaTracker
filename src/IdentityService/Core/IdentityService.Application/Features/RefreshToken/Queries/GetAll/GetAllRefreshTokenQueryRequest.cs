using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace RefreshTokenService.Application.Features.RefreshToken.Queries.GetAll;

public class GetAllRefreshTokenQueryRequest : IRequest<IResponse<GetAllRefreshTokenQueryResponse, GeneralErrorDto>>
{
   
}