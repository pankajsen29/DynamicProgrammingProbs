using System.Collections.Generic;

namespace DPProbsLib
{
    public class CanConstruct
    {       
        public bool canConstruct(string target, string[] wordBank)
        {
            if (string.IsNullOrWhiteSpace(target)) return true;

            for (int i = 0; i < wordBank.Length; i++)
            {
                if (target.StartsWith(wordBank[i]))
                {
                    var suffix = target.Substring(wordBank[i].Length);
                    if (canConstruct(suffix, wordBank))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool canConstruct_memoized(string target, string[] wordBank, Dictionary<string, bool> memo)
        {
            if (memo.ContainsKey(target)) { return memo[target]; }
            if (string.IsNullOrWhiteSpace(target)) return true;

            for (int i = 0; i < wordBank.Length; i++)
            {
                if (target.StartsWith(wordBank[i]))
                {
                    var suffix = target.Substring(wordBank[i].Length);
                    if (canConstruct_memoized(suffix, wordBank, memo))
                    {
                        memo.TryAdd(target, true);
                        return true;
                    }
                }
            }
            memo.TryAdd(target, false);
            return false;
        }

        public bool canConstruct_tabulation(string target, string[] wordBank)
        {
            var table = new bool[target.Length + 1];
            table[0] = true;

            for (int i = 0; i <= target.Length; i++)
            {
                if (table[i])
                {
                    for (int j = 0; j < wordBank.Length; j++)
                    {
                        //if the word matches the characters starting at position i
                        if (i + wordBank[j].Length <= target.Length && target.Substring(i, wordBank[j].Length).Equals(wordBank[j]))
                        {
                            table[i + wordBank[j].Length] = true;
                        }
                    }
                }
            }
            return table[target.Length];
        }
    }
}
