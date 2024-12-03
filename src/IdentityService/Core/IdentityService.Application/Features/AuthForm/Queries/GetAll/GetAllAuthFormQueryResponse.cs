namespace AuthFormService.Application.Features.AuthForm.Queries.GetAll;

public class GetAllAuthFormQueryResponse
{
    public List<GetAllAuthFormQueryResponseItemDto> AuthForms { get; set; }
    public GetAllAuthFormQueryResponse(List<GetAllAuthFormQueryResponseItemDto> AuthForms)
    {
        AuthForms = AuthForms;
    }
}