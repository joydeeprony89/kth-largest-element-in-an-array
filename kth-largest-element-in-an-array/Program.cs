using System;

namespace kth_largest_element_in_an_array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 0, 1 , -1, -2, 9 };
            Console.WriteLine($"Input is - {string.Join(",", arr)}");
            int k = 3;
            Console.Write($"{k}'th largest element is " + FindKthLargest(arr, k));
        }

        static int FindKthLargest(int[] nums, int k)
        {
            k = nums.Length - k; // k'th largest is similar to (length - k) th index element from an asc sorted array.
            int l = 0, r = nums.Length - 1;
            while (l < r)
            {
                int position = Partition(nums, l, r);
                // similar to quick sort except the below check
                // we take the partition ( from partition position left side elements are lesser , right side elements are greater of partition elemenet)
                // based on the value of K we update the left / right pointer to carry our sorting for the required portion, instead of entire array to be sorted.
                if (k < position)
                {
                    r = position - 1;
                }
                else if (k > position)
                {
                    l = position + 1;
                }
                else break;
            }
            return nums[k];
        }

        static int Partition(int[] nums, int l, int r)
        {
            int i = l;
            int pivot = nums[r];
            for (int j = l; j < r; j++)
            {
                if (nums[j] <= pivot)
                {
                    Swap(nums, i, j);
                    i++;
                }
            }
            Swap(nums, i, r);
            return i;
        }

        static int Another_Partition(int[] nums, int l, int r)
        {
            int i = l - 1;
            int pivot = nums[r];
            for (int j = l; j <= r - 1; j++)
            {
                if (nums[j] < pivot)
                {
                    i++;
                    Swap(nums, i, j);
                }
            }

            Swap(nums, i + 1, r);
            return i + 1;
        }

        static void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
