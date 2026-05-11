using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism
{
    class Program
    {
        public class clsCalculator        // Declare a class
        {
            private double nResult;

            public double add(int a, int b)
            {
                nResult = a + b;
                return nResult;
            }

            public double add(double a, double b)
            {
                nResult = a + b + 5;
                return nResult;
            }
        }

        static void Main(string[] args)
        {
            clsCalculator oCalculator = new clsCalculator();

            Console.WriteLine(oCalculator.add(5, 5));

            Console.WriteLine(oCalculator.add(5.0, 5.0));

            Console.ReadLine();
        }
    }
}
