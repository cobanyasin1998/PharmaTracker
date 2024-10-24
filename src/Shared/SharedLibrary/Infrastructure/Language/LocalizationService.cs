using Newtonsoft.Json;
using SharedLibrary.Core.Application.Cache;
using SharedLibrary.Core.Application.DTOs.Enum;
using SharedLibrary.Core.Application.Enums;
using SharedLibrary.Core.Application.Language;
using SharedLibrary.Infrastructure.Helpers;
using System.Text.RegularExpressions;

namespace SharedLibrary.Infrastructure.Language;

public class LocalizationService : ILocalizationService
{
    private readonly ICacheService _cacheService;

    public LocalizationService(ICacheService cacheService)
    {
        _cacheService = cacheService;

        GetLocalizationDataFromJson("tr.json");

    }

    private ECultureType _currentCulture;

    public ECultureType CurrentCulture
        => _currentCulture;

    public string GetLocalizedValue(string key)
    {
        string cacheKey = $"{key}_{_currentCulture}";
        if (_cacheService.TryGetValue(cacheKey, out string localizedValue))
        {
            return localizedValue;
        }
        return GetFallbackValue(key);
    }
    public List<EnumHelperDTO> GetSupportedCultures()
        => EnumHelper.GetEnumValues<ECultureType>();

    public void SetCulture(ECultureType culture)
        => _currentCulture = culture;

    public IDictionary<string, string> GetLocalizedValues(IEnumerable<string> keys)
    {
        var localizedValues = new Dictionary<string, string>();

        foreach (var key in keys)
            localizedValues[key] = GetLocalizedValue(key);
        return localizedValues;
    }

    private string GetFallbackValue(string key)
        => AddSpacesBeforeUppercase(key);

    private static string AddSpacesBeforeUppercase(string input)
        => Regex.Replace(input, "(?<!^)([A-Z])", " $1");

    private void GetLocalizationDataFromJson(string filePath)
    {
        var jsonContent = File.ReadAllText(filePath);
        var datas = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonContent);
        _cacheService.SetMultiple(datas, _currentCulture);
    }


}
