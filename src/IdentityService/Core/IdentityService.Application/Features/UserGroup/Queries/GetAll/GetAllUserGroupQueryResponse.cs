namespace UserGroupService.Application.Features.UserGroup.Queries.GetAll;

public class GetAllUserGroupQueryResponse
{
    public List<GetAllUserGroupQueryResponseItemDto> UserGroups { get; set; }
    public GetAllUserGroupQueryResponse(List<GetAllUserGroupQueryResponseItemDto> UserGroups)
    {
        UserGroups = UserGroups;
    }
}