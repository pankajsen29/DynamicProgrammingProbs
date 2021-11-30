using System.Collections.Generic;

namespace DPProbsLib
{
    public class CountConstruct
    {
        public int countConstruct(string target, string[] wordBank)
        {
            if (string.IsNullOrWhiteSpace(target)) return 1;

            int totalCount = 0;
            for (int i = 0; i < wordBank.Length; i++)
            {
                if (target.StartsWith(wordBank[i]))
                {
                    var suffix = target.Substring(wordBank[i].Length);
                    var numOfWaysForRest = countConstruct(suffix, wordBank);
                    totalCount += numOfWaysForRest;
                }
            }
            return totalCount;
        }

        public int countConstruct_memoized(string target, string[] wordBank, Dictionary<string, int> memo)
        {
            if (memo.ContainsKey(target)) { return memo[target]; }
            if (string.IsNullOrWhiteSpace(target)) return 1;

            int totalCount = 0;
            for (int i = 0; i < wordBank.Length; i++)
            {
                if (target.StartsWith(wordBank[i]))
                {
                    var suffix = target.Substring(wordBank[i].Length);
                    var numOfWaysForRest = countConstruct_memoized(suffix, wordBank, memo);
                    totalCount += numOfWaysForRest;
                }
            }
            memo.TryAdd(target, totalCount);
            return totalCount;
        }

        public int countConstruct_tabulation(string target, string[] wordBank)
        {
            var table = new int[target.Length + 1];
            table[0] = 1;

            for (int i = 0; i <= target.Length; i++)
            {
                if (table[i] != 0)
                {
                    for (int j = 0; j < wordBank.Length; j++)
                    {
                        //if the word matches the characters starting at position i
                        if (i + wordBank[j].Length <= target.Length && target.Substring(i, wordBank[j].Length).Equals(wordBank[j]))
                        {
                            table[i + wordBank[j].Length] += table[i];
                        }
                    }
                }
            }
            return table[target.Length];
        }
    }
}
