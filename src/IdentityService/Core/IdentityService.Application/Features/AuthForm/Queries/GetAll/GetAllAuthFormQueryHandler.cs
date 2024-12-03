using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthFormService.Application.Features.AuthForm.Queries.GetAll;



public class GetAllAuthFormQueryHandler : IRequestHandler<GetAllAuthFormQueryRequest, IResponse<GetAllAuthFormQueryResponse, GeneralErrorDto>>
{
    
    public async Task<IResponse<GetAllAuthFormQueryResponse, GeneralErrorDto>> Handle(GetAllAuthFormQueryRequest request, CancellationToken cancellationToken)
    {
        throw new Exception("Not Implemented");

    }
}