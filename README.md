# C# Random Number Generators

Written by [Conrad Shyu](mailto:conradshyu@hotmail.com)<br>
*revised on June 17, 2015*<br>
*last updated on July 5, 2020*

## Synopsis
This C# implementation generates random number of various, well-known probability distributions. Specifically,
this implementation supports the following continuous probability distributions:

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

All the equations for generators, except Gamma, are analytical derived either using the inverse CDF (cumulative
distribution function) or transformation. The random numbers generated based on the inverse CDF are guaranteed to
follow the designated distribution. The Gamma random number generator, on the other hand, is based on the
Marsaglia and Tsang's method. This method is also implemented in GSL (Gnu Scientific Library). The equation for
Normal or Gaussian distribution is derived from the bivariate normal distribution, instead of univariate. The
derivation is based on the Box-Muller transformation.

| Filename | Description |
| --- | --- |
| `random.cs` | C# implementation of random number generators |
| `README.md` | this file |

To compile the source code, simply type:

`csc /out:random.exe random.cs`

or, alternatively, on Ubuntu with Mono

`mcs /out:random.exe random.cs`

## Author's Comments
Please report any problems or send comments to [me](mailto:conradshyu@hotmail.com).

## Reference
- GEP Box, Muller M (1958) A note on the generation of random normal deviates. *Annual of Mathematical Statistics*,
29(2): 610-611. [doi:10.1214/aoms/1177706645](http://projecteuclid.org/euclid.aoms/1177706645).
- Marsaglia G, Tsang WW (2000) The Ziggurat method for generating random variables. *Journal of Statistical Software*,
5(8). <http://www.jstatsoft.org/v05/i08>.

Copyright (C) 2015 [Conrad Shyu](mailto:conradshyu@hotmail.com)<br>
Richmond, Virginia 23223

## License
This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public
License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any
later version.

This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied
warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more
details.

You should have received a copy of the GNU General Public License along with this program. If not, see
<http://www.gnu.org/licenses/>.
