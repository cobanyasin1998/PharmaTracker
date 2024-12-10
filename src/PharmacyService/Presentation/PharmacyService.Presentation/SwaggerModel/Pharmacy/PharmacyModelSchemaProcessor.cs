using Bogus;
using Coban.Consts;
using NJsonSchema;
using NSwag;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Contexts;

namespace PharmacyService.Presentation.SwaggerModel.Pharmacy;

public class PharmacyModelSchemaProcessor : IOperationProcessor
{

    public bool Process(OperationProcessorContext context)
    {
        string path = context.OperationDescription.Path;

        if (path.Contains("Pharmacy/Create", StringComparison.OrdinalIgnoreCase))
        {
            OpenApiRequestBody requestBody = context.OperationDescription.Operation.RequestBody;
            if (requestBody?.Content?.ContainsKey(GeneralOperationConsts.ApplicationJsonKey) == true)
            {
                JsonSchema schema = requestBody.Content[GeneralOperationConsts.ApplicationJsonKey].Schema;

                if (schema?.Reference?.Properties?.ContainsKey("LicenseNumber") == true)
                {
                    JsonSchemaProperty licenseNumber = schema.Reference.Properties["LicenseNumber"];
                    licenseNumber.Example = GenerateRandomLicenseNumber();
                    licenseNumber.Description ="License number in the format '####-###-####'. Example: 1234-567-8901";
                }
                if (schema?.Reference?.Properties?.ContainsKey("Name") == true)
                {
                    JsonSchemaProperty name = schema.Reference.Properties["Name"];
                    name.Example = GenerateRandomName(3,20);
                }
                if (schema?.Reference?.Properties?.ContainsKey("Description") == true)
                {
                    JsonSchemaProperty name = schema.Reference.Properties["Description"];
                    name.Example = GenerateRandomName(3, 20);
                }
            }

        }

        return true; 
    }

    private string GenerateRandomName(int minLength, int maxLength)
    {
        Faker faker = new();
        string factoryName = string.Empty;
        do
        {
            factoryName = faker.Company.CompanyName(); 
        } while (factoryName.Length < minLength || factoryName.Length > maxLength);

        return factoryName;
    }
    private string GenerateRandomLicenseNumber()
    {
        _ = new Random();

        // Format: XXXX-XXX-XXXX
        string licenseNumber = string.Join("-",
            new string[] {
            GenerateRandomDigits(4), // First part: 4 digits
            GenerateRandomDigits(3), // Second part: 3 digits
            GenerateRandomDigits(4)  // Third part: 4 digits
            });

        return licenseNumber;
    }
    private string GenerateRandomDigits(int length)
    {
        Random random = new Random();
        string digits = string.Empty;

        for (int i = 0; i < length; i++)
        {
            digits += random.Next(0, 10).ToString(); // Append random digit
        }

        return digits;
    }
}
