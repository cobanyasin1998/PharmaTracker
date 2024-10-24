using SharedLibrary.Core.Application.Enums;

namespace SharedLibrary.Core.Application.Cache;

public interface ICacheService
{
    bool TryGetValue(string key, out string value);
    void Set(string key, string value);
    void SetMultiple(Dictionary<string, string> keyValuePairs, ECultureType eCultureType);
}