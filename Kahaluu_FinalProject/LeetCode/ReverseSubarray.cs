/*
 *File Name: ReverseSubarray.cs

* Name: Ian Baker, Zulqarnayan Hossain, Leah T slassie, Mariah Jenkins
* email: bakerin@mail.uc.edu, hossaizn@mail.uc.edu, tslassll@mail.uc.edu, jenkim3@mail.uc.edu
* Assignment Number: Final Project
* Due Date:  4/29/2025
* Course #/Section: IS3050-001
* Semester/Year:   Spring 2025
* Brief Description of the assignment:  This assignment included the team creating a project in Visual Studio that is a web page displaying 4 different Leetcode problems and their solutions. The languages used to build the web page are C# and ASP.Net.

* Brief Description of what this module does. Contains the C# logic to solve LeetCode problem 1330, returning the result based on the provided input test cases.
* Citations: https://chat.openai.com/
	     https://claude.ai/ 
 */
using System;

namespace Kahaluu_FinalProject.LeetCode
{
    public class ReverseSubarray
    {
        public int MaxValueAfterReverse(int[] nums)
        {
            int n = nums.Length;
            if (n <= 1) return 0;

            int initialValue = 0;
            for (int i = 0; i < n - 1; i++)
            {
                initialValue += Math.Abs(nums[i] - nums[i + 1]);
            }

            int maxGain = 0;
            int low = int.MaxValue, high = int.MinValue;

            for (int i = 0; i < n - 1; i++)
            {
                int a = nums[i];
                int b = nums[i + 1];
                int diff = Math.Abs(a - b);

                maxGain = Math.Max(maxGain, Math.Abs(nums[0] - b) - diff);
                maxGain = Math.Max(maxGain, Math.Abs(a - nums[n - 1]) - diff);

                low = Math.Min(low, Math.Max(a, b));
                high = Math.Max(high, Math.Min(a, b));
            }

            maxGain = Math.Max(maxGain, 2 * (high - low));

            return initialValue + maxGain;
        }

        public string GetProblemDescription()
        {
            return @"Problem 1330: Reverse Subarray To Maximize Array Value

You are given an integer array nums. The value of this array is defined as the sum of |nums[i] - nums[i + 1]| for all 0 <= i < nums.length - 1.

You are allowed to select any subarray of the given array and reverse it. You can perform this operation only once.

Find maximum possible value of the final array.";
        }

        public string GetTestCase()
        {
            return @"Example:
Input: nums = [2,3,1,5,4]
Output: 10
Explanation: By reversing the subarray [3,1,5] the array becomes [2,5,1,3,4] whose value is 10.";
        }

        public int SolveTestCase()
        {
            int[] nums = { 2, 3, 1, 5, 4 };
            return MaxValueAfterReverse(nums);
        }
    }
}

