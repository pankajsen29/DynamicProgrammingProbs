using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPProbsLib
{
    public class Fibonacci
    {
        public int fib(int n)
        {
            if (n <= 2) return 1;
            return fib(n - 1) + fib(n - 2);
        }

        //Here memo parameter is of type,
        //long[] memo, where array index will be the arg to the function and strored value will be the return value
        //also possible to take as, Dictionary<int, int> memo, where keys will be the arg to the function and value will be the return value
        public long fib_memoized(int n, long[] memo) 
        {
            if (memo[n] != 0) return memo[n];
            if (n <= 2) return 1;

            memo[n] = fib_memoized(n - 1, memo) + fib_memoized(n - 2, memo);
            return memo[n];
        }

        public long fib_tabulation(int n)
        {
            long[] table = new long[n + 1];
            table[1] = 1;
            for (int i = 0; i <= n; i++)
            {
                if (i + 1 <= n) table[i + 1] += table[i];
                if (i + 2 <= n) table[i + 2] += table[i];
            }
            return table[n];
        }
    }
}
