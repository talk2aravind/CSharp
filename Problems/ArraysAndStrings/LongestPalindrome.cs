
using System;
using System.Collections.Generic;
using System.Text;

namespace ArraysAndStrings
{
    public class LongestPalindrome
    {
        /// <summary>
        /// Make longest palindrome.
        /// </summary>
        public string Create(string input)
        {
            if (input == null)
                return null;

            var inputArray = input.ToCharArray();
            var output = new StringBuilder();

            // Make dictionary to populate word counts.
            var dict = new Dictionary<char, int>();
            MakeDic(inputArray, dict);

            string oddVal = null;
            foreach (var key in dict.Keys)
            {
                var count = dict[key] / 2;

                if (oddVal == null && dict[key] % 2 != 0)
                    oddVal = key.ToString();

                output.Append(key, count);
            }

            // Reverse second half
            var secondHalf = output.ToString().ToCharArray();
            Array.Reverse(secondHalf);

            // If there was an add counted string, put that in middle.
            if (oddVal != null)
                output.Append(oddVal);

            return output.Append(new string(secondHalf)).ToString();
        }

        private void MakeDic(char[] arr, Dictionary<char, int> dict)
        {
            foreach (var c in arr)
            {
                if (dict.ContainsKey(c))
                    dict[c]++;
                else
                    dict.Add(c, 1);
            }
        }

    }
}
