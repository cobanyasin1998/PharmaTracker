Console.WriteLine("Enter the service name (e.g., Pharmacy, File): ");
string serviceName = Console.ReadLine();


Console.WriteLine("Enter the entity name (e.g., PharmacyBranch): ");
string entityName = Console.ReadLine();


if (string.IsNullOrWhiteSpace(entityName))
{
    Console.WriteLine("Entity name cannot be empty!");
    return;
}

GenerateCodeFiles(serviceName, entityName);
Console.WriteLine("Code generation completed!");

async void GenerateCodeFiles(string serviceName, string entityName)
{
    //string basePath = "C:\\Users\\Yasin\\source\\repos\\PharmaTracker\\src\\PharmacyService";
    //string entityPath = Path.Combine(basePath, "Core\\PharmacyService.Domain\\Entities");
    //string commandsPath = Path.Combine(basePath, $"Core\\PharmacyService.Application\\Features\\{entityName}\\Commands");
    //string constantsPath = Path.Combine(basePath, $"Core\\PharmacyService.Application\\Features\\{entityName}\\Constants");
    //string profilesPath = Path.Combine(basePath, $"Core\\PharmacyService.Application\\Features\\{entityName}\\Profiles");
    //string queriesPath = Path.Combine(basePath, $"Core\\PharmacyService.Application\\Features\\{entityName}\\Queries");
    //string rulesPath = Path.Combine(basePath, $"Core\\PharmacyService.Application\\Features\\{entityName}\\Rules");

    //Directory.CreateDirectory(entityPath);
    //Directory.CreateDirectory(commandsPath);
    //Directory.CreateDirectory(constantsPath);
    //Directory.CreateDirectory(profilesPath);
    //Directory.CreateDirectory(queriesPath);
    //Directory.CreateDirectory(rulesPath);

    ////string entityFile = Path.Combine(entityPath, $"{entityName}Entity.cs");
    ////await File.WriteAllTextAsync(entityFile, GenerateEntityTemplate(entityName));


}

string GenerateEntityTemplate(string entityName)
{
    return $$"""
                namespace PharmacyService.Domain.Entities;
                
                using Coban.Domain.Entities.Base;
                
                public class {{entityName}}Entity : BaseEntity
                {
                   
                }
                """;
}
