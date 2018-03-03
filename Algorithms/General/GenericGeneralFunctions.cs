using System;

namespace Algorithms.General
{
    public class GenericGeneralFunctions
    {
        public static void SwapNumbersWithoutUsingTemp(int number1, int number2)
        {
            number1 = number1 + number2;
            number2 = number1 - number2;
            number1 = number1 - number2;
            Console.WriteLine("\nAfter Swapping : ");
            Console.WriteLine("\nFirst Number : " + number1);
            Console.WriteLine("\nSecond Number : " + number2);
        }

        public static void SumOfDigits(int number)
        {
            int sumOfDigits = 0, remainderDigits;
            while (number != 0)
            {
                remainderDigits = number % 10;
                number = number / 10;
                sumOfDigits = sumOfDigits + remainderDigits;
            }
            Console.WriteLine("Sum of Digits of the Number : " + sumOfDigits);
            Console.ReadLine();
        }
    }
}
