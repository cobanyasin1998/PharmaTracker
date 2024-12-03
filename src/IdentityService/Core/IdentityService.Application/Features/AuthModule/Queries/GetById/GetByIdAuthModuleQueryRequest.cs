using Coban.Application.Responses.Base.Abstractions;
using Coban.GeneralDto;
using MediatR;

namespace AuthModuleService.Application.Features.AuthModule.Queries.GetById;

public class GetByIdAuthModuleQueryRequest : IRequest<IResponse<GetByIdAuthModuleQueryResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}