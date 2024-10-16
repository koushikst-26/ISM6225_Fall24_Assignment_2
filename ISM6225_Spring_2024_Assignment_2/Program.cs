using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        // Given an array with numbers from 1 to n, this function finds which numbers
        // are missing from the array by rearranging the elements such that each element
        // is in its correct index (e.g., nums[i] == i + 1). Then, it collects all indices
        // that do not match the expected value.
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            IList<int> missing = new List<int>();

            // Arrange numbers so that each number is placed at its correct index
            for (int i = 0; i < nums.Length; i++)
            {
                while (nums[i] != nums[nums[i] - 1])
                {
                    int temp = nums[i];
                    nums[i] = nums[temp - 1];
                    nums[temp - 1] = temp;
                }
            }

            // Collect the numbers that are missing (i.e., indices where nums[i] != i + 1)
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != i + 1)
                {
                    missing.Add(i + 1);
                }
            }

            return missing;
        }

        // Question 2: Sort Array by Parity
        // This function sorts an array by parity, placing even numbers at the front
        // and odd numbers at the end. It uses two pointers (start and end) to rearrange the array.
        public static int[] SortArrayByParity(int[] nums)
        {
            int[] result = new int[nums.Length];
            int start = 0, end = nums.Length - 1;

            foreach (var num in nums)
            {
                if (num % 2 == 0) // Even number goes to the front
                {
                    result[start++] = num;
                }
                else // Odd number goes to the end
                {
                    result[end--] = num;
                }
            }

            return result;
        }

        // Question 3: Two Sum
        // This function returns the indices of two numbers that add up to a specific target.
        // It uses a dictionary to store numbers and their indices for quick lookups.
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            // Traverse the array and check if the complement of nums[i] (target - nums[i])
            // has already been seen (exists in the dictionary).
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                // If complement is found, return the pair of indices
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                }

                // Otherwise, store the current number and its index
                map[nums[i]] = i;
            }

            return new int[0];
        }

        // Question 4: Find Maximum Product of Three Numbers
        // This function finds the maximum product of three numbers in the array.
        // It considers two cases: the product of the three largest numbers, and
        // the product of the two smallest numbers (possibly negative) and the largest number.
        public static int MaximumProduct(int[] nums)
        {
            Array.Sort(nums); // Sort the array to easily access min and max values
            int n = nums.Length;

            // Maximum product can either come from:
            // 1. The product of the three largest numbers
            // 2. The product of the two smallest numbers (in case they're negative) and the largest number
            return Math.Max(nums[0] * nums[1] * nums[n - 1], nums[n - 1] * nums[n - 2] * nums[n - 3]);
        }

        // Question 5: Decimal to Binary Conversion
        // This function converts a decimal number into its binary representation.
        // It uses repeated division by 2 and concatenates the remainders to build the binary string.
        public static string DecimalToBinary(int decimalNumber)
        {
            if (decimalNumber == 0) return "0";

            string binary = "";

            // Keep dividing the number by 2 and collect the remainders
            while (decimalNumber > 0)
            {
                binary = (decimalNumber % 2) + binary; // Prepend the remainder to the binary string
                decimalNumber /= 2;
            }

            return binary;
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        // This function finds the minimum element in a rotated sorted array using binary search.
        // It leverages the fact that in a rotated sorted array, one half of the array is always sorted.
        public static int FindMin(int[] nums)
        {
            int left = 0, right = nums.Length - 1;

            // Use binary search to find the minimum element
            while (left < right)
            {
                int mid = left + (right - left) / 2;

                // If the middle element is greater than the right element, the minimum must be in the right half
                if (nums[mid] > nums[right])
                {
                    left = mid + 1;
                }
                else // Otherwise, it's in the left half
                {
                    right = mid;
                }
            }

            return nums[left]; // The left index will point to the minimum element
        }

        // Question 7: Palindrome Number
        // This function checks whether a given number is a palindrome.
        // A number is a palindrome if it reads the same forward and backward.
        public static bool IsPalindrome(int x)
        {
            if (x < 0) return false; // Negative numbers can't be palindromes

            int original = x, reversed = 0;

            // Reverse the digits of the number
            while (x > 0)
            {
                reversed = reversed * 10 + x % 10;
                x /= 10;
            }

            return original == reversed; // Check if the original number matches the reversed number
        }

        // Question 8: Fibonacci Number
        // This function calculates the nth Fibonacci number using dynamic programming.
        // It stores intermediate results in an array to avoid redundant calculations.
        public static int Fibonacci(int n)
        {
            if (n <= 1) return n; // Base case: F(0) = 0, F(1) = 1

            int[] fib = new int[n + 1];
            fib[0] = 0;
            fib[1] = 1;

            // Calculate Fibonacci numbers iteratively and store them in the array
            for (int i = 2; i <= n; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }

            return fib[n]; // Return the nth Fibonacci number
        }
    }
}
