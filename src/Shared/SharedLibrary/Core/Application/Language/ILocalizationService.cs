using SharedLibrary.Core.Application.DTOs.Enum;
using SharedLibrary.Core.Application.Enums;

namespace SharedLibrary.Core.Application.Language;

public interface ILocalizationService
{
   
        void SetCulture(ECultureType culture);
        string GetLocalizedValue(string key);       
        IDictionary<string, string> GetLocalizedValues(IEnumerable<string> keys);
        List<EnumHelperDTO> GetSupportedCultures();
    

}
