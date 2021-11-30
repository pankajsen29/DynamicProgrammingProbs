using System;
using System.Collections.Generic;
using System.Linq;

namespace DPProbsLib
{
    public class AllConstruct
    {
        public string[][] allConstruct(string target, string[] wordBank)
        {
            if (string.IsNullOrWhiteSpace(target)) return Array.Empty<string[]>(); //return new string[0][];

            List<string[]> result= null;

            for (int i = 0; i < wordBank.Length; i++)
            {
                if (target.StartsWith(wordBank[i]))
                {
                    var suffix = target.Substring(wordBank[i].Length);
                    var suffixWays = allConstruct(suffix, wordBank);

                    if (null != suffixWays)
                    {
                        var targetWays = (List<string[]>)suffixWays.ToList();
                        if (suffixWays.Length == 0)
                        {
                            targetWays.Add(new string[1] { wordBank[i] });
                        }
                        else
                        {
                            targetWays = targetWays.Select(comb => (new string[1] { wordBank[i] }).Concat(comb).ToArray()).ToList();
                        }
                        if (null == result) result = new();
                        result.AddRange(targetWays);
                    }
                }
            }
            if (null == result) return null;
            else return result.ToArray();
        }


        public string[][] allConstruct_memoized(string target, string[] wordBank, Dictionary<string, string[][]> memo)
        {
            if (memo.ContainsKey(target)) { return memo[target]; }
            if (string.IsNullOrWhiteSpace(target)) return Array.Empty<string[]>(); //return new string[0][];

            List<string[]> result = null;

            for (int i = 0; i < wordBank.Length; i++)
            {
                if (target.StartsWith(wordBank[i]))
                {
                    var suffix = target.Substring(wordBank[i].Length);
                    var suffixWays = allConstruct_memoized(suffix, wordBank, memo);

                    if (null != suffixWays)
                    {
                        var targetWays = (List<string[]>)suffixWays.ToList();
                        if (suffixWays.Length == 0)
                        {
                            targetWays.Add(new string[1] { wordBank[i] });
                        }
                        else
                        {
                            targetWays = targetWays.Select(comb => (new string[1] { wordBank[i] }).Concat(comb).ToArray()).ToList();
                        }
                        if (null == result) result = new();
                        result.AddRange(targetWays);
                    }
                }
            }
            if (null == result)
            {
                memo.TryAdd(target, null);
                return null;
            }
            else
            {
                memo.TryAdd(target, result.ToArray());
                return result.ToArray();
            }
        }

        public string[][] allConstruct_tabulation(string target, string[] wordBank)
        {
            //array of 'List of (List of string)' is taken to bypass the resize of string array
            List<List<string>> [] table = new List<List<string>>[target.Length +1];
            table[0] = new List<List<string>>();

            for (int i = 0; i <= target.Length; i++)
            {
                if(null!=table[i])
                {
                    for (int j = 0; j < wordBank.Length; j++)
                    {
                        //if the word matches the characters starting at position i
                        if (i + wordBank[j].Length <= target.Length && target.Substring(i, wordBank[j].Length).Equals(wordBank[j]))
                        {
                            var wordOption = new List<string> { wordBank[j] };
                            if (null == table[i + wordBank[j].Length])
                            {
                                table[i + wordBank[j].Length] = new List<List<string>>();
                            }

                            var comb = new List<List<string>>();
                            if (null != table[i]) comb.AddRange(table[i]);
                            if (comb.Count == 0)
                            {
                                comb.Add(wordOption);
                            }
                            else
                            {
                                comb = comb.Select(c => c.Concat(wordOption).ToList()).ToList();
                            }
                            table[i + wordBank[j].Length].AddRange(comb);
                        }
                    }
                }
            }
            if (null != table[target.Length])
                return table[target.Length].Select(comb => comb.ToArray()).ToArray();
            else return null;
        }
    }
}
