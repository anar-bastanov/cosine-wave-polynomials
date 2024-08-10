using CosinePolynomials;
using System.Text.RegularExpressions;

internal static partial class FormulaFormatParser
{
    private const string PatternCosineOnly = @"^\s*(c|cos|cosine)(\s*only)?\s*$";

    private const string PatternSineAndCosine = @"^\s*(s|sin|sine)\s*((and\s*)?(c|cos|cosine))?$";

    public static bool TryParse(string s, out FormulaFormat result)
    {
        if (MatchCosineOnly().IsMatch(s))
        {
            result = FormulaFormat.CosineOnly;
            return true;
        }

        if (MatchSineAndCosine().IsMatch(s))
        {
            result = FormulaFormat.SineAndCosine;
            return true;
        }

        result = FormulaFormat.Invalid;
        return false;
    }

    [GeneratedRegex(PatternCosineOnly, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
    private static partial Regex MatchCosineOnly();

    [GeneratedRegex(PatternSineAndCosine, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)]
    private static partial Regex MatchSineAndCosine();
}
