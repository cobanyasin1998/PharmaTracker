using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace UserService.Application.Features.User.Queries.GetById;

public class GetByIdUserQueryRequest : IRequest<IResponse<GetByIdUserQueryResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}