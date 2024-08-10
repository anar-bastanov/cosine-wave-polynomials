from formula_format import FormulaFormat
from formula_ctor_cos import FormulaConstructorWithCosineOnly
from formula_ctor_sincos import FormulaConstructorWithSineAndCosine


class FormulaConstructor:
    max_multiplier = +500
    min_multiplier = -500

    @classmethod
    def construct(cls, multiplier: int, format: FormulaFormat) -> str | None:
        def fallback() -> str:
            return "cos(-1 * x)  ==  cos(x)" if multiplier < 0 else \
                   "cos(1 * x)  ==  cos(x)"  if multiplier > 0 else \
                   "cos(0 * x)  ==  1"

        if format != FormulaFormat.CosineOnly and format != FormulaFormat.SineAndCosine:
            raise Exception(f"Unsupported format: {format}")

        if multiplier < cls.min_multiplier or multiplier > cls.max_multiplier:
            return None

        if -1 <= multiplier <= 1:
            return fallback()

        if format == FormulaFormat.CosineOnly:
            return FormulaConstructorWithCosineOnly.construct(multiplier)
        return FormulaConstructorWithSineAndCosine.construct(multiplier)
