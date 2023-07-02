
using System.Security.Cryptography;

int[] test = { -1, 0, 1, 2, -1, -4 };
IList<IList<int>> output = Solution.ThreeSum(test);
for (int i = 0; i < output.Count; i++)
{
    for (int j = 0; j < output[i].Count; j++)
    {
        Console.Write($"{output[i][j]}, ");
    }
    Console.WriteLine();
}

public class Solution
{
    static public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        IList<IList<int>> triplets = new List<IList<int>>();

        for (int i = 0; i < nums.Length; i++)
        // for each num in nums
        {
            int j = i + 1;
            int k = nums.Length - 1;

            while (j < k)
            {
                int sum = nums[i] + nums[j] + nums[k];
                if (sum == 0)
                {
                    IList<int> temp = new List<int>();
                    temp.Add(nums[i]);
                    temp.Add(nums[j]);
                    temp.Add(nums[k]);

                    if (triplets.All(c => !c.SequenceEqual(temp)))
                    // IF triplet is not already in triplets
                    {
                        triplets.Add(temp); // triplet is unique
                    }

                    j++;
                    k--;
                }
                else if (sum < 0)
                {
                    j++;
                }
                else // sum > 0
                {
                    k--;
                }
            }
        }

        return triplets;
    }
}