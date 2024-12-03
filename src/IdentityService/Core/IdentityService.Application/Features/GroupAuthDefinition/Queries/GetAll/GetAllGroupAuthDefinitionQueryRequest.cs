using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace GroupAuthDefinitionService.Application.Features.GroupAuthDefinition.Queries.GetAll;

public class GetAllGroupAuthDefinitionQueryRequest : IRequest<IResponse<GetAllGroupAuthDefinitionQueryResponse, GeneralErrorDto>>
{
   
}