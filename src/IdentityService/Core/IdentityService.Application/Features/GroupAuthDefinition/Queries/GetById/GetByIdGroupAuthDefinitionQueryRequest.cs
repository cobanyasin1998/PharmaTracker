using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace GroupAuthDefinitionService.Application.Features.GroupAuthDefinition.Queries.GetById;

public class GetByIdGroupAuthDefinitionQueryRequest : IRequest<IResponse<GetByIdGroupAuthDefinitionQueryResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}