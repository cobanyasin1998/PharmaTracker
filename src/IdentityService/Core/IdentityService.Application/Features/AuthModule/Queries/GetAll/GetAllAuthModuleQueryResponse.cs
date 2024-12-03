namespace AuthModuleService.Application.Features.AuthModule.Queries.GetAll;

public class GetAllAuthModuleQueryResponse
{
    public List<GetAllAuthModuleQueryResponseItemDto> AuthModules { get; set; }
    public GetAllAuthModuleQueryResponse(List<GetAllAuthModuleQueryResponseItemDto> AuthModules)
    {
        AuthModules = AuthModules;
    }
}