namespace GroupService.Application.Features.Group.Queries.GetAll;

public class GetAllGroupQueryResponse
{
    public List<GetAllGroupQueryResponseItemDto> Groups { get; set; }
    public GetAllGroupQueryResponse(List<GetAllGroupQueryResponseItemDto> Groups)
    {
        Groups = Groups;
    }
}