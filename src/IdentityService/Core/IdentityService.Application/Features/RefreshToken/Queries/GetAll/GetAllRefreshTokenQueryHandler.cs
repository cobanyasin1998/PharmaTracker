using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace RefreshTokenService.Application.Features.RefreshToken.Queries.GetAll;



public class GetAllRefreshTokenQueryHandler : IRequestHandler<GetAllRefreshTokenQueryRequest, IResponse<GetAllRefreshTokenQueryResponse, GeneralErrorDto>>
{
 
    public async Task<IResponse<GetAllRefreshTokenQueryResponse, GeneralErrorDto>> Handle(GetAllRefreshTokenQueryRequest request, CancellationToken cancellationToken)
    {
        throw new Exception("Not Implemented");

    }
}