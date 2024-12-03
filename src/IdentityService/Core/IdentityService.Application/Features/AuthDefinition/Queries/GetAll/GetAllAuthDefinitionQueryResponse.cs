namespace AuthDefinitionService.Application.Features.AuthDefinition.Queries.GetAll;

public class GetAllAuthDefinitionQueryResponse
{
    public List<GetAllAuthDefinitionQueryResponseItemDto> AuthDefinitions { get; set; }
    public GetAllAuthDefinitionQueryResponse(List<GetAllAuthDefinitionQueryResponseItemDto> AuthDefinitions)
    {
        AuthDefinitions = AuthDefinitions;
    }
}