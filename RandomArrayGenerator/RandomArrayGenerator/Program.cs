using RandomGenerator;
using System;
using System.Collections.Generic;

namespace RandomArrayGenerator
{
    class Program
    {

        public static void Out(List<int> nums)
        {
            foreach (var i in nums)
            {
                Console.Write(i);
                Console.Write(" ");
            }
        }

        static void Main(string[] args)
        {
            ArrayGenerator generator = new ArrayGenerator();
            List<int> randomList = generator.GenerateArray(10000);

            Out(randomList);
            Console.ReadKey();
        }
    }
}

