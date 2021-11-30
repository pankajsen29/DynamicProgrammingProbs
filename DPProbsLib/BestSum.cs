using System;
using System.Collections.Generic;
using System.Linq;

namespace DPProbsLib
{
    public class BestSum
    {
        public int[] bestSum(int targetSum, int[] numbers)
        {
            if (targetSum == 0) return Array.Empty<int>();
            if (targetSum < 0) return null;

            int[] shortestCombination = null;

            for (int i = 0; i < numbers.Length; i++)
            {
                var remainder = targetSum - numbers[i];
                var remainderCombination = bestSum(remainder, numbers);
                if (remainderCombination != null)
                {
                    var combination = remainderCombination.Concat(new int[] { numbers[i] }).ToArray();
                    if (shortestCombination == null || combination.Length < shortestCombination.Length)
                    {
                        shortestCombination = combination;
                    }
                }
            }
            return shortestCombination;
        }

        public int[] bestSum_memoized(int targetSum, int[] numbers, Dictionary<int, int[]> memo)
        {
            if (memo.ContainsKey(targetSum))
            {
                return memo[targetSum];
            }
            if (targetSum == 0) return Array.Empty<int>();
            if (targetSum < 0) return null;

            int[] shortestCombination = null;

            for (int i = 0; i < numbers.Length; i++)
            {
                var remainder = targetSum - numbers[i];
                var remainderCombination = bestSum_memoized(remainder, numbers, memo);
                if (remainderCombination != null)
                {
                    var combination = remainderCombination.Concat(new int[] { numbers[i] }).ToArray();
                    if (shortestCombination == null || combination.Length < shortestCombination.Length)
                    {
                        shortestCombination = combination;
                    }
                }
            }
            memo.TryAdd(targetSum, shortestCombination);
            return shortestCombination;
        }

        public int[] bestSum_tabulation(int targetSum, int[] numbers)
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
                            var combination = table[i].Concat(new int[] { numbers[j] }).ToArray();
                            if (null == table[i + numbers[j]] || table[i + numbers[j]].Length > combination.Length)
                            {
                                table[i + numbers[j]] = combination;
                            }
                        }
                    }
                }
            }
            return table[targetSum];
        }
    }
}
