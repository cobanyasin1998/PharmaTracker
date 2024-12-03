using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthDefinitionService.Application.Features.AuthDefinition.Queries.GetAll;

public class GetAllAuthDefinitionQueryRequest : IRequest<IResponse<GetAllAuthDefinitionQueryResponse, GeneralErrorDto>>
{
   
}