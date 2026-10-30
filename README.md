# C# Random Number Generators

Written by [Conrad Shyu](mailto:conradshyu@hotmail.com)<br>
*revised on June 17, 2015*<br>
*last updated on July 5, 2020*

## Synopsis

This C# implementation generates random numbers from several well-known probability distributions. It supports
the following continuous probability distributions:

- Beta, with default parameters shape 2 and 5
- Cauchy, with default parameters location 0.0 and scale 1.0
- Chi Square, with default degree of freedom 10
- Erlang, with default parameters shape 2 and rate 0.5
- Exponential, with default parameters lambda 1.0
- F, with default degrees of freedom 4 and 6
- Gamma, with default parameters shape 2.0 and rate 0.5
- Gaussian or Normal, with default mean 0.0 and standard deviation 1.0
- Pareto, with default parameters scale 2.0 and shape 3.0
- Rayleigh, with default parameter sigma 0.5
- Student-*t*, with default degree of freedom 10
- Uniform, with default minimum 0.0 and maximum 1.0
- Weibull, with default parameters scale 1.0 and shape 1.0

The discrete Bernoulli distribution is also supported, with default probability 0.5. Most generators use inverse-CDF
or transformation methods; the Gamma generator uses the Marsaglia-Tsang method. Normal (Gaussian) samples are
generated using the Box-Muller transformation.

| Filename | Description |
| --- | --- |
| `random.cs` | C# implementation of random number generators |
| `README.md` | this file |
| `LICENSE` | GNU General Public License, version 3 or later |
| `euclid.aoms.1177706645.pdf` | Box-Muller reference paper |
| `ziggurat.pdf` | Ziggurat reference paper |

Compile the source code with the .NET C# compiler:

```text
csc /out:random.exe random.cs
```

Or, on Ubuntu with Mono:

```text
mcs /out:random.exe random.cs
```

Running the compiled program prints 100 Gamma-distributed samples (shape 0.5, rate 1.0).

## Reference
- GEP Box, Muller M (1958) A note on the generation of random normal deviates. *Annual of Mathematical Statistics*,
29(2): 610-611. [doi:10.1214/aoms/1177706645](http://projecteuclid.org/euclid.aoms/1177706645).
- Marsaglia G, Tsang WW (2000) The Ziggurat method for generating random variables. *Journal of Statistical Software*,
5(8). <http://www.jstatsoft.org/v05/i08>.
