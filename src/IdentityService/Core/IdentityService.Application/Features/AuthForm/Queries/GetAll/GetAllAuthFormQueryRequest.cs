using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthFormService.Application.Features.AuthForm.Queries.GetAll;

public class GetAllAuthFormQueryRequest : IRequest<IResponse<GetAllAuthFormQueryResponse, GeneralErrorDto>>
{
   
}