using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPProbsLib
{
    public class GridTraveller
    {
        public long gridTraveller(int row, int col)
        {
            if (row == 0 || col == 0) return 0;
            if (row == 1 && col == 1) return 1;
            return gridTraveller(row - 1, col) + gridTraveller(row, col - 1);
        }

        public long gridTraveller_meoized(int row, int col, Dictionary<string, long> memo)
        {
            string key = row + "," + col;

            if (memo.ContainsKey(key)) return memo[key];
            if (row == 0 || col == 0) return 0;
            if (row == 1 && col == 1) return 1;

            memo[key] = gridTraveller_meoized(row - 1, col, memo) + gridTraveller_meoized(row, col - 1, memo);
            return memo[key];
        }

        public long gridTraveller_tabulation(int row, int col)
        {
            long[,] table = new long[row + 1, col + 1];
            table[1,1] = 1;

            for (int i = 0; i <= row; i++)
            {
                for (int j = 0; j <= col; j++)
                {
                    if (j + 1 <= col) table[i, j + 1] += table[i, j];
                    if (i + 1 <= row) table[i + 1, j] += table[i, j];
                }
            }
            return table[row, col];
        }
    }
}
