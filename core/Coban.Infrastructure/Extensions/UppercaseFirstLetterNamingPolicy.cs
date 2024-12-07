using System.Text.Json;

namespace Coban.Infrastructure.Extensions;

public class UppercaseFirstLetterNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        if (string.IsNullOrEmpty(name))
            return name;

        return char.ToUpperInvariant(name[0]) + name.Substring(1);
    }
}
