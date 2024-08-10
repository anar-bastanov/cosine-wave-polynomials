using System.Diagnostics;
using System.Numerics;
using static System.Numerics.BigInteger;

namespace CosinePolynomials;

internal static class FormulaConstructorWithCosineOnly
{
    public static string DeriveFormula(int multiplier)
    {
        string init = "cos(" + multiplier + " * x)  == ";

        if (multiplier < 0)
            multiplier = -multiplier;

        Debug.Assert(multiplier > 1);

        var formula = new string[multiplier + (multiplier + 6) / 4 * 2];
        formula[0] = init;

        var terms = GetPolynomialTerms(multiplier);
        int count = terms.Length;

        for (int i = 0, j = count - 2; j > 0; --j)
        {
            int k = multiplier - 2 * j + 2;

            if (j % 2 == 0)
                formula[++i] = "-";
            else if (j + 2 != count)
                formula[++i] = "+";

            formula[++i] = terms[j].ToString();

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

        int length = multiplier / 2 + 3;
        var st = new BigInteger[length];
        var nd = new BigInteger[length];
        var rd = new BigInteger[length];
        st[1] = One;
        nd[1] = 2;
        nd[2] = One;

        for (int i = 1; i < multiplier; ++i)
        {
            for (int j = 0; j < i / 2 + 2; ++j)
            {
                rd[j + 1] = st[j] + 2 * nd[j + 1];
            }

            (st, nd, rd) = (nd, rd, st);
        }

        return st;
    }
}
