namespace PharmacyService.Application.Abstraction.Language;

public interface ILocalizationService
{
    string GetLocalizedValue(string key);
}
