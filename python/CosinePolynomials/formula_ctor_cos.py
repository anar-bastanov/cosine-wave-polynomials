
class FormulaConstructorWithCosineOnly:
    @staticmethod
    def get_polynomial_terms(multiplier: int) -> list:
        length = multiplier // 2 + 3
        st = [0] * length
        nd = [0] * length
        rd = [0] * length
        st[1] = 1
        nd[1] = 2
        nd[2] = 1

        for i in range(1, multiplier):
            for j in range(i // 2 + 2):
                rd[j + 1] = st[j] + 2 * nd[j + 1]
            st, nd, rd = nd, rd, st

        return st

    @staticmethod
    def construct(multiplier: int) -> str:
        init = f"cos({multiplier} * x)  == "
        multiplier = abs(multiplier)

        formula = [''] * (multiplier + (multiplier + 6) // 4 * 2)
        formula[0] = init

        terms = FormulaConstructorWithCosineOnly.get_polynomial_terms(multiplier)
        count = len(terms)

        i = 0
        for j in range(count - 2, 0, -1):
            k = multiplier - 2 * j + 2

            if j % 2 == 0:
                formula[i := i + 1] = '-'
            elif j + 2 != count:
                formula[i := i + 1] = '+'

            formula[i := i + 1] = str(terms[j])

            if k == 1:
                formula[i := i + 1] = "cos(x)"
            elif k != 0:
                formula[i := i + 1] = f"cos(x)^{k}"

        return ' '.join(formula)
