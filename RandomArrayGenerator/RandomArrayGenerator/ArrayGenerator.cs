using System;
using System.Collections.Generic;

namespace RandomGenerator
{
    public class ArrayGenerator
    {
        private readonly Random rand = new Random();

        public List<int> GenerateArray(int length)
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= length; i++)
                list.Add(i);

            for (int i = 0; i < list.Count; i++)
            {
                int next = rand.Next(0, i + 1);
                swap(ref list, i, next);
            }

            return list;
        }

        private void swap(ref List<int> nums, int i, int j)
        {
            int tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }

    }
}
