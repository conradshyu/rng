/*
 * random.cs
 * collection of random number generators of various distributions
 *
 * Written by Conrad Shyu (conradshyu at hotmail.com)
 * revised on May 19, 2015
 * revised on June 17, 2015
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

/*
 * random number generator class
*/
public class rng
{
    private static System.Random r = new System.Random();

    /*
     * parameter: lower and upper bound
    */
    static System.Double uniform( System.Double a = 0.0, System.Double b = 1.0 )
    {
        return( a + ( b - a ) * r.NextDouble() );
    }   // uniform distribution, default [0, 1]

    /*
     * parameter: mean and standard deviation
    */
    static System.Double gaussian( System.Double u = 0.0, System.Double s = 1.0 )
    {
        return( s * System.Math.Sqrt( -2.0 * System.Math.Log( uniform() ) ) *
            System.Math.Cos( 2.0 * System.Math.PI * uniform() ) + u );
    }   // normal distribution with mean 0 stadnard deviation 1

    static System.Double normal( System.Double u = 0.0, System.Double s = 1.0 )
    {
        return( gaussian( u, s ) );
    }   // normal distribution with mean 0 and stadnard deviation 1

    /*
     * parameter: lambda
    */
    static System.Double exponential( System.Double l = 1.0 )
    {
        return( -1.0 * System.Math.Log( uniform() ) / l );
    }   // exponential distribution with lambda 1

    /*
     * parameter: lambda and k
    */
    static System.Double weibull( System.Double l = 1.0, System.Double k = 1.0 )
    {
        return( l * System.Math.Pow( -1.0 * System.Math.Log( uniform() ), 1.0 / k ) );
    }   // weibull distribution with lambda 1 and k 1

    /*
     * parameter: sigma
    */
    static System.Double rayleigh( System.Double s = 0.5 )
    {
        return( System.Math.Sqrt( -2.0 * System.Math.Pow( s, 2.0 ) * System.Math.Log( uniform() ) ) );
    }   // rayleigh distribution with sigma 0.5

    /*
     * parameter: scale and shape
    */
    static System.Double pareto( System.Double x = 2.0, System.Double a = 3.0 )
    {
        return( x * System.Math.Pow( uniform(), -1.0 / a ) );
    }   // generalized pareto distribution scale 1 and shape 3

    /*
     * parameter: location and scale
    */
    static System.Double cauchy( System.Double x = 0.0, System.Double r = 1.0 )
    {
        return( r * System.Math.Tan( System.Math.PI * uniform() ) + x );
    }   // cauchy distribution with location 0 and scale 1

    /*
     * parameter: shape and rate
     *
     * note: using the fact that a gamma(1, 1) distribution is the same as
     * exponential(lambda = 1) distribution.
    */
    static System.Double erlang( System.Int32 a = 2, System.Double b = 0.5 )
    {
        System.Double g = 0.0;

        for ( System.Int32 i = 0; i < a; ++i )
        {
            g += exponential( 1.0 ) / b;
        }   // construct the gamma distribution

        return( g );
    }   // erlang distribution with shape 2 and rate 0.5
	
	/*
	 * parameter: shape and rate
	 * 
	 * this implementation is based on Marsaglia and Tsang's method, which is alos used
	 * in GSL (Gnu Scientific Library) and Matlab gammd command.
	*/
	static System.Double gamma( System.Double a = 2.0, System.Double b = 0.5 )
	{
		if ( a < 1.0 )
		{
			return( gamma( a + 1.0, b ) * System.Math.Pow( uniform(), 1.0 / a ) );
		}	// special case when alpha is less than 1.0

	    System.Double d = a - 1.0 / 3.0; System.Double c = 1.0 / System.Math.Sqrt ( 9.0 * d );
		System.Double z, v, p;
		
		do {  // iteratively find the random number
			z = normal(); v = System.Math.Pow( 1.0 + c * z, 3.0 );
			p = 0.5 * System.Math.Pow( z, 2.0 ) + d - d * v + d * System.Math.Log( v );
		} while ( ( z < -1.0 / c ) || ( System.Math.Log( uniform() ) > p ) );
		
		return( ( d * v ) / b );
	}	// gamma distribution with shape 2.0 and rate 0.5
	
    /*
     * parameter: degree of freedom
     *
     * T = Z / sqrt( X / n )
    */
    static System.Double t( System.Double n = 10.0 )
    {
        return( normal( 0.0, 1.0 ) / System.Math.Sqrt( chi( ( System.Int32 )( n ) ) / n ) );
    }   // student t distribution with degree of freedom 10

    /*
     * parameter: degree of freedom and degree of freedom
    */
    static System.Double f( System.Int32 d1 = 4, System.Int32 d2 = 6 )
    {
        return( ( chi( d1 ) * d2 ) / ( chi( d2 ) * d1 ) );
    }   // f distribution with degree of freedom 4 and 6

    /*
     * parameter: alpha and beta
     *
     * note: z = x / (x + y), z ~ beta(a, b), x ~ gamma(a, 1), y ~ gamma(b, 1)
    */
    static System.Double beta( System.Double a = 2.0, System.Double b = 5.0 )
    {
        return( 1.0 / ( 1.0 + gamma( b, 1.0 ) / gamma( a, 1.0 ) ) );
    }   // beta distribution with alpha 2 and beta 5

    /*
     * parameter: degree of freedom
    */
    static System.Double chi( System.Int32 k = 10 )
    {
        System.Double c = 0.0;

        for ( System.Int32 i = 0; i < k; ++i )
        {
            c += System.Math.Pow( normal( 0.0, 1.0 ), 2.0 );
        }   // construct the chi square distribution

        return( c );
    }   // chi square distribution with degree of freedom 10

    /*
     * parameter: p
    */
    static System.Boolean bernoulli( System.Double p = 0.5 )
    {
        return( uniform() > p ? false : true );
    }   // bernoulli trial with p of 0.5

    public static int Main( System.String[] args )
    {
        for ( System.Int32 i = 0; i < 100; ++i )
        {
            System.Console.WriteLine( "{0, 12:f8}", gamma( 0.5, 1.0 ) );
        }   // print out the random numbers

        return( 0 );
    }
}   // class implementation of random number generator
