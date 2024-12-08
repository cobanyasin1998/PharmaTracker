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
                    licenseNumber.Example ="XXXX-XXX-XXXX";
                    licenseNumber.Description ="License number in the format '####-###-####'. Example: 1234-567-8901";
                }
            }

        }

        return true; 
    }
}
