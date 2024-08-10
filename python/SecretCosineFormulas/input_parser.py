from formula_format import FormulaFormat
import re


_pattern_cos = re.compile(r"^\s*(c|cos|cosine)(\s*only)?\s*$", re.IGNORECASE)
_pattern_sincos = re.compile(r"^\s*(s|sin|sine)\s*((and\s*)?(c|cos|cosine))?$", re.IGNORECASE)

def parse_formula_format(s: str) -> FormulaFormat:
    if _pattern_cos.match(s) is not None:
        return FormulaFormat.CosineOnly

    if _pattern_sincos.match(s) is not None:
        return FormulaFormat.SineAndCosine

    raise ValueError
