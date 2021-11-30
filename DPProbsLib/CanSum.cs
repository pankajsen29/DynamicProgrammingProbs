namespace DPProbsLib
{
    public class CanSum
    {
        public bool canSum(int targetSum, int[] numbers)
        {
            if (targetSum == 0) return true;
            if (targetSum < 0) return false;

            for (int i = 0; i < numbers.Length; i++)
            {
                var remainder = targetSum - numbers[i];
                if (canSum(remainder, numbers) == true)
                {
                    return true;
                }
            }
            return false;
        }

        public bool? canSum_memoized(int targetSum, int[] numbers, bool?[] memo)
        {
            if (targetSum >= 0 && null != memo[targetSum]) { return memo[targetSum]; }
            if (targetSum == 0) return true;
            if (targetSum < 0) return false;

            for (int i = 0; i < numbers.Length; i++)
            {
                var remainder = targetSum - numbers[i];
                if (canSum_memoized(remainder, numbers, memo) == true)
                {
                    memo[targetSum] = true;
                    return true;
                }
            }
            memo[targetSum] = false;
            return false;
        }

        public bool canSum_tabulation(int targetSum, int[] numbers)
        {
            bool[] table = new bool[targetSum + 1];
            table[0] = true;

            for (int i = 0; i <= targetSum; i++)
            {
                if (table[i])
                {
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        if (i + numbers[j] <= targetSum) table[i + numbers[j]] = true;
                    }
                }
            }
            return table[targetSum];
        }
    }
}
