/*
 *File Name: SelectCellsInGrid.cs

* Name: Ian Baker, Zulqarnayan Hossain, Leah T slassie, Mariah Jenkins
* email: bakerin@mail.uc.edu, hossaizn@mail.uc.edu, tslassll@mail.uc.edu, jenkim3@mail.uc.edu
* Assignment Number: Final Project
* Due Date:  4/29/2025
* Course #/Section: IS3050-001
* Semester/Year:   Spring 2025
* Brief Description of the assignment:  This assignment included the team creating a project in Visual Studio that is a web page displaying 4 different Leetcode problems and their solutions. The languages used to build the web page are C# and ASP.Net.

* Brief Description of what this module does. Contains the C# logic to solve LeetCode problem 1316, returning the result based on the provided input test cases.
* Citations: https://chat.openai.com/
	     https://claude.ai/ 
 */

using System;
using System.Collections.Generic;

namespace Kahaluu_FinalProject.LeetCode
{
    public class DistinctEchoSubstrings
    {
        public int DistinctEchoSubstringsSolution(string text)
        {
            int n = text.Length;
            HashSet<string> echoSubstrings = new HashSet<string>();

            // Try all possible substrings
            for (int len = 1; len <= n / 2; len++)
            {
                for (int i = 0; i + 2 * len <= n; i++)
                {
                    bool isEcho = true;
                    for (int j = 0; j < len; j++)
                    {
                        if (text[i + j] != text[i + len + j])
                        {
                            isEcho = false;
                            break;
                        }
                    }

                    if (isEcho)
                    {
                        string echoString = text.Substring(i, 2 * len);
                        echoSubstrings.Add(echoString);
                    }
                }
            }

            return echoSubstrings.Count;
        }

        // Faster solution using Rabin-Karp rolling hash
        public int DistinctEchoSubstringsOptimized(string text)
        {
            int n = text.Length;
            HashSet<long> seen = new HashSet<long>();
            HashSet<string> result = new HashSet<string>();

            // For each possible length of the half of echo substring
            for (int len = 1; len <= n / 2; len++)
            {
                long hashFirst = 0;
                long hashSecond = 0;
                long power = 1;

                // Base for the rolling hash
                long BASE = 26;
                long MOD = (long)1e9 + 7;

                // Calculate initial hashes for the first two segments
                for (int i = 0; i < len; i++)
                {
                    hashFirst = (hashFirst * BASE + (text[i] - 'a')) % MOD;
                    hashSecond = (hashSecond * BASE + (text[i + len] - 'a')) % MOD;
                    if (i < len - 1)
                        power = (power * BASE) % MOD;
                }

                // Check if the first two segments form an echo
                if (hashFirst == hashSecond && text.Substring(0, len) == text.Substring(len, len))
                {
                    result.Add(text.Substring(0, 2 * len));
                }

                // Slide the window and check for echo substrings
                for (int i = 1; i + 2 * len <= n; i++)
                {
                    // Update the first half hash
                    hashFirst = ((hashFirst - (text[i - 1] - 'a') * power) % MOD + MOD) % MOD;
                    hashFirst = (hashFirst * BASE + (text[i + len - 1] - 'a')) % MOD;

                    // Update the second half hash
                    hashSecond = ((hashSecond - (text[i + len - 1] - 'a') * power) % MOD + MOD) % MOD;
                    hashSecond = (hashSecond * BASE + (text[i + 2 * len - 1] - 'a')) % MOD;

                    // If hashes match, verify and add to result
                    if (hashFirst == hashSecond && text.Substring(i, len) == text.Substring(i + len, len))
                    {
                        result.Add(text.Substring(i, 2 * len));
                    }
                }
            }

            return result.Count;
        }

        public string GetProblemDescription()
        {
            return @"Problem 1316: Distinct Echo Substrings

Return the number of distinct non-empty substrings of text that can be written as the concatenation of some string with itself (i.e. it can be written as a + a where a is some string).";
        }

        public string GetTestCase()
        {
            return @"Example:
Input: text = ""abcabcabc""
Output: 3
Explanation: The 3 substrings are ""abcabc"", ""bcabca"" and ""cabcab"".";
        }

        public int SolveTestCase()
        {
            string text = "abcabcabc";
            return DistinctEchoSubstringsOptimized(text);
        }
    }
}

