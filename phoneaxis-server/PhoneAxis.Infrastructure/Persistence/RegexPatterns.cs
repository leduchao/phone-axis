using System.Text.RegularExpressions;

namespace PhoneAxis.Infrastructure.Persistence;

public static partial class RegexPatterns
{
    [GeneratedRegex("([a-z0-9])([A-Z])")]
    public static partial Regex SnakeCaseRegex();
}
