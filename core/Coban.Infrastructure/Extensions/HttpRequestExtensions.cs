using Coban.Consts;
using Microsoft.AspNetCore.Http;

namespace Coban.Infrastructure.Extensions;

public static class HttpRequestExtensions
{
    public static bool HasJsonContentType(this HttpRequest request)
    {
        return request.ContentType is not null &&
               request.ContentType.StartsWith(GeneralOperationConsts.ApplicationJsonKey, StringComparison.OrdinalIgnoreCase);
    }
}
