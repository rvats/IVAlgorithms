using Algorithms.General;
using Algorithms.WayFair;
using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestGeneralClassMethods();
            Maths m = new Maths();
            m.PrintTableBetweenTwoNumbers(1, 3);
            m.PrintTableBetweenTwoNumbers(9, 12);
        }

        private static void TestGeneralClassMethods()
        {
            int number1;
            Console.Write("Enter a Number : ");
            number1 = int.Parse(Console.ReadLine());
            if (GenericMathFunctions.IsNumberEven(number1))
            {
                Console.WriteLine("{0} is Even", number1);
            }
            else
            {
                Console.WriteLine("{0} is Odd", number1);
            }

            int number2;
            Console.Write("Enter a Number : ");
            number2 = int.Parse(Console.ReadLine());
            GenericGeneralFunctions.SwapNumbersWithoutUsingTemp(number1, number2);

            GenericGeneralFunctions.SumOfDigits(number1 + number2);
        }
    }
}
