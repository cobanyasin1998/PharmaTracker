namespace GroupService.Application.Features.Group.Queries.GetById;

public class GetByIdGroupQueryRequest : IRequest<IResponse<GetByIdGroupQueryResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}