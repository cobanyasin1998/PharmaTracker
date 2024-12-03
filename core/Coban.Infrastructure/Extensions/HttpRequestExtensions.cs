using Microsoft.AspNetCore.Http;

namespace Coban.Infrastructure.Extensions;

public static class HttpRequestExtensions
{
    public static bool HasJsonContentType(this HttpRequest request)
    {
        return request.ContentType != null &&
               request.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase);
    }
}
