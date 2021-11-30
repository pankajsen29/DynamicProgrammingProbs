using DPProbsLib;
using System;
using System.Collections.Generic;

namespace DPProbsClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibonacci fibObj = new();

            Console.WriteLine("Fibonacci bruteforce:");
            Console.WriteLine(fibObj.fib(7)); //13
            Console.WriteLine(fibObj.fib(9)); //34
            //takes long time to execute, that's why commented out
            //Console.WriteLine(fibObj.fib(50)); //12,586,269,025

            Console.WriteLine();
            Console.WriteLine("Fibonacci memoized:");
            Console.WriteLine(fibObj.fib_memoized(7, new long[7 + 1])); //13
            Console.WriteLine(fibObj.fib_memoized(9, new long[9 + 1])); //34
            Console.WriteLine(fibObj.fib_memoized(50, new long[50 + 1])); //12,586,269,025

            Console.WriteLine();
            Console.WriteLine("Fibonacci tabulation:");
            Console.WriteLine(fibObj.fib_tabulation(7)); //13
            Console.WriteLine(fibObj.fib_tabulation(9)); //34
            Console.WriteLine(fibObj.fib_tabulation(50)); //12,586,269,025
            Console.WriteLine("=================================");


            GridTraveller gtObj = new();
            Console.WriteLine("Gridtraveller bruteforce:");
            Console.WriteLine(gtObj.gridTraveller(1, 1)); //1
            Console.WriteLine(gtObj.gridTraveller(2, 3)); //3
            Console.WriteLine(gtObj.gridTraveller(3, 2)); //3
            Console.WriteLine(gtObj.gridTraveller(3, 3)); //6
            //takes long time to execute, that's why commented out
            //Console.WriteLine(gtObj.gridTraveller(18, 18)); //2333606220

            Console.WriteLine();
            Console.WriteLine("Gridtraveller memoized:");
            Console.WriteLine(gtObj.gridTraveller_meoized(1, 1, new Dictionary<string, long>())); //1
            Console.WriteLine(gtObj.gridTraveller_meoized(2, 3, new Dictionary<string, long>())); //3
            Console.WriteLine(gtObj.gridTraveller_meoized(3, 2, new Dictionary<string, long>())); //3
            Console.WriteLine(gtObj.gridTraveller_meoized(3, 3, new Dictionary<string, long>())); //6
            Console.WriteLine(gtObj.gridTraveller_meoized(18, 18, new Dictionary<string, long>())); //2333606220

            Console.WriteLine();
            Console.WriteLine("Gridtraveller tabulation:");
            Console.WriteLine(gtObj.gridTraveller_tabulation(1, 1)); //1
            Console.WriteLine(gtObj.gridTraveller_tabulation(2, 3)); //3
            Console.WriteLine(gtObj.gridTraveller_tabulation(3, 2)); //3
            Console.WriteLine(gtObj.gridTraveller_tabulation(3, 3)); //6
            Console.WriteLine(gtObj.gridTraveller_tabulation(18, 18)); //2333606220
            Console.WriteLine("=================================");

            CanSum canSumObj = new CanSum();
            Console.WriteLine("CanSum bruteforce:");
            Console.WriteLine(canSumObj.canSum(7, new int[] { 2, 3 })); //True
            Console.WriteLine(canSumObj.canSum(7, new int[] { 5, 3, 4, 7 })); //True
            Console.WriteLine(canSumObj.canSum(7, new int[] { 2, 4 })); //False
            Console.WriteLine(canSumObj.canSum(8, new int[] { 2, 3, 5 })); //True
            //takes long time to execute, that's why commented out
            //Console.WriteLine(canSumObj.canSum(300, new int[] { 7, 14 })); //False

            Console.WriteLine();
            Console.WriteLine("CanSum memoized:");
            Console.WriteLine(canSumObj.canSum_memoized(7, new int[] { 2, 3 }, new bool?[7 + 1])); //True
            Console.WriteLine(canSumObj.canSum_memoized(7, new int[] { 5, 3, 4, 7 }, new bool?[7 + 1])); //True
            Console.WriteLine(canSumObj.canSum_memoized(7, new int[] { 2, 4 }, new bool?[7 + 1])); //False
            Console.WriteLine(canSumObj.canSum_memoized(8, new int[] { 2, 3, 5 }, new bool?[8 + 1])); //True
            Console.WriteLine(canSumObj.canSum_memoized(300, new int[] { 7, 14 }, new bool?[300 + 1])); //False

            Console.WriteLine();
            Console.WriteLine("CanSum tabulation:");
            Console.WriteLine(canSumObj.canSum_tabulation(7, new int[] { 2, 3 })); //True
            Console.WriteLine(canSumObj.canSum_tabulation(7, new int[] { 5, 3, 4, 7 })); //True
            Console.WriteLine(canSumObj.canSum_tabulation(7, new int[] { 2, 4 })); //False
            Console.WriteLine(canSumObj.canSum_tabulation(8, new int[] { 2, 3, 5 })); //True
            Console.WriteLine(canSumObj.canSum_tabulation(300, new int[] { 7, 14 })); //False
            Console.WriteLine("=================================");

            HowSum howSumObj = new HowSum();
            Console.WriteLine("HowSum bruteforce:");
            Print(howSumObj.howSum(7, new int[] { 2, 3 })); //[3,2,2]
            Print(howSumObj.howSum(7, new int[] { 5, 3, 4, 7 })); //[4,3]
            Print(howSumObj.howSum(7, new int[] { 2, 4 })); //Null
            Print(howSumObj.howSum(8, new int[] { 2, 3, 5 })); //[2,2,2,2]
            //takes long time to execute, that's why commented out
            //Print(howSumObj.howSum(300, new int[] { 7, 14 })); //Null

            Console.WriteLine();
            Console.WriteLine("HowSum memoized:");
            Print(howSumObj.howSum_memoized(7, new int[] { 2, 3 }, new Dictionary<int, int[]>())); //[3,2,2]
            Print(howSumObj.howSum_memoized(7, new int[] { 5, 3, 4, 7 }, new Dictionary<int, int[]>())); //[4,3]
            Print(howSumObj.howSum_memoized(7, new int[] { 2, 4 }, new Dictionary<int, int[]>())); //Null
            Print(howSumObj.howSum_memoized(8, new int[] { 2, 3, 5 }, new Dictionary<int, int[]>())); //[2,2,2,2]
            Print(howSumObj.howSum_memoized(300, new int[] { 7, 14 }, new Dictionary<int, int[]>())); //Null

            Console.WriteLine();
            Console.WriteLine("HowSum tabulation:");
            Print(howSumObj.howSum_tabulation(7, new int[] { 2, 3 })); //[3,2,2]
            Print(howSumObj.howSum_tabulation(7, new int[] { 5, 3, 4, 7 })); //[4,3]
            Print(howSumObj.howSum_tabulation(7, new int[] { 2, 4 })); //Null
            Print(howSumObj.howSum_tabulation(8, new int[] { 2, 3, 5 })); //[2,2,2,2]
            Print(howSumObj.howSum_tabulation(300, new int[] { 7, 14 })); //Null
            Console.WriteLine("=================================");

            BestSum bestSumObj = new BestSum();
            Console.WriteLine("BestSum bruteforce:");
            Print(bestSumObj.bestSum(7, new int[] { 2, 3 })); //[3,2,2]
            Print(bestSumObj.bestSum(7, new int[] { 5, 3, 4, 7 })); //[7]
            Print(bestSumObj.bestSum(8, new int[] { 2, 3, 5 })); //[5,3]
            Print(bestSumObj.bestSum(8, new int[] { 1, 4, 5 })); //[4,4]
            //takes long time to execute, that's why commented out
            //Print(bestSumObj.bestSum(100, new int[] { 1, 2, 5, 25 })); //[25,25,25,25]

            Console.WriteLine();
            Console.WriteLine("BestSum memoized:");
            Print(bestSumObj.bestSum_memoized(7, new int[] { 2, 3 }, new Dictionary<int, int[]>())); //[3,2,2]
            Print(bestSumObj.bestSum_memoized(7, new int[] { 5, 3, 4, 7 }, new Dictionary<int, int[]>())); //[7]            
            Print(bestSumObj.bestSum_memoized(8, new int[] { 2, 3, 5 }, new Dictionary<int, int[]>())); //[5,3]
            Print(bestSumObj.bestSum_memoized(8, new int[] { 1, 4, 5 }, new Dictionary<int, int[]>())); //[4,4]
            Print(bestSumObj.bestSum_memoized(100, new int[] { 1, 2, 5, 25 }, new Dictionary<int, int[]>())); //[25,25,25,25]
            Print(bestSumObj.bestSum_memoized(300, new int[] { 7, 14 }, new Dictionary<int, int[]>())); //Null

            Console.WriteLine();
            Console.WriteLine("BestSum tabulation:");
            Print(bestSumObj.bestSum_tabulation(7, new int[] { 2, 3 })); //[3,2,2]
            Print(bestSumObj.bestSum_tabulation(7, new int[] { 5, 3, 4, 7 })); //[7]            
            Print(bestSumObj.bestSum_tabulation(8, new int[] { 2, 3, 5 })); //[5,3]
            Print(bestSumObj.bestSum_tabulation(8, new int[] { 1, 4, 5 })); //[4,4]
            Print(bestSumObj.bestSum_tabulation(100, new int[] { 1, 2, 5, 25 })); //[25,25,25,25]
            Print(bestSumObj.bestSum_tabulation(300, new int[] { 7, 14 })); //Null
            Console.WriteLine("=================================");


            CanConstruct canConstructObj = new CanConstruct();
            Console.WriteLine("CanConstruct bruteforce:");
            Console.WriteLine(canConstructObj.canConstruct("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" })); //True
            Console.WriteLine(canConstructObj.canConstruct("skateboard", new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" })); //False
            Console.WriteLine(canConstructObj.canConstruct("enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" })); //True
            //takes long time to execute, that's why commented out
            //Console.WriteLine(canConstructObj.canConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", 
            //    new string[] { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" })); //False


            Console.WriteLine();
            Console.WriteLine("CanConstruct memoized:");
            Console.WriteLine(canConstructObj.canConstruct_memoized("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" }, new Dictionary<string, bool>())); //True
            Console.WriteLine(canConstructObj.canConstruct_memoized("skateboard", new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" }, new Dictionary<string, bool>())); //False
            Console.WriteLine(canConstructObj.canConstruct_memoized("enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" }, new Dictionary<string, bool>())); //True
            Console.WriteLine(canConstructObj.canConstruct_memoized("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
                new string[] { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" }, new Dictionary<string, bool>())); //False

            Console.WriteLine();
            Console.WriteLine("CanConstruct tabulation:");
            Console.WriteLine(canConstructObj.canConstruct_tabulation("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" })); //True
            Console.WriteLine(canConstructObj.canConstruct_tabulation("skateboard", new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" })); //False
            Console.WriteLine(canConstructObj.canConstruct_tabulation("enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" })); //True
            Console.WriteLine(canConstructObj.canConstruct_tabulation("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
                new string[] { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" })); //False
            Console.WriteLine("=================================");


            CountConstruct countConstructObj = new CountConstruct();
            Console.WriteLine("CountConstruct bruteforce:");
            Console.WriteLine(countConstructObj.countConstruct("purple", new string[] { "purp", "p", "ur", "le", "purpl" })); //2
            Console.WriteLine(countConstructObj.countConstruct("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" })); //1
            Console.WriteLine(countConstructObj.countConstruct("skateboard", new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" })); //0
            Console.WriteLine(countConstructObj.countConstruct("enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" })); //4
            //takes long time to execute, that's why commented out
            //Console.WriteLine(countConstructObj.countConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
            //    new string[] { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" })); //0


            Console.WriteLine();
            Console.WriteLine("CountConstruct memoized:");
            Console.WriteLine(countConstructObj.countConstruct_memoized("purple", new string[] { "purp", "p", "ur", "le", "purpl" }, new Dictionary<string, int>())); //2
            Console.WriteLine(countConstructObj.countConstruct_memoized("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" }, new Dictionary<string, int>())); //1
            Console.WriteLine(countConstructObj.countConstruct_memoized("skateboard", new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" }, new Dictionary<string, int>())); //0
            Console.WriteLine(countConstructObj.countConstruct_memoized("enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" }, new Dictionary<string, int>())); //4
            Console.WriteLine(countConstructObj.countConstruct_memoized("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
                new string[] { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" }, new Dictionary<string, int>())); //0
            Console.WriteLine(countConstructObj.countConstruct_memoized("", new string[] { "cat", "dog", "mouse" }, new Dictionary<string, int>())); //1

            Console.WriteLine();
            Console.WriteLine("CountConstruct tabulation:");
            Console.WriteLine(countConstructObj.countConstruct_tabulation("purple", new string[] { "purp", "p", "ur", "le", "purpl" })); //2
            Console.WriteLine(countConstructObj.countConstruct_tabulation("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" })); //1
            Console.WriteLine(countConstructObj.countConstruct_tabulation("skateboard", new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" })); //0
            Console.WriteLine(countConstructObj.countConstruct_tabulation("enterapotentpot", new string[] { "a", "p", "ent", "enter", "ot", "o", "t" })); //4
            Console.WriteLine(countConstructObj.countConstruct_tabulation("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef",
                new string[] { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" })); //0
            Console.WriteLine(countConstructObj.countConstruct_tabulation("", new string[] { "cat", "dog", "mouse" })); //1
            Console.WriteLine("=================================");


            AllConstruct allConstructObj = new AllConstruct();
            Console.WriteLine("AllConstruct bruteforce:");
            DisplayResults(allConstructObj.allConstruct("purple", new string[] { "purp", "p", "ur", "le", "purpl" }));
            /*
            [
            ['purp' 'le' ]
            ['p' 'ur' 'p' 'le' ]
            ]
            */
            DisplayResults(allConstructObj.allConstruct("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd", "ef", "c" }));
            /*
            [
            ['ab' 'cd' 'ef' ]
            ['ab' 'c' 'def' ]
            ['abc' 'def' ]
            ['abcd' 'ef' ]
            ]
            */
            DisplayResults(allConstructObj.allConstruct("skateboard", new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" })); //NULL
            DisplayResults(allConstructObj.allConstruct("", new string[] { "cat", "dog", "mouse" })); //EMPTY
            //takes long time to execute, that's why commented out
            //DisplayResults(allConstructObj.allConstruct("aaaaaaaaaaaaaaaaaaaaaaaaaaz", new string[] { "a", "aa", "aaa", "aaaa", "aaaaa" })); //NULL


            Console.WriteLine();
            Console.WriteLine("AllConstruct memoized:");
            DisplayResults(allConstructObj.allConstruct_memoized("purple", new string[] { "purp", "p", "ur", "le", "purpl" }, new Dictionary<string, string[][]>()));
            /*
            [
            ['purp' 'le' ]
            ['p' 'ur' 'p' 'le' ]
            ]
            */
            DisplayResults(allConstructObj.allConstruct_memoized("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd", "ef", "c" }, new Dictionary<string, string[][]>()));
            /*
            [
            ['ab' 'cd' 'ef' ]
            ['ab' 'c' 'def' ]
            ['abc' 'def' ]
            ['abcd' 'ef' ]
            ]
            */
            DisplayResults(allConstructObj.allConstruct_memoized("skateboard", new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" }, new Dictionary<string, string[][]>())); //NULL
            DisplayResults(allConstructObj.allConstruct_memoized("", new string[] { "cat", "dog", "mouse" }, new Dictionary<string, string[][]>())); //EMPTY
            DisplayResults(allConstructObj.allConstruct_memoized("aaaaaaaaaaaaaaaaaaaaaaaaaaz", new string[] { "a", "aa", "aaa", "aaaa", "aaaaa" }, new Dictionary<string, string[][]>())); //NULL

            Console.WriteLine();
            Console.WriteLine("AllConstruct tabulation:");
            DisplayResults(allConstructObj.allConstruct_tabulation("purple", new string[] { "purp", "p", "ur", "le", "purpl" }));
            /*
            [
            ['purp' 'le' ]
            ['p' 'ur' 'p' 'le' ]
            ]
            */
            DisplayResults(allConstructObj.allConstruct_tabulation("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd", "ef", "c" }));
            /*
            [
            ['ab' 'cd' 'ef' ]
            ['ab' 'c' 'def' ]
            ['abc' 'def' ]
            ['abcd' 'ef' ]
            ]
            */
            DisplayResults(allConstructObj.allConstruct_tabulation("skateboard", new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" })); //NULL            
            DisplayResults(allConstructObj.allConstruct_tabulation("", new string[] { "cat", "dog", "mouse" })); //EMPTY
            //takes long time to execute, that's why commented out
            //DisplayResults(allConstructObj.allConstruct_tabulation("aaaaaaaaaaaaaaaaaaaaaaaaaaz", new string[] { "a", "aa", "aaa", "aaaa", "aaaaa" })); //NULL
        }

        private static void DisplayResults(string[][] result)
        {
            if (null == result) Console.WriteLine("NULL:0 ways to create the target");
            else if (null != result && result.Length == 0) Console.WriteLine("EMPTY:1 way to create the target, by not taking any elements from the given word bank");
            else
            {
                Console.Write("[");
                Console.WriteLine();
                for (int i = 0; (null != result && i < result.Length); i++)
                {
                    Console.Write("[");
                    for (int j = 0; j < result[i].Length; j++)
                    {
                        Console.Write("'" + result[i][j] + "' ");
                    }
                    Console.Write("]");
                    Console.WriteLine();
                }
                Console.Write("]");
                Console.WriteLine();
            }
        }

        private static void Print(int[] result)
        {
            if (null == result)
            {
                Console.Write("Null");
            }
            else
            {
                Console.Write("[");
                foreach (var item in result)
                {
                    Console.Write(item + " ");
                }
                Console.Write("]");
            }
            Console.WriteLine();
        }
    }
}
