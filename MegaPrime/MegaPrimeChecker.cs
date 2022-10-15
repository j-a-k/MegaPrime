using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaPrime
{
    public class MegaPrimeChecker
    {
        private static readonly HashSet<int> primeDigits = new() { 2, 3, 5, 7};

        /// <summary>
        /// Check if a number has only prime digits
        /// </summary>
        /// <param name="x">numer to test</param>
        /// <returns>true if all digits are prime</returns>
        public static bool HasPrimeDigits(uint x)
        {
            return x.ToString()
                .Select(c => int.Parse(c.ToString()))
                .All(d => primeDigits.Contains(d) );
        }

        /// <summary>
        /// Get Primes under max, using a relatively naive seive, not clear if performance is an issue
        /// </summary>
        /// <param name="max">largest number to consider</param>
        /// <returns>list of primes</returns>
        public static List<uint> GetPrimes(uint max)
        {
            CheckRange(max);
            var primes = new List<uint>();
            if (max == 1u)
            {
                return primes;
            }

            for(uint i = 2; i <= max; ++i)
            {
                if (primes.All(p => i % p != 0 ))
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        /// <summary>
        /// Get mega primes below max, where a mega prime is a prime number where all its digits are prime
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static List<uint> GetMegaPrimes(uint max)
        {
            CheckRange(max);
            return GetPrimes(max)
                .Where(HasPrimeDigits)
                .ToList();
        }

        //requirment states between 1 and uint max so handle 0 as an error
        private static void CheckRange(uint max)
        {
            if (max == 0u)
            {
                throw new ArgumentException("max must be 1..unit.max");
            }
        }
    }
}
