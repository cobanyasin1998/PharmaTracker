using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthDefinitionService.Application.Features.AuthDefinition.Queries.GetById;

public class GetByIdAuthDefinitionQueryRequest : IRequest<IResponse<GetByIdAuthDefinitionQueryResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}