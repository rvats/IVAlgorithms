using Algorithms.General;
using Algorithms.WayFair;
using Algorithms.IHSMarkit;
using System;

namespace Algorithms
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    // TestGeneralClassMethods();
        //    // TestWayFairPrintTable();
        //    // TestWayFairStringIsBalanced();
        //    // TestWayFairSumOfMultiplesOf3And5LessThanN();
        //    // TestSepratePositiveNegativeInArray();
        //    // TestWayFairBST();
        //    Console.WriteLine(IHSMarkit.String.Reverse("123456789"));
        //}

        private static void TestWayFairBST()
        {
            BinarySearchTree binarySearchTree = new BinarySearchTree();
            binarySearchTree.Insert("Rahul", 33);
            binarySearchTree.Insert("Arpita", 30);
            binarySearchTree.Insert("Amita", 55);
            binarySearchTree.Insert("Pooja", 26);
            binarySearchTree.Insert("Keshav", 60);
            binarySearchTree.Insert("Gopal", 58);
            Console.WriteLine(binarySearchTree.DrawTree());
            DataStructures dataStructures = new DataStructures();
            Console.WriteLine("Max Depth is {0}", dataStructures.MaxDepthViaLoop(binarySearchTree.RootNode()));
            binarySearchTree.RootNode();
        }

        private static void TestSepratePositiveNegativeInArray()
        {
            int[][] twoDArray = new int[][] {
                new int [] { -1, -3, -5, -6, 2, 4, 5, 2, 1, -6 },
                new int [] { 1, 3, 5, 6, -2, -4, -5, -2, -1, 6 },
                new int [] { 1, -1, 5, -5, -2, 2, 4, -4, -3, 3 },
                new int [] { -1, 1, -5, 5, 2, -2, -4, 4, 3, -3 },
            };
            Maths m = new Maths();
            int i = 1;
            foreach (int[] arr in twoDArray)
            {
                Console.Write("Array {0} before Positive and Negatives are Separated is ", i);
                for (int j = 0; j < arr.Length; j++)
                {
                    Console.Write(arr[j] + " ");
                }
                Console.WriteLine();
                Console.Write("Array {0} after Positive and Negatives are Separated is ", i);
                m.SeparatePositiveAndNegativeNumbers(arr);
                i++;
            }
        }

        private static void TestWayFairSumOfMultiplesOf3And5LessThanN()
        {
            Maths m = new Maths();
            m.SumOfMultiplesOf3And5LessThanN(10);
            m.SumOfMultiplesOf3And5LessThanN(100);
            m.SumOfMultiplesOf3And5LessThanN(1000);
        }

        private static void TestWayFairStringIsBalanced()
        {
            string[] inputs = new string[] {
                "[288 votes so far. Categories: {\"Everything Else\" (47 votes), C# (61 votes), C++ (39 votes), Database (44 votes), Mobile (45 votes), Web Dev (52 votes)}]",
                "[{}()<sometext>[[{{}}]]]", "<Root><First>Test</First<</Root>"
            };
            foreach (var input in inputs)
            {
                var output = WayFair.String.IsBalanced(input)
                ? input + " Is Balanced"
                : input + " Is Not Balanced";
                Console.WriteLine(output);
            }
        }

        private static void TestWayFairPrintTable()
        {
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
