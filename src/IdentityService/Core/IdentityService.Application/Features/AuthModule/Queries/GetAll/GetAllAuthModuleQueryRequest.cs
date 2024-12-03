using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthModuleService.Application.Features.AuthModule.Queries.GetAll;

public class GetAllAuthModuleQueryRequest : IRequest<IResponse<GetAllAuthModuleQueryResponse, GeneralErrorDto>>
{
   
}