using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Newtonsoft.Json.Linq;

namespace PharmacyService.Persistence.AWSSecret;

public class DatabaseConnectionHelper
{
    public static async Task<string> GetConnectionStringAsync()
    {
        string secretName = "pharmacyServiceDatabaseSecret";
        string region = "eu-north-1";

        IAmazonSecretsManager client = new AmazonSecretsManagerClient(
            "AKIASU5664CIJB6Q7E56",
            "FXEf8OOWcU2vNIqgZGzVyhGL6SeTnrXKo3ggCeeg",
            RegionEndpoint.GetBySystemName(region));

        GetSecretValueRequest request = new GetSecretValueRequest
        {
            SecretId = secretName,
            VersionStage = "AWSCURRENT", // VersionStage defaults to AWSCURRENT if unspecified.
        };

        GetSecretValueResponse response;

        try
        {
            response = await client.GetSecretValueAsync(request);
        }
        catch (Exception e)
        {
            // For a list of the exceptions thrown, see
            // https://docs.aws.amazon.com/secretsmanager/latest/apireference/API_GetSecretValue.html
            throw e;
        }

        string secret = response.SecretString;
        return secret;
    }
}
