using CosinePolynomials;

Console.WriteLine("Enter an integer multiplier to substitute for `n` in `cos(n * x)`:");

int multiplier;
while (!int.TryParse(Console.ReadLine() ?? "0", out multiplier))
    Console.Error.WriteLine("Invalid input! Please try again:");

Console.WriteLine("Specify the format for the output polynomial (`Cosine Only` or `Sine And Cosine):");

FormulaFormat format;
while (!FormulaFormatParser.TryParse(Console.ReadLine() ?? "c", out format))
    Console.Error.WriteLine("Invalid input! Please try again:");

string? formula = FormulaConstructor.DeriveFormula(multiplier, format);

if (formula is null)
{
    Console.Error.WriteLine(
        $"The input exceeded the limit of {FormulaConstructor.MaxMultiplier} for the multiplier. The developer " +
        $"intentionally put this restriction as outputs from these functions can grow rapidly and consume too much " +
        $"memory. If the machine you are running this code on is powerful enough and you still want to try higher " +
        $"values, you can always inspect the code and remove the limit manually.");
    return;
}

Console.WriteLine("Output formula:");
Console.WriteLine(formula);
