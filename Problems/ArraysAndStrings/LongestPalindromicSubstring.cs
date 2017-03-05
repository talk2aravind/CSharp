
namespace ArraysAndStrings
{
    public class LongestPalindromicSubstring
    {
        /// <summary>
        /// Find the longest palindromic substring.
        /// </summary>
        public string Find(string input)
        {
            if (input == null)
                return null;

            var inputArray = input.ToCharArray();
            var output = inputArray[0].ToString();

            for (var i = 1; i < inputArray.Length; i++)
            {
                // Check for palindromes of odd length.
                output = CheckPalindromes(inputArray, i - 1, i + 1, output);

                // Check for palindromes of even length. Middle two characters are same.
                if (inputArray[i - 1] == inputArray[i])
                    output = CheckPalindromes(inputArray, i - 2, i + 1, output);
            }

            return output;
        }

        private string CheckPalindromes(char[] inputArray, int beforeIndex, int afterIndex, string output)
        {
            while (AreIndicesValid(inputArray, beforeIndex, afterIndex))
            {
                if (inputArray[beforeIndex] != inputArray[afterIndex])
                    break;

                beforeIndex--;
                afterIndex++;
            }

            afterIndex--; // Decrease to go back to the valid index.
            beforeIndex++; // Increase to go back to valid index.

            // Make string only if this palindrome is larger than the previous one.
            var length = afterIndex - beforeIndex + 1;
            if (length > output.Length)
                output = new string(inputArray).Substring(beforeIndex, length);

            return output;
        }

        /// <summary>
        /// Check if the indices are within string.
        /// </summary>
        private bool AreIndicesValid(char[] arr, int startIndex, int endIndex)
            => startIndex >= 0 && endIndex < arr.Length;
    }
}
