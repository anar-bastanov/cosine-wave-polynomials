from input_parser import parse_formula_format
from formula_ctor import FormulaConstructor


def main():
    print("Enter an integer multiplier to substitute for `n` in `cos(n * x)`:");

    while True:
        try:
            multiplier = int(input())
            break
        except ValueError:
            print("Invalid input! Please try again:")
        except EOFError:
            exit()

    print("Specify the format for the output polynomial (`Cosine Only` or `Sine And Cosine):");

    while True:
        try:
            format = parse_formula_format(input())
            break
        except ValueError:
            print("Invalid input! Please try again:")
        except EOFError:
            exit()

    formula = FormulaConstructor.construct(multiplier, format)

    if formula is None:
        print(
            f"The input exceeded the limit of {FormulaConstructor.max_multiplier} for the multiplier. The developer " +
            f"intentionally put this restriction as outputs from these functions can grow rapidly and consume too much " +
            f"memory. If the machine you are running this code on is powerful enough and you still want to try higher " +
            f"values, you can always inspect the code and remove the limit manually.");
        return;

    print("Output formula:");
    print(formula);


if __name__ == '__main__':
    main()
