using System;

namespace Algorithms.WayFair
{
    public class Maths
    {
        public void PrintTableBetweenTwoNumbers(int number1, int number2)
        {
            int difference = number2 - number1;
            Console.Write(" ");
            for (int i = 0; i <= difference; i++)
            {
                Console.Write(" "+(number1 + i));
            }
            Console.WriteLine();

            for (int i = 0; i <= difference; i++)
            {
                Console.Write((number1 + i) + " ");
                for (int j = 0; j <= difference; j++)
                {
                    Console.Write((number1+i)*(number1+j));
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
/*****************************************************************************************
1,3
  1 2 3
1 1 2 3
2 2 4 6
3 3 6 9

9, 12
81 90 99 108
90 100 110 120
99 110 121 132
108 120 132 144
*****************************************************************************************/
