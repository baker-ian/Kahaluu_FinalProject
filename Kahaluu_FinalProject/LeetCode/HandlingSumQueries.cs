/****************************************************************
 * Kahaluu_FinalProject
 * Author: [Your Name]
 * Created: April 23, 2025
 * Description: Solution for LeetCode Problem 2569 - 
 *              Handling Sum Queries After Update
 * 
 * Source: Assisted by Claude 3.7 Sonnet (Anthropic)
 ****************************************************************/

using System;
using System.Collections.Generic;

namespace Kahaluu_FinalProject.LeetCode
{
    public class HandlingSumQueries
    {
        public class SegmentTree
        {
            private int[] tree;
            private bool[] lazy;
            private int n;

            public SegmentTree(int[] nums)
            {
                n = nums.Length;
                tree = new int[4 * n];
                lazy = new bool[4 * n];
                BuildTree(nums, 0, 0, n - 1);
            }

            private void BuildTree(int[] nums, int node, int start, int end)
            {
                if (start == end)
                {
                    tree[node] = nums[start];
                    return;
                }

                int mid = (start + end) / 2;
                BuildTree(nums, 2 * node + 1, start, mid);
                BuildTree(nums, 2 * node + 2, mid + 1, end);
                tree[node] = tree[2 * node + 1] + tree[2 * node + 2];
            }

            private void PushDown(int node, int start, int end)
            {
                if (lazy[node])
                {
                    tree[node] = (end - start + 1) - tree[node]; // Flip bits

                    if (start != end)
                    {
                        lazy[2 * node + 1] = !lazy[2 * node + 1];
                        lazy[2 * node + 2] = !lazy[2 * node + 2];
                    }

                    lazy[node] = false;
                }
            }

            public void UpdateRange(int l, int r)
            {
                UpdateRange(0, 0, n - 1, l, r);
            }

            private void UpdateRange(int node, int start, int end, int l, int r)
            {
                PushDown(node, start, end);

                // No overlap
                if (end < l || start > r) return;

                // Complete overlap
                if (start >= l && end <= r)
                {
                    tree[node] = (end - start + 1) - tree[node]; // Flip bits

                    if (start != end)
                    {
                        lazy[2 * node + 1] = !lazy[2 * node + 1];
                        lazy[2 * node + 2] = !lazy[2 * node + 2];
                    }

                    return;
                }

                // Partial overlap
                int mid = (start + end) / 2;
                UpdateRange(2 * node + 1, start, mid, l, r);
                UpdateRange(2 * node + 2, mid + 1, end, l, r);

                tree[node] = tree[2 * node + 1] + tree[2 * node + 2];
            }

            public int Query(int l, int r)
            {
                return Query(0, 0, n - 1, l, r);
            }

            private int Query(int node, int start, int end, int l, int r)
            {
                if (end < l || start > r)
                    return 0;

                PushDown(node, start, end);

                if (start >= l && end <= r)
                    return tree[node];

                int mid = (start + end) / 2;
                int left = Query(2 * node + 1, start, mid, l, r);
                int right = Query(2 * node + 2, mid + 1, end, l, r);

                return left + right;
            }
        }

        public long[] HandleQuery(int[] nums1, int[] nums2, int[][] queries)
        {
            SegmentTree segTree = new SegmentTree(nums1);
            List<long> result = new List<long>();
            long sum = 0;

            // Calculate initial sum of nums2
            foreach (int num in nums2)
            {
                sum += num;
            }

            foreach (int[] query in queries)
            {
                int queryType = query[0];

                if (queryType == 1)
                {
                    int l = query[1];
                    int r = query[2];
                    segTree.UpdateRange(l, r);
                }
                else if (queryType == 2)
                {
                    long p = query[1];
                    int onesCount = segTree.Query(0, nums1.Length - 1);
                    sum += onesCount * p;
                }
                else if (queryType == 3)
                {
                    result.Add(sum);
                }
            }

            return result.ToArray();
        }

        public string GetProblemDescription()
        {
            return @"Problem 2569: Handling Sum Queries After Update

You are given two 0-indexed arrays nums1 and nums2 and a 2D array queries of queries. There are three types of queries:

1. For a query of type 1, queries[i] = [1, l, r]. Flip the values from 0 to 1 and from 1 to 0 in nums1 from index l to index r. Both l and r are 0-indexed.
2. For a query of type 2, queries[i] = [2, p, 0]. For every index 0 <= i < n, set nums2[i] = nums2[i] + nums1[i] * p.
3. For a query of type 3, queries[i] = [3, 0, 0]. Find the sum of the elements in nums2.

Return an array containing all the answers to the third type queries.";
        }

        public string GetTestCase()
        {
            return @"Example:
nums1 = [1,0,1], nums2 = [0,0,0], queries = [[1,1,1],[2,1,0],[3,0,0]]
Output: [3]

Explanation:
After the first query, nums1 becomes [1,1,1].
After the second query, nums2 becomes [1,1,1].
After the third query, we return the sum of nums2 which is 3.";
        }

        public long[] SolveTestCase()
        {
            int[] nums1 = { 1, 0, 1 };
            int[] nums2 = { 0, 0, 0 };
            int[][] queries = new int[][] {
                new int[] { 1, 1, 1 },
                new int[] { 2, 1, 0 },
                new int[] { 3, 0, 0 }
            };

            return HandleQuery(nums1, nums2, queries);
        }
    }
}