using System.Collections;

namespace Algorithms.IHSMarkit
{
    public static class String
    {
        public static string Reverse(string input)
        {
            var inputCharArray = input.ToCharArray();
            Stack inputStack = new Stack(inputCharArray);
            char[] outputCharArray = inputCharArray;
            inputStack.CopyTo(outputCharArray,0);
            var output = new string(outputCharArray);
            return output;
        }

        public static string ReverseUsingSlice(string input)
        {
            input = input.Slice(input.Length, -1);
            return input;
        }

        public static string Slice(this string source, int start, int end)
        {
            if (end < 0) // Keep this for negative end support
            {
                end = source.Length + end;
            }
            int len = end - start;               // Calculate length
            return source.Substring(start, len); // Return Substring of length
        }
    }
}
