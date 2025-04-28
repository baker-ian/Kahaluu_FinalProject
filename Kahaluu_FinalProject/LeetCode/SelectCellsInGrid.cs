/*
 *File Name: SelectCellsInGrid.cs

* Name: Ian Baker, Zulqarnayan Hossain, Leah T slassie, Mariah Jenkins
* email: bakerin@mail.uc.edu, hossaizn@mail.uc.edu, tslassll@mail.uc.edu, jenkim3@mail.uc.edu
* Assignment Number: Final Project
* Due Date:  4/29/2025
* Course #/Section: IS3050-001
* Semester/Year:   Spring 2025
* Brief Description of the assignment:  This assignment included the team creating a project in Visual Studio that is a web page displaying 4 different Leetcode problems and their solutions. The languages used to build the web page are C# and ASP.Net.

* Brief Description of what this module does. Contains the C# logic to solve LeetCode problem 3276, returning the result based on the provided input test cases.
* Citations: https://chat.openai.com/
	     https://claude.ai/ 
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kahaluu_FinalProject.LeetCode
{
    public class SelectCellsInGrid
    {
        public int MaxScore(int[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            HashSet<int> usedCols = new HashSet<int>();
            HashSet<int> usedVals = new HashSet<int>();
            return DFS(grid, 0, usedCols, usedVals);
        }

        private int DFS(int[][] grid, int row, HashSet<int> usedCols, HashSet<int> usedVals)
        {
            if (row >= grid.Length)
                return 0;

            int max = DFS(grid, row + 1, usedCols, usedVals); // skip current row

            for (int col = 0; col < grid[row].Length; col++)
            {
                int val = grid[row][col];
                if (usedCols.Contains(col) || usedVals.Contains(val))
                    continue;

                usedCols.Add(col);
                usedVals.Add(val);

                int score = val + DFS(grid, row + 1, usedCols, usedVals);
                max = Math.Max(max, score);

                usedCols.Remove(col);
                usedVals.Remove(val);
            }

            return max;
        }


        public string GetProblemDescription()
        {
            return @"Problem 3276: Select Cells in Grid with Maximum Value

You are given a 2D matrix grid consisting of positive integers. You have to select one or more cells from the matrix such that the following conditions are satisfied:
* No two selected cells are in the same row of the matrix.
* The values in the set of selected cells are unique.

Your score will be the sum of the values of the selected cells. Return the maximum score you can achieve.";
        }

        public string GetTestCase()
        {
            return @"Example:
Input: grid = [[1,2,3],[4,3, 2],[1, 1, 1]]
Output: 8
Explanation: We can select the cells at positions (0,2), (1,0), and (2,1).
The values are 3, 4, and 1. All values are unique and come from different rows.
The sum is 3 + 4 + 1 = 8.";
        }

        public int SolveTestCase()
        {
            int[][] grid = new int[][] {
        new int[] { 1, 2, 3 },
        new int[] { 4, 3, 2 },
        new int[] { 1, 1, 1 }
    };

            return MaxScore(grid);
        }

    }
}

