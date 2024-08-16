# Cosine Wave Polynomials
A console application that outputs multiple-angle formulas and trigonometric identities given the multiplier and a specific format. This repository contains two functionally the same applications, one written in C# and the other in Python.

The algorithm generating desired polynomials uses one of two approaches to compute coefficients, famous Pascal's triangle and Chebyshev polynomials of the first kind.

## Examples

| Multiplier | Format | Output Formula |
|:----------:|:------:|:---------------|
| 2 | Cosine Only     | $`cos(2 * x)  =  - 1 + 2 cos(x)^2`$ |
| 2 | Sine And Cosine | $`cos(2 * x)  =  - sin(x)^2 + cos(x)^2`$ |
| 3 | Cosine Only     | $`cos(3 * x)  =  - 3 cos(x) + 4 cos(x)^3`$ |
| 3 | Sine And Cosine | $`cos(3 * x)  =  - 3 sin(x)^2 cos(x) + cos(x)^3`$ |
| 5 | Cosine Only     | $`cos(5 * x)  =  5 cos(x) - 20 cos(x)^3 + 16 cos(x)^5`$ |
| 5 | Sine And Cosine | $`cos(5 * x)  =  5 sin(x)^4 cos(x) - 10 sin(x)^2 cos(x)^3 + cos(x)^5`$ |
| 9 | Cosine Only     | $`cos(9 * x)  =  9 cos(x) - 120 cos(x)^3 + 432 cos(x)^5 - 576 cos(x)^7 + 256 cos(x)^9`$ |
| 9 | Sine And Cosine | $`cos(9 * x)  =  9 sin(x)^8 cos(x) - 84 sin(x)^6 cos(x)^3 + 126 sin(x)^4 cos(x)^5 - 36 sin(x)^2 cos(x)^7 + cos(x)^9`$ |
| ... |

The input multiplier has no theoretical limit; however, these formulas can become extremely lengthy due to their rapidly growing coefficients.

## References
* https://mathworld.wolfram.com/Multiple-AngleFormulas.html
* https://www.anirdesh.com/math/trig/cosine-identities.php
* https://en.wikipedia.org/wiki/Pascal%27s_triangle
* https://en.wikipedia.org/wiki/Chebyshev_polynomials

## License
Copyright &copy; 2024 Anar Bastanov  
Distributed under the [MIT License](http://www.opensource.org/licenses/mit-license.php).
