using SharedLibrary.Core.Application.DTOs.Enum;

namespace SharedLibrary.Infrastructure.Helpers;

public static class EnumHelper
{
    public static List<EnumHelperDTO> GetEnumValues<T>() where T : Enum
    {
        var result = new List<EnumHelperDTO>();

        foreach (T enumValue in Enum.GetValues(typeof(T)))
        {
            result.Add(new EnumHelperDTO
            {
                Id = Convert.ToInt32(enumValue), 
                Name = enumValue.ToString()
            });
        }

        return result;
    }
}
