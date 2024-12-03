using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthFormService.Application.Features.AuthForm.Queries.GetById;

public class GetByIdAuthFormQueryRequest : IRequest<IResponse<GetByIdAuthFormQueryResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}