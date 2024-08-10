namespace CosinePolynomials;

public static class FormulaConstructor
{
    public const int MaxMultiplier = 500;

    public const int MinMultiplier = -MaxMultiplier;

    public static string? DeriveFormula(int multiplier, FormulaFormat format)
    {
        if (format is not (FormulaFormat.CosineOnly or FormulaFormat.SineAndCosine))
            throw new ArgumentException($"Unsupported format: {format}", nameof(format));

        if (multiplier is < MinMultiplier or > MaxMultiplier)
            return null;

        if (multiplier is >= -1 and <= 1)
            return Fallback(multiplier);

        return format is FormulaFormat.CosineOnly ?
            FormulaConstructorWithCosineOnly.DeriveFormula(multiplier) :
            FormulaConstructorWithSineAndCosine.DeriveFormula(multiplier);

        static string Fallback(int multiplier) =>
            multiplier switch
            {
                < 0 => "cos(-1 * x)  ==  cos(x)",
                  0 => "cos(0 * x)  ==  1",
                > 0 => "cos(1 * x)  ==  cos(x)"
            };
    }
}
