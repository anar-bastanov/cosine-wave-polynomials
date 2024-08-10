
class FormulaConstructorWithSineAndCosine:
    @staticmethod
    def get_polynomial_terms(multiplier: int) -> list:
        length = multiplier + 1
        terms = [0] * length
        terms[0] = 1

        for a in range(multiplier):
            terms[a + 1] = (terms[a] * (multiplier - a)) // (a + 1)

        return terms


    @staticmethod
    def construct(multiplier: int) -> str:
        init = f"cos({multiplier} * x)  == "
        multiplier = abs(multiplier)

        formula = [''] * (2 * multiplier + multiplier // 2 % 2)
        formula[0] = init

        terms = FormulaConstructorWithSineAndCosine.get_polynomial_terms(multiplier)

        i = 0
        for j in range(multiplier // 2 * 2, -1, -2):
            k = multiplier - j

            if j % 4 != 0:
                formula[i := i + 1] = '-'
            elif k > 1:
                formula[i := i + 1] = '+'

            if terms[j] != 1:
                formula[i := i + 1] = str(terms[j])

            if j != 0:
                formula[i := i + 1] = f"sin(x)^{j}"

            if k == 1:
                formula[i := i + 1] = "cos(x)"
            elif k != 0:
                formula[i := i + 1] = f"cos(x)^{k}"

        return ' '.join(formula)
