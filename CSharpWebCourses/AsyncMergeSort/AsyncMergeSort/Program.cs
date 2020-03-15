using System;
using System.Collections.Generic;
using System.Linq;

namespace AsyncMergeSort
{
    class Program
    {
        static void Main()
        {
            string[] arr = Console.ReadLine().Split(", ");

            string[] sorted = GetSortedArray(arr);

            Console.WriteLine(string.Join(", ", sorted));
        }

        private static string[] GetSortedArray(string[] arr)
        {
            List<int> nums = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                int a;
                if (int.TryParse(arr[i], out a))
                {
                    nums.Add(a);
                }
                else
                {
                    Console.WriteLine($"Error, {arr[i]} is not a valid integer!");
                }
            }

            return AsyncMergeSort(nums).Select(x => x.ToString()).ToArray();
        }

        private static List<int> AsyncMergeSort(List<int> nums)
        {
            if (nums.Count <= 1)
            {
                return nums;
            }

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < nums.Count; i++)
            {
                if (i<nums.Count/2)
                {
                    left.Add(nums[i]);
                }
                else
                {
                    right.Add(nums[i]);
                }
            }

            left = AsyncMergeSort(left);
            right = AsyncMergeSort(right);

            return AsyncMerge(left, right);
        }

        private static List<int> AsyncMerge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while(left.Count >= 1 && right.Count >= 1)
            {
                if (left.First() < right.First())
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }

            if(left.Count >= 1)
            {
                result.AddRange(left);
            }

            if (right.Count >= 1)
            {
                result.AddRange(right);
            }

            return result;
        }
    }
}
