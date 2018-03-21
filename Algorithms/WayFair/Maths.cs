using System;
using System.Linq;

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

        public int GetLargestSum(int [] array, int len, int start, int end)
        {
            int maxSum = 0, Sum = 0, i;
            int tempStart = 0;

            for (i = 0; i != len; ++i)
            {
                Sum += array[i];

                // if the sum is equal, choose the one with more elements
                if (Sum > maxSum || (Sum == maxSum && (end - start) < (i - tempStart)))
                {
                    maxSum = Sum;
                    start = tempStart;
                    end = i;
                }
                if (Sum < 0)
                {
                    Sum = 0;
                    tempStart = i + 1;
                }
            }

            return maxSum;
        }

        public static int HighestContiguousSum(int[] inputSequence)
        {
            if (inputSequence == null)
            {
                throw new ArgumentNullException("inputSequence");
            }

            if (!inputSequence.Any())
            {
                throw new ArgumentException("input should not be an empty sequence.");
            }

            var currentSum = inputSequence.First();
            var bestSum = currentSum;

            foreach (var value in inputSequence.Skip(1))
            {
                if (bestSum < 0 && bestSum < value)
                {
                    bestSum = value;
                    currentSum = value;
                }
                else if (value > 0 || (value < 0 && value > -1 * currentSum))
                {
                    currentSum += value;
                    bestSum = Math.Max(currentSum, bestSum);
                }
                else if (value <= -1 * currentSum)
                {
                    currentSum = 0;
                }
            }

            return bestSum;
        }

        // Find the sum of the multiples of 3 or 5 under 1000 from 0 (low L2)
        public void SumOfMultiplesOf3And5LessThanN(int Limit)
        {
            int Sum = 0;
            Console.Write("The Numbers which met the criteria are: ");
            for(int i = 1; i < Limit; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    Console.Write(i + " ");
                    Sum = Sum + i;
                }
            }
            Console.WriteLine();
            Console.WriteLine("The Sum of Multiples of 3 Or 5 Upto and Less Than {0} = {1}", Limit, Sum);

        }

        // public void SumOfMultiplesOfNumbers (int)

        public void SeparatePositiveAndNegativeNumbers(int [] arr)
        {
            int posIndex = 0;
            int negIndex = arr.Length - 1;
            int temp = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[posIndex] >= 0)
                {
                    posIndex++;
                    if (arr[negIndex] < 0)
                    {
                        negIndex--;
                    }
                    continue;
                }

                if (arr[negIndex] < 0)
                {
                    negIndex--;
                    if (arr[posIndex] >= 0)
                    {
                        posIndex++;
                    }
                    continue;
                }

                if (arr[posIndex] < 0 && arr[negIndex] >= 0 && posIndex < negIndex)
                {
                    temp = arr[posIndex];
                    arr[posIndex] = arr[negIndex];
                    arr[negIndex] = temp;
                    posIndex++;
                    negIndex--;
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
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
