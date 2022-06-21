//Last Updated: June 21st 2022
//DESCRIPTION : Given an integer, print to console prime numbers less than the given integer

using System;
using System.Collections.Generic;

namespace PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int max;
            string input;

            //Check for passed parameters
            if (args.Length > 0)
            {
                input = args[0];
            }
            //No parameters passed
            else
            {
                Console.WriteLine("Please enter an integer: ");
                input = Console.ReadLine();
            }

            //Check if integer
            if (false == int.TryParse(input, out max))
            {
                //not an int
                Console.WriteLine(input + " is not an integer.\n");
            }

            List<int> Primes = new List<int>();
            Primes.Add(2);
            if (max >= 3)
            {
                Primes = FindPrimes(Primes, max, 3);
                foreach (int number in Primes)
                {
                    Console.Write(number + " ");
                }
            }
            else if(max == 2)
            {
                Console.Write("2");
            }
            else
            {
                Console.Write("There are no prime numbers below 2.");
            }
        }

        //Method        : FindPrimes
        //Parameters    : Primes    : List<int> Containing previous prime numbers
        //              : max       : int contianing the maximum value to generate prime numbers up to
        //              : current   : current number to check if prime
        //Returns       : Primes    : List<int> Containing prime numbers below maximum
        //Description   : Method to find all the prime numbers up to the given maximum using recursion
        static List<int> FindPrimes(List<int> Primes, int max, int current)
        {
            //Check if divisible by any previous prime number
            bool isPrime = true;
            foreach(int number in Primes)
            {
                if (current % number == 0)
                {
                    //not prime
                    isPrime = false;
                    break;
                }
            }
            //If prime, add to list
            if(isPrime)
            {
                Primes.Add(current);
            }
            //skip even numbers
            current += 2;

            //If below max, use recursion to get more primes
            if (current < max)
            {
                Primes = FindPrimes(Primes, max, current);
            }

            return Primes;
        }


    }
}
