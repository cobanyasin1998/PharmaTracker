using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace GroupService.Application.Features.Group.Queries.GetAll;



public class GetAllGroupQueryHandler : IRequestHandler<GetAllGroupQueryRequest, IResponse<GetAllGroupQueryResponse, GeneralErrorDto>>
{
  
    public async Task<IResponse<GetAllGroupQueryResponse, GeneralErrorDto>> Handle(GetAllGroupQueryRequest request, CancellationToken cancellationToken)
    {
        throw new Exception("Not Implemented");

    }
}