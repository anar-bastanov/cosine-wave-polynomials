using System.Diagnostics;
using System.Numerics;
using static System.Numerics.BigInteger;

namespace CosinePolynomials;

internal static class FormulaConstructorWithSineAndCosine
{
    public static string DeriveFormula(int multiplier)
    {
        string init = "cos(" + multiplier + " * x)  == ";

        if (multiplier < 0)
            multiplier = -multiplier;

        Debug.Assert(multiplier > 1);

        var formula = new string[2 * multiplier + multiplier / 2 % 2];
        formula[0] = init;

        var terms = GetPolynomialTerms(multiplier);

        for (int i = 0, j = multiplier / 2 * 2; j >= 0; j -= 2)
        {
            int k = multiplier - j;

            if (j % 4 != 0)
                formula[++i] = "-";
            else if (k > 1)
                formula[++i] = "+";

            if (terms[j] is var t && !t.IsOne)
                formula[++i] = t.ToString();

            if (j > 0)
                formula[++i] = "sin(x)^" + j;

            if (k == 1)
                formula[++i] = "cos(x)";
            else if (k != 0)
                formula[++i] = "cos(x)^" + k;
        }

        return string.Join(' ', formula);
    }

    private static BigInteger[] GetPolynomialTerms(int multiplier)
    {
        Debug.Assert(multiplier >= 0);

        int length = multiplier + 1;
        var terms = new BigInteger[length];
        terms[0] = One;

        for (int a = 0; a < multiplier;)
        {
            var p = terms[a] * (multiplier - a);
            ++a;
            terms[a] = p / a;
        }

        return terms;
    }
}
