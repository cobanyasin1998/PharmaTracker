using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace UserService.Application.Features.User.Queries.GetAll;



public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, IResponse<GetAllUserQueryResponse, GeneralErrorDto>>
{
  
    public async Task<IResponse<GetAllUserQueryResponse, GeneralErrorDto>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
    {
        throw new Exception("Not Implemented");

    }
}