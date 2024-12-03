namespace GroupAuthDefinitionService.Application.Features.GroupAuthDefinition.Queries.GetAll;

public class GetAllGroupAuthDefinitionQueryResponse
{
    public List<GetAllGroupAuthDefinitionQueryResponseItemDto> GroupAuthDefinitions { get; set; }
    public GetAllGroupAuthDefinitionQueryResponse(List<GetAllGroupAuthDefinitionQueryResponseItemDto> GroupAuthDefinitions)
    {
        GroupAuthDefinitions = GroupAuthDefinitions;
    }
}