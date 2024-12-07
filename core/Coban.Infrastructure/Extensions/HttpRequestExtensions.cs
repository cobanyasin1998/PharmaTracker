using Microsoft.AspNetCore.Http;

namespace Coban.Infrastructure.Extensions;

public static class HttpRequestExtensions
{
    private readonly static string ApplicationJson = "application/json";
    public static bool HasJsonContentType(this HttpRequest request)
    {
        return request.ContentType is not null &&
               request.ContentType.StartsWith(ApplicationJson, StringComparison.OrdinalIgnoreCase);
    }
}
