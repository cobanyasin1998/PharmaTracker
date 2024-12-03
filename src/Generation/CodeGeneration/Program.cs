using System;
using System.IO;
using System.Threading.Tasks;

Console.WriteLine("Switch to service name:");
Console.WriteLine("1. PharmacyService");
Console.WriteLine("2. IdentityService");

string? serviceName = Console.ReadLine() switch
{
    "1" => "PharmacyService",
    "2" => "IdentityService",
    _ => null
};

if (string.IsNullOrEmpty(serviceName))
{
    Console.WriteLine("Invalid service selection. Please try again.");
    return;
}

Console.WriteLine("Enter the entity name (e.g., PharmacyBranch):");
string? entityName = Console.ReadLine()?.Trim();

if (string.IsNullOrWhiteSpace(entityName))
{
    Console.WriteLine("Entity name cannot be empty! Please try again.");
    return;
}

try
{
    await GenerateCodeFilesAsync(serviceName, entityName);
    Console.WriteLine("Code generation completed successfully!");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred during code generation: {ex.Message}");
}

static async Task GenerateCodeFilesAsync(string serviceName, string entityName)
{
    string basePath = Path.Combine(
        @"C:\Users\Yasin\source\repos\PharmaTracker\src",
        serviceName);

    var paths = new[]
    {
        new { Type = "Create", Path = $"Core\\{serviceName}.Application\\Features\\{entityName}\\Commands\\Create" },
        new { Type = "Update", Path = $"Core\\{serviceName}.Application\\Features\\{entityName}\\Commands\\Update" },
        new { Type = "Delete", Path = $"Core\\{serviceName}.Application\\Features\\{entityName}\\Commands\\Delete" },
        new { Type = "Constants", Path = $"Core\\{serviceName}.Application\\Features\\{entityName}\\Constants" },
        new { Type = "Profiles", Path = $"Core\\{serviceName}.Application\\Features\\{entityName}\\Profiles" },
        new { Type = "GetAll", Path = $"Core\\{serviceName}.Application\\Features\\{entityName}\\Queries\\GetAll" },
        new { Type = "GetById", Path = $"Core\\{serviceName}.Application\\Features\\{entityName}\\Queries\\GetById" },
        new { Type = "RulesAbstractions", Path = $"Core\\{serviceName}.Application\\Features\\{entityName}\\Rules\\Abstractions" },
        new { Type = "Rules", Path = $"Core\\{serviceName}.Application\\Features\\{entityName}\\Rules" }
    };

    // Create directories
    foreach (var item in paths)
    {
        Directory.CreateDirectory(Path.Combine(basePath, item.Path));
    }

    // Define file templates and tasks
    var tasks = new[]
    {
        CreateFileAsync(Path.Combine(basePath, paths[0].Path, $"Create{entityName}CommandHandler.cs"), GenerateCreateHandlerTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[0].Path, $"Create{entityName}CommandRequest.cs"), GenerateCreateRequestTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[0].Path, $"Create{entityName}CommandResponse.cs"), GenerateCreateResponseTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[0].Path, $"Create{entityName}CommandValidator.cs"), GenerateCreateValidatorTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[1].Path, $"Update{entityName}CommandHandler.cs"), GenerateUpdateHandlerTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[1].Path, $"Update{entityName}CommandRequest.cs"), GenerateUpdateRequestTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[1].Path, $"Update{entityName}CommandResponse.cs"), GenerateUpdateResponseTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[1].Path, $"Update{entityName}CommandValidator.cs"), GenerateUpdateValidatorTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[2].Path, $"Delete{entityName}CommandHandler.cs"), GenerateDeleteHandlerTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[2].Path, $"Delete{entityName}CommandRequest.cs"), GenerateDeleteRequestTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[2].Path, $"Delete{entityName}CommandResponse.cs"), GenerateDeleteResponseTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[3].Path, $"{entityName}Constants.cs"), GenerateConstantsTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[4].Path, $"MappingProfile.cs"), GenerateMappingProfileTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[5].Path, $"GetAll{entityName}QueryHandler.cs"), GenerateGetAllHandlerTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[5].Path, $"GetAll{entityName}QueryRequest.cs"), GenerateGetAllRequestTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[5].Path, $"GetAll{entityName}QueryResponse.cs"), GenerateGetAllResponseTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[5].Path, $"GetAll{entityName}QueryResponseItemDto.cs"), GenerateGetAllResponseItemDtoTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[6].Path, $"GetById{entityName}QueryHandler.cs"), GenerateGetByIdHandlerTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[6].Path, $"GetById{entityName}QueryRequest.cs"), GenerateGetByIdRequestTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[6].Path, $"GetById{entityName}QueryResponse.cs"), GenerateGetByIdResponseTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[7].Path, $"I{entityName}BusinessRule.cs"), GenerateRulesAbsTemplate(entityName)),
        CreateFileAsync(Path.Combine(basePath, paths[8].Path, $"{entityName}BusinessRule.cs"), GenerateRulesTemplate(entityName))
    };

    // Wait for all tasks to complete
    await Task.WhenAll(tasks);
}

static async Task CreateFileAsync(string filePath, string content)
{
    await File.WriteAllTextAsync(filePath, content);
}
static string GenerateCreateHandlerTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Commands.Create;
                
                
                
                public class Create{{entityName}}CommandHandler : IRequestHandler<Create{{entityName}}CommandRequest, IResponse<Create{{entityName}}CommandResponse, GeneralErrorDto>>
                {
                    private readonly IMapper _mapper;
                    private readonly IDataProtectService _dataProtectService;
                    private readonly IUnitOfWork _unitOfWork;

                    public Create{{entityName}}CommandHandler(IMapper mapper, IDataProtectService dataProtectService)
                    {
                        _mapper = mapper;
                        _dataProtectService = dataProtectService;
                        _unitOfWork = unitOfWork;
                    }

                    public async Task<IResponse<Create{{entityName}}CommandResponse, GeneralErrorDto>> Handle(Create{{entityName}}CommandRequest request, CancellationToken cancellationToken)
                    {
                       

                        {{entityName}}Entity entity = _mapper.Map<Create{{entityName}}CommandRequest, {{entityName}}Entity>(request);

                        await _unitOfWork.{{entityName}}WriteRepository.AddAsync(entity);
                        await _unitOfWork.SaveChangesAsync(cancellationToken);

                        return Response<Create{{entityName}}CommandResponse, GeneralErrorDto>
                            .CreateSuccess(new Create{{entityName}}CommandResponse(_dataProtectService.Encrypt(entity.Id)));
                    }
                }

                """;
}
static string GenerateCreateRequestTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Commands.Create;
                
                public class Create{{entityName}}CommandRequest : IRequest<IResponse<Create{{entityName}}CommandResponse, GeneralErrorDto>>
                {
                   
                }
                """;
}
static string GenerateCreateResponseTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Commands.Create;
                
                public class Create{{entityName}}CommandResponse
                {
                  
                }
                """;
}
static string GenerateCreateValidatorTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Commands.Create;
                
                public class Create{{entityName}}CommandValidator : AbstractValidator<Create{{entityName}}CommandRequest>
                {
                    public Create{{entityName}}CommandValidator()
                    {
                       
                    }
                }
                """;
}
static string GenerateUpdateHandlerTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Commands.Update;
                
                
                
                public class Update{{entityName}}CommandHandler : IRequestHandler<Update{{entityName}}CommandRequest, IResponse<Update{{entityName}}CommandResponse, GeneralErrorDto>>
                {
                    private readonly IMapper _mapper;
                    private readonly IDataProtectService _dataProtectService;
                    private readonly IUnitOfWork _unitOfWork;
                    public Update{{entityName}}CommandHandler(IMapper mapper, IDataProtectService dataProtectService)
                    {
                        _mapper = mapper;
                        _dataProtectService = dataProtectService;
                        _unitOfWork = unitOfWork;
                    }
                    public async Task<IResponse<Update{{entityName}}CommandResponse, GeneralErrorDto>> Handle(Update{{entityName}}CommandRequest request, CancellationToken cancellationToken)
                    {
                       
                        {{entityName}}Entity entity = _mapper.Map<Update{{entityName}}CommandRequest, {{entityName}}Entity>(request);
                        await _unitOfWork.{{entityName}}WriteRepository.UpdateAsync(entity);
                        await _unitOfWork.SaveChangesAsync(cancellationToken);
                        return Response<Update{{entityName}}CommandResponse, GeneralErrorDto>
                            .CreateSuccess(new Update{{entityName}}CommandResponse(_dataProtectService.Encrypt(entity.Id)));
                    }
                }
                """;
}
static string GenerateUpdateRequestTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Commands.Update;
                
                public class Update{{entityName}}CommandRequest : IRequest<IResponse<Update{{entityName}}CommandResponse, GeneralErrorDto>>
                {
                   
                }
                """;
}
static string GenerateUpdateResponseTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Commands.Update;
                
                public class Update{{entityName}}CommandResponse
                {
                  
                }
                """;
}
static string GenerateUpdateValidatorTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Commands.Update;
                
                public class Update{{entityName}}CommandValidator : AbstractValidator<Update{{entityName}}CommandRequest>
                {
                    public Update{{entityName}}CommandValidator()
                    {
                       
                    }
                }
                """;
}
static string GenerateDeleteHandlerTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Commands.Delete;
                
                
                
                public class Delete{{entityName}}CommandHandler : IRequestHandler<Delete{{entityName}}CommandRequest, IResponse<Delete{{entityName}}CommandResponse, GeneralErrorDto>>
                {
                    private readonly IMapper _mapper;
                    private readonly IDataProtectService _dataProtectService;
                    private readonly IUnitOfWork _unitOfWork;
                    public Delete{{entityName}}CommandHandler(IMapper mapper, IDataProtectService dataProtectService)
                    {
                        _mapper = mapper;
                        _dataProtectService = dataProtectService;
                        _unitOfWork = unitOfWork;
                    }
                    public async Task<IResponse<Delete{{entityName}}CommandResponse, GeneralErrorDto>> Handle(Delete{{entityName}}CommandRequest request, CancellationToken cancellationToken)
                    {
                       
                        await _unitOfWork.{{entityName}}WriteRepository.DeleteAsync(request.Id);
                        await _unitOfWork.SaveChangesAsync(cancellationToken);
                        return Response<Delete{{entityName}}CommandResponse, GeneralErrorDto>
                            .CreateSuccess(new Delete{{entityName}}CommandResponse());
                    }
                }
                """;
}
static string GenerateDeleteRequestTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Commands.Delete;
                
                public class Delete{{entityName}}CommandRequest : IRequest<IResponse<Delete{{entityName}}CommandResponse, GeneralErrorDto>>
                {
                    public Guid Id { get; set; }
                }
                """;
}
static string GenerateDeleteResponseTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Commands.Delete;
                
                public class Delete{{entityName}}CommandResponse
                {
                  
                }
                """;
}
static string GenerateConstantsTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Constants;
                
                public static class {{entityName}}Constants
                {
                    public const string {{entityName}} = "{{entityName}}";
                }
                """;
}
static string GenerateMappingProfileTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Profiles;
                
                public class MappingProfile : Profile
                {
                    public MappingProfile()
                    {
                        CreateMap<Create{{entityName}}CommandRequest, {{entityName}}Entity>();
                        CreateMap<Update{{entityName}}CommandRequest, {{entityName}}Entity>();
                        CreateMap<{{entityName}}Entity, GetAll{{entityName}}QueryResponseItemDto>();
                        CreateMap<{{entityName}}Entity, GetById{{entityName}}QueryResponseItemDto>();
                    }
                }
                """;
}
static string GenerateGetAllHandlerTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Queries.GetAll;
                
                
                
                public class GetAll{{entityName}}QueryHandler : IRequestHandler<GetAll{{entityName}}QueryRequest, IResponse<GetAll{{entityName}}QueryResponse, GeneralErrorDto>>
                {
                    private readonly IMapper _mapper;
                    private readonly IUnitOfWork _unitOfWork;
                    public GetAll{{entityName}}QueryHandler(IMapper mapper)
                    {
                        _mapper = mapper;
                        _unitOfWork = unitOfWork;
                    }
                    public async Task<IResponse<GetAll{{entityName}}QueryResponse, GeneralErrorDto>> Handle(GetAll{{entityName}}QueryRequest request, CancellationToken cancellationToken)
                    {
                        var entities = await _unitOfWork.{{entityName}}ReadRepository.GetAllAsync();
                        return Response<GetAll{{entityName}}QueryResponse, GeneralErrorDto>
                            .CreateSuccess(new GetAll{{entityName}}QueryResponse(_mapper.Map<List<GetAll{{entityName}}QueryResponseItemDto>>(entities)));
                    }
                }
                """;
}
static string GenerateGetAllRequestTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Queries.GetAll;
                
                public class GetAll{{entityName}}QueryRequest : IRequest<IResponse<GetAll{{entityName}}QueryResponse, GeneralErrorDto>>
                {
                   
                }
                """;
}
static string GenerateGetAllResponseTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Queries.GetAll;
                
                public class GetAll{{entityName}}QueryResponse
                {
                    public List<GetAll{{entityName}}QueryResponseItemDto> {{entityName}}s { get; set; }
                    public GetAll{{entityName}}QueryResponse(List<GetAll{{entityName}}QueryResponseItemDto> {{entityName}}s)
                    {
                        {{entityName}}s = {{entityName}}s;
                    }
                }
                """;
}
static string GenerateGetAllResponseItemDtoTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Queries.GetAll;
                
                public class GetAll{{entityName}}QueryResponseItemDto
                {
                  
                }
                """;
}
static string GenerateGetByIdHandlerTemplate(string entityName)
{
    return "";
}
static string GenerateGetByIdRequestTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Queries.GetById;
                
                public class GetById{{entityName}}QueryRequest : IRequest<IResponse<GetById{{entityName}}QueryResponse, GeneralErrorDto>>
                {
                    public Guid Id { get; set; }
                }
                """;
}
static string GenerateGetByIdResponseTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Queries.GetById;
                
                public class GetById{{entityName}}QueryResponse
                {
                  
                }
                """;
}
static string GenerateRulesAbsTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Rules.Abstractions;
                
                public interface I{{entityName}}BusinessRule
                {
                   
                }
                """;
}
static string GenerateRulesTemplate(string entityName)
{
    return
        $$"""
                namespace {{entityName}}Service.Application.Features.{{entityName}}.Rules;
                
                public class {{entityName}}BusinessRule : I{{entityName}}BusinessRule
                {
                    private readonly IUnitOfWork _unitOfWork;
                    public {{entityName}}BusinessRule(IUnitOfWork unitOfWork)
                    {
                        _unitOfWork = unitOfWork;
                    }
                }
                """;
}