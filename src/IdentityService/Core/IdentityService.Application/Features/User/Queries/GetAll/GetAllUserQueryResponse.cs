namespace UserService.Application.Features.User.Queries.GetAll;

public class GetAllUserQueryResponse
{
    public List<GetAllUserQueryResponseItemDto> Users { get; set; }
    public GetAllUserQueryResponse(List<GetAllUserQueryResponseItemDto> Users)
    {
        Users = Users;
    }
}