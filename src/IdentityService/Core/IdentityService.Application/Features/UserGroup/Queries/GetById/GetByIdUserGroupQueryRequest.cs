namespace UserGroupService.Application.Features.UserGroup.Queries.GetById;

public class GetByIdUserGroupQueryRequest : IRequest<IResponse<GetByIdUserGroupQueryResponse, GeneralErrorDto>>
{
    public Guid Id { get; set; }
}