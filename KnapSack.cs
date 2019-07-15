using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace csharp
{
    class KanpSack
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---KnapSack testing--");
            //            Console.WriteLine(numberOfLists(10, 8, 2));
            int result =KnapSackRecursive(3, 50, new int[] { 10, 20, 30 }, new int[] { 60, 100, 120 });
            // int[,] k = new int[4, 51];
            //KnapSackDP(3, 50, new int[] { 10, 20, 30 }, new int[] { 60, 100, 120 }, k);
            //int result = k[3, 50];
            Console.WriteLine(result);
        }
        static int KnapSackRecursive(int n, int m, int[] wt, int[] v)
        {
            int result = 0;
            if (n == 0 || m == 0)
                result = 0;
            else if (wt[n - 1] > m)
                result = KnapSackRecursive(n - 1, m, wt, v);
            else
            {
                int temp1 = KnapSackRecursive(n - 1, m, wt, v);
                int temp2 = KnapSackRecursive(n - 1, m - wt[n - 1], wt, v) + v[n - 1];
                result = Math.Max(temp1, temp2);
            }
            return result;
        }
        static int KnapSackDP(int n, int m, int[] wt, int[] v, int[,] k)
        {
            if (k[n, m] > 0)
                return k[n, m];
            int result = 0;
            if (n == 0 || m == 0)
                result = 0;
            else if (wt[n - 1] > m)
                result = KnapSackDP(n - 1, m, wt, v, k);
            else
            {
                int temp1 = KnapSackDP(n - 1, m, wt, v, k);
                int temp2 = KnapSackDP(n - 1, m - wt[n - 1], wt, v, k) + v[n - 1];
                result = Math.Max(temp1, temp2);
            }

            k[n, m] = result;
            return result;
        }
    }
}