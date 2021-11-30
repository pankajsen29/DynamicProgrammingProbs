using System;
using System.Collections.Generic;
using System.Linq;

namespace DPProbsLib
{
    public class HowSum
    {
        public int[] howSum(int targetSum, int [] numbers)
        {
            if (targetSum == 0) return new int[] { };
            if (targetSum < 0) return null;

            for (int i = 0; i < numbers.Length; i++)
            {
                var remainder = targetSum - numbers[i];
                var resultRemainder = howSum(remainder, numbers);
                if (resultRemainder != null)
                {
                    return resultRemainder.Concat(new int[] { numbers[i] }).ToArray(); //early return
                }
            }
            return null;
        }

        public int[] howSum_memoized(int targetSum, int[] numbers, Dictionary<int, int[]> memo)
        {
            if (memo.ContainsKey(targetSum))
            {
                return memo[targetSum];
            }
            if (targetSum == 0) return Array.Empty<int>();
            if (targetSum < 0) return null;

            for (int i = 0; i < numbers.Length; i++)
            {
                var remainder = targetSum - numbers[i];
                var resultRemainder = howSum_memoized(remainder, numbers, memo);
                if (resultRemainder != null)
                {
                    memo.TryAdd(targetSum, resultRemainder.Concat(new int[] { numbers[i] }).ToArray());
                    return memo[targetSum];
                }
            }
            memo.TryAdd(targetSum, null);
            return null;
        }

        public int[] howSum_tabulation(int targetSum, int[] numbers)
        {
            int[][] table = new int[targetSum + 1][];
            table[0] = new int[0];

            for (int i = 0; i <= targetSum; i++)
            {
                if (null != table[i])
                {
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        if (i + numbers[j] <= targetSum)
                        {
                            table[i + numbers[j]] = table[i].Concat(new int[] { numbers[j] }).ToArray();
                        }
                    }
                }
            }
            return table[targetSum];
        }
    }
}
