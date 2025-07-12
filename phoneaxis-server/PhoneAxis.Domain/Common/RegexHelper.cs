using System.Text.RegularExpressions;

namespace PhoneAxis.Domain.Common;

public static partial class RegexHelper
{
    [GeneratedRegex(@"[^a-z0-9\s-]")]
    public static partial Regex SlugCleanupRegex();

    [GeneratedRegex(@"\s+")]
    public static partial Regex SlugWhitespaceRegex();

    [GeneratedRegex(@"([a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12})$")]
    public static partial Regex SlugProductIdRegex();
}
