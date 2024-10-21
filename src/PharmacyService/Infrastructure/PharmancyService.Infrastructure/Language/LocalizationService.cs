using Microsoft.AspNetCore.Http;
using PharmacyService.Application.Abstraction.Language;
using System.Text.RegularExpressions;

namespace PharmancyService.Infrastructure.Language;

public class LocalizationService : ILocalizationService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LocalizationService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetLocalizedValue(string key)
    {
        //önce jsondan okuma yapılacak sonra cache gelecek buraya
        if (key == "NameRequired")
        {
            return "Name is required";
        }
        // Kullanıcı kültürüne göre JSON dosyasını okur ve ilgili mesajı döndürür
        return AddSpacesBeforeUppercase(key);
    }
    private static string AddSpacesBeforeUppercase(string input)
    {
        return Regex.Replace(input, "(?<!^)([A-Z])", " $1");
    }
}
