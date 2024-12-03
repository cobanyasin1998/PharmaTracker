using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace RefreshTokenService.Application.Features.RefreshToken.Queries.GetById;

public class GetByIdRefreshTokenQueryRequest : IRequest<IResponse<GetByIdRefreshTokenQueryResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}