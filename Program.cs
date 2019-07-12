using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace csharp
{
    class Program
    {
        public static List<string> GetPermutation(string str)
        {
            if (str.Length == 0)
            {
                List<string> empty = new List<string>();
                empty.Add("");
                return empty;
            }
            char ch = str[0];
            string substr = str.Substring(1);
            List<string> preResult = GetPermutation(substr);
            List<string> res = new List<string>();
            foreach (string val in preResult)
            {
                for (int i = 0; i <= val.Length; i++)
                {
                    res.Add(val.Substring(0, i) + ch + val.Substring(i));
                }
            }
            return res;
        }
        static void generateAllBinaryStrings(int n, int[] arr, int i)
        {
            if (i == n)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    Console.Write(arr[j] + " ");
                }
                Console.WriteLine();
                return;
            }
            arr[i] = 0;
            generateAllBinaryStrings(n, arr, i + 1);
            arr[i] = 1;
            generateAllBinaryStrings(n, arr, i + 1);
        }
        static void generateAllBinaryStringsByPattern(int[] pattern, int i, int m, int n, HashSet<string> hs)
        {
            if (i == pattern.Length)
            {
                string result = string.Join("", pattern);
                result = result.Replace("2", "1");
                hs.Add(result);
                return;
            }
            if (pattern[i] == 1)
            {
                pattern[i] = 0;
                generateAllBinaryStringsByPattern(pattern, i + 1, m, n, hs);
                pattern[i] = 1;
                generateAllBinaryStringsByPattern(pattern, i + 1, m, n, hs);
                pattern[i] = 1; //backtrack
            }
            else
            {
                generateAllBinaryStringsByPattern(pattern, i + 1, m, n, hs);
            }

        }
        public static void testQueue()
        {
            Queue<string> ss = new Queue<string>();
            ss.Enqueue("one");
            ss.Enqueue("two");
            ss.Dequeue();

            foreach (var item in ss)
                Console.WriteLine(item);
        }
        public static void testStack()
        {
            Stack<string> ss = new Stack<string>();
            ss.Push("one");
            ss.Push("two");
            ss.Pop();

            foreach (var item in ss)
                Console.WriteLine(item);
        }
        public static void testLinkedList()
        {
            LinkedList<string> ss = new LinkedList<string>();
            ss.AddFirst("bb");
            ss.AddLast("ee");

            foreach (var item in ss)
                Console.WriteLine(item);
        }
        public static void testHashSet()
        {
            HashSet<string> ss = new HashSet<string>();
            ss.Add("aa");
            ss.Add("aa");
            ss.Add("cc");
            foreach (var item in ss)
                Console.WriteLine(item);
        }
        public static void testSortedSet()
        {
            SortedSet<string> ss = new SortedSet<string>();
            ss.Add("bb");
            ss.Add("cc");
            ss.Add("cc");
            foreach (var item in ss)
                Console.WriteLine(item);
        }
        public static void testSortedList()
        {
            SortedList<string, string> ss = new SortedList<string, string>();
            ss.Add("bb", "2");
            ss.Add("aa", "1");
            ss.Add("cc", "3");
            foreach (var key in ss.Keys)
                Console.WriteLine(ss[key]);

        }
        public static int[] testSortArr(int[] arr)
        {
            int temp = 0;
            for (int i = 0; i <= arr.Length - 1; i++)
            {
                for (int j = i + 1; j <= arr.Length - 1; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            return arr;
        }

        static int[] quicksort(int[] arr, int l, int r)
        {
            // Base case: No need to sort arrays of length <= 1
            if (l >= r)
            {
                return arr;
            }

            // Choose pivot to be the last element in the subarray
            int pivot = arr[r];

            // Index indicating the "split" between elements smaller than pivot and 
            // elements greater than pivot
            int cnt = l;

            int temp;
            // Traverse through array from l to r
            for (int i = l; i <= r; i++)
            {
                // If an element less than or equal to the pivot is found...
                if (arr[i] <= pivot)
                {
                    // Then swap arr[cnt] and arr[i] so that the smaller element arr[i] 
                    // is to the left of all elements greater than pivot
                    temp = arr[i];
                    arr[i] = arr[cnt];
                    arr[cnt] = temp;
                    // Make sure to increment cnt so we can keep track of what to swap
                    // arr[i] with
                    cnt++;
                }
            }

            // NOTE: cnt is currently at one plus the pivot's index 
            // (Hence, the cnt-2 when recursively sorting the left side of pivot)
            quicksort(arr, l, cnt - 2); // Recursively sort the left side of pivot
            quicksort(arr, cnt, r);   // Recursively sort the right side of pivot
            return arr;
        }

        public static List<int> gradingStudents(List<int> grades)
        {
            List<int> result = new List<int>();
            for (int i = 0; i <= grades.Count - 1; i++)
            {
                if (grades[i] < 38)
                    result.Add(grades[i]);
                else
                {
                    string str = grades[i].ToString();
                    string lastOne = str.Substring(str.Length - 1, 1);
                    if (lastOne == "3" || lastOne == "8")
                        result.Add(grades[i] + 2);
                    else if (lastOne == "4" || lastOne == "9")
                        result.Add(grades[i] + 1);
                    else
                    {
                        result.Add(grades[i]);
                    }

                }
            }
            return result;
        }
        public static int countNumber()
        {
            int total = 0;
            for (int i = 1; i < 1000; i++)
            {
                if (i % 3 == 0)
                    total += i;
                if (i % 3 != 0 && i % 5 == 0)
                {
                    total += i;
                }
            }
            Console.WriteLine(total);
            return total;
        }
        static void insertionSort1(int n, int[] arr)
        {
            List<string> list = new List<string>();
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                int temp = arr[i];
                int j = i;
                while (j > 0 && arr[j - 1] > temp)
                {
                    arr[j] = arr[j - 1];
                    j = j - 1;
                    list.Add(string.Join(" ", arr));
                }
                arr[j] = temp;
                if (!list.Contains(string.Join(" ", arr)))
                    list.Add(string.Join(" ", arr));
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        static void insertionSort2(int n, int[] arr)
        {
            int temp;
            int countRuntime = 0;
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[i])
                    {
                        temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                        countRuntime++;
                    }
                }
                Console.WriteLine(string.Join(" ", arr));
            }
            Console.WriteLine(countRuntime);
        }
        static int[] countingSort(int[] arr)
        {
            int[] index = new int[100];
            for (int i = 0; i <= arr.Length - 1; i++)
            {
                index[arr[i] - 1]++;
            }
            return index;
        }
        public static int recursiveSum(int[] arr, int total, int index, Dictionary<string, int> mem)
        {
            string key = total.ToString() + ":" + index.ToString();
            if (mem.ContainsKey(key))
                return mem[key];
            if (index > arr.Length - 1)
                return 0;
            if (arr[index] > total)
                return 0;
            if (arr[index] == total)
                return 1;
            if (arr[index] < total)
            {
                int result = recursiveSum(arr, total, index + 1, mem) + recursiveSum(arr, total - arr[index], index + 1, mem);
                mem[key] = result;
                return result;
            }
            return 0;
        }
        public static int PowerSum(double total, int n, int num)
        {
            Console.WriteLine(total + " " + num);
            double xNum = Math.Pow(num, n);
            if (xNum > total)
                return 0;
            if (xNum == total)
            {

                return 1;
            }
            if (xNum < total)
            {
                //Console.WriteLine(num);
                return PowerSum(total, n, num + 1) + PowerSum(total - xNum, n, num + 1);
            }
            return 0;
        }
        public static void GetList()
        {
            List<int> aa = new List<int> { 1, 1, 1 };
            List<int> bb = new List<int> { 0, 0 };
            var dd = from a in aa
                     from b in bb
                     select new int[] { a, b };
            foreach (var item in dd)
                Console.WriteLine(item[0] + " " + item[1]);
        }
        public static void CombArray(int[] c, int m, int n)
        {
            int numTwo = c.Where(o => o == 2).Count();
            int numZero = c.Where(o => o == 2).Count();
            string input = "";
            for (int i = 0; i <= c.Length - numZero - numTwo - 1; i++)
            {
                if (i <= m - numTwo - 1)
                    input += "1";
                else
                    input += "0";
            }
            //Console.WriteLine(input);
            //Console.WriteLine(swap("abc", 0, 2));
            List<string> result = new List<string>();
            for (int i = 0; i <= input.Length - 1; i++)
            {
                for (int j = 0; j <= input.Length - 1; j++)
                {
                    input = swap(input, i, j);
                    if (!result.Contains(input))
                        result.Add(input);
                }
            }
            //foreach (var item in result)
            //  Console.WriteLine(item);
            List<string> finalResult = new List<string>();
            List<string> finalResultTwo = new List<string>();
            for (int i = 0; i <= result.Count - 1; i++)
            {
                string temp = result[i];
                string tempTwo = swapNumber(temp);
                for (int j = 0; j <= c.Length - 1; j++)
                {
                    if (c[j] == 2)
                    {
                        if (j > temp.Length - 1)
                        {
                            temp = temp + "1";
                            tempTwo = tempTwo + "1";
                        }
                        else
                        {
                            temp = temp.Substring(0, j) + "1" + temp.Substring(j);
                            tempTwo = tempTwo.Substring(0, j) + "1" + tempTwo.Substring(j);
                        }
                    }
                    if (c[j] == 0)
                    {
                        if (j > temp.Length - 1)
                        {
                            temp = temp + "0";
                            tempTwo = tempTwo + "0";
                        }
                        else
                        {
                            temp = temp.Substring(0, j) + "0" + temp.Substring(j);
                            tempTwo = tempTwo.Substring(0, j) + "0" + tempTwo.Substring(j);
                        }
                    }
                }
                finalResult.Add(temp);
                finalResultTwo.Add(tempTwo);
            }
            foreach (var item in finalResult)
                Console.WriteLine(item);
            foreach (var item in finalResultTwo)
                Console.WriteLine(item);
        }
        public static string swap(string input, int i, int j)
        {
            string istr = input.Substring(i, 1);
            string jstr = input.Substring(j, 1);
            input = input.Substring(0, i) + jstr + input.Substring(i + 1);
            input = input.Substring(0, j) + istr + input.Substring(j + 1);
            return input;
        }
        public static string swapNumber(string item)
        {
            string temp = "";
            foreach (char c2 in item.ToCharArray())
            {
                if (c2 == '1')
                    temp += "0";
                else
                    temp += "1";
            }
            return temp;
        }
        public static int DynamicEqual(int[] arr)
        {
            arr = arr.OrderBy(o => o).ToArray();
            int result = 0;
            long sum = long.MaxValue;
            for (int k = 0; k <= 3; k++)
            {
                result = 0;
                for (int i = arr.Length - 1; i >= 0; i--)
                {
                    result += CountResult(arr[i] - arr[0] + k);
                }
                sum = sum < result ? sum : result;
            }
            return (int)sum;
        }
        private static int CountResult(int input)
        {
            int result = 0;
            result += input / 5 + (input % 5) / 2 + input % 5 % 2 / 1;
            return result;
        }
        public static long find_min_actions(int[] cookies)
        {

            cookies = cookies.OrderBy(o => o).ToArray();

            long sum = long.MaxValue;

            for (int b = 0; b < 3; b++)
            {
                int current_sum = 0;
                for (int i = 0; i < cookies.Length; i++)
                {
                    int delta = cookies[i] - cookies[0] + b;
                    current_sum += (int)delta / 5 + delta % 5 / 2 + delta % 5 % 2 / 1;
                }
                sum = Math.Min(current_sum, sum);
            }

            return sum;
        }
        public static int CountArray(int n, int k, int x)
        {
            for (int i = 0; i <= n - 3; i++)
            {

            }
            return 0;
        }
        public static void insertionSort(int[] A)
        {
            var j = 0;
            for (var i = 1; i < A.Length; i++)
            {
                var value = A[i];
                j = i - 1;
                while (j >= 0 && value < A[j])
                {
                    A[j + 1] = A[j];
                    j = j - 1;
                }
                A[j + 1] = value;
            }
            Console.WriteLine(string.Join(" ", A));
        }
        static int runningTime(int[] arr)
        {
            int temp;
            int countRuntime = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (arr[j] > arr[i])
                    {
                        temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                        countRuntime++;
                    }
                }
                Console.WriteLine(string.Join(" ", arr));
            }

            return countRuntime;
        }
        public static string superReducedString(string s)
        {
            for (int i = 0; i <= s.Length - 2; i++)
            {
                if (s.Substring(i, 1) == s.Substring(i + 1, 1))
                {
                    s = s.Substring(0, i) + s.Substring(i + 2);
                    i = -1;
                }
            }
            return s;

        }
        static int camelcase(string s)
        {
            char[] arr = s.ToCharArray();
            if (s.Trim() == "")
                return 0;
            return arr.Where(o => o < 'a').Count() + 1;


        }
        static int minimumNumber(int n, string password)
        {
            bool hasNumber = false;
            bool hasLower = false;
            bool hasUpper = false;
            bool hasSpecial = false;
            int result = 0;
            foreach (char item in password.ToCharArray())
            {
                if (item >= '0' && item <= '9')
                    hasNumber = true;
                else if (item >= 'a' && item <= 'z')
                    hasLower = true;
                else if (item >= 'A' && item <= 'Z')
                    hasUpper = true;
                else
                    hasSpecial = true;
            }
            if (!hasNumber)
                result += 1;
            if (!hasLower)
                result += 1;
            if (!hasUpper)
                result += 1;
            if (!hasSpecial)
                result += 1;
            return ((6 - password.Length) < result ? result : (6 - password.Length));
        }
        static int[] icecreamParlor(int m, int[] arr)
        {
            int[] result = new int[2];
            for (int i = 0; i <= arr.Length - 1; i++)
            {
                if (arr.Any(o => o == (m - arr[i])))
                {
                    result[0] = i + 1;
                    result[1] = Array.IndexOf(arr, m - arr[i], i + 1) + 1;
                    break;
                }

            }
            return result;

        }

        static void countApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            int apple = 0;
            int orange = 0;
            foreach (var item in apples)
            {
                if (item + a >= s && item + a <= t)
                    apple++;
            }
            foreach (var item in oranges)
            {
                if (item + b >= s && item + b <= t)
                    orange++;
            }
            Console.WriteLine(apple);
            Console.WriteLine(orange);

        }
        static string kangaroo(int x1, int v1, int x2, int v2)
        {
            if (v1 == v2)
            {
                if (x1 == x2)
                    return "YES";
                else
                    return "NO";
            }
            else
            {
                if (x1 > x2 && v1 > v2 || x1 < x2 && v1 < v2)
                    return "NO";
                if ((x1 - x2) % (v1 - v2) == 0)
                    return "YES";
                else
                    return "NO";
            }
        }
        public static int getTotalX(List<int> a, List<int> b)
        {
            a = a.OrderBy(o => o).ToList();
            b = b.OrderBy(o => o).ToList();
            int min = a.Last();
            int max = b.First();
            if (min > max)
                return 0;
            int sum = 0;
            for (int i = min; i <= max; i++)
            {
                bool qulified = true;
                for (int k = 0; k <= a.Count() - 1; k++)
                {
                    if (i % a[k] != 0)
                    {
                        qulified = false;
                        break;
                    }
                }
                for (int k = 0; k <= b.Count() - 1; k++)
                {
                    if (b[k] % i != 0)
                    {
                        qulified = false;
                        break;
                    }

                }
                if (qulified)
                    sum++;
            }
            return sum;
        }
        static int[] breakingRecords(int[] scores)
        {
            int[] result = new int[2];
            int lower = 0;
            int higher = 0;
            int min = scores[0];
            int max = scores[0];
            for (int i = 1; i <= scores.Length - 1; i++)
            {
                if (scores[i] > max)
                {
                    max = scores[i];
                    higher++;
                }
                if (scores[i] < min)
                {
                    min = scores[i];
                    lower++;
                }
            }
            result[0] = higher;
            result[1] = lower;
            return result;

        }
        static int birthday(List<int> s, int d, int m)
        {
            int result = 0;
            if (s.Count < m)
                return 0;
            for (int i = 0; i <= s.Count - 1; i++)
            {
                if (i + m > s.Count)
                    break;
                int days = 0;
                for (int j = i; j <= i + m - 1; j++)
                {
                    days += s[j];
                }
                if (days == d)
                    result++;
            }
            return result;
        }
        static int divisibleSumPairs(int n, int k, int[] ar)
        {
            int result = 0;
            for (int i = 0; i <= ar.Length - 1; i++)
            {
                for (int j = i + 1; j <= ar.Length - 1; j++)
                {
                    if ((ar[i] + ar[j]) % k == 0)
                        result++;
                }
            }
            return result;
        }

        static int migratoryBirds(List<int> arr)
        {
            int result = arr[0];
            arr = arr.OrderBy(o => o).ToList();
            int max = 1;
            int previousMax = 1;
            int previous = arr[0];
            for (int i = 1; i <= arr.Count - 1; i++)
            {
                if (arr[i] == previous)
                {
                    max++;
                }
                else
                {
                    if (max > previousMax)
                    {
                        previousMax = max;
                        result = arr[i - 1];
                    }
                    previous = arr[i];
                    max = 1;
                }
            }
            if (max > previousMax)
                return arr[arr.Count - 1];
            return result;
        }

        static string dayOfProgrammer(int year)
        {
            string result = "";
            if (year % 4 == 0 && year % 100 != 0)
            {
                result = "12";
            }
            else if (year % 400 == 0)
                result = "12";
            else
                result = "13";
            result += ".09." + year;
            return result;
        }
        static void bonAppetit(List<int> bill, int k, int b)
        {
            int sum = 0;
            for (int i = 0; i <= bill.Count - 1; i++)
            {
                sum += k == i ? 0 : bill[i];
            }

            Console.WriteLine((b - sum / 2) == 0 ? "Bon Appetit" : (b - sum / 2).ToString());

        }
        static int sockMerchant(int n, int[] ar)
        {
            int result = 0;
            ar = ar.OrderBy(o => o).ToArray();
            for (int i = 0; i < ar.Length; i++)
            {
                int sum = 1;
                for (int j = i + 1; j < ar.Length; j++)
                {
                    if (ar[i] == ar[j])
                        sum++;
                    else
                    {
                        result += sum > 1 ? sum / 2 : 0;
                        i = j - 1;
                        break;
                    }
                    if (j == ar.Length - 1)
                    {
                        i = j;
                        result += sum > 1 ? sum / 2 : 0;
                        break;
                    }
                }
            }
            return result;
        }

        static int pageCount(int n, int p)
        {
            /*
             * Write your code here.
             */
            if (n - p > p - 1)
                return p / 2;
            else
            if (n % 2 == 0)
                return (n - p + 1) / 2;
            else
                return (n - p) / 2;

        }

        static int countingValleys(int n, string s)
        {
            int result = 0;
            char[] arr = s.ToCharArray();
            int sum = 0;
            bool isValley = false;
            for (int i = 0; i <= arr.Length - 1; i++)
            {
                if (sum < 0)
                    isValley = true;
                sum += arr[i] == 'U' ? 1 : (arr[i] == 'D' ? -1 : 0);
                if (isValley && sum >= 0)
                {
                    result++;
                }
                if (sum >= 0)
                    isValley = false;
            }
            return result;
        }
        static int getMoneySpent(int[] keyboards, int[] drives, int b)
        {
            /*
             * Write your code here.
             */
            int sum = 0;
            for (int i = 0; i <= keyboards.Length - 1; i++)
            {
                for (int j = 0; j <= drives.Length - 1; j++)
                {
                    if (keyboards[i] + drives[j] <= b && keyboards[i] + drives[j] >= sum)
                    {
                        sum = keyboards[i] + drives[j];
                    }
                }
            }
            if (sum == 0)
                return -1;
            return sum;
        }

        static string catAndMouse(int x, int y, int z)
        {
            int a = Math.Abs(x - z);
            int b = Math.Abs(y - z);
            if (a == b)
                return "Mouse C";
            if (a > b)
                return "Cat B";
            if (b > a)
                return "Cat A";
            return "";

        }
        static int formingMagicSquare(int[][] s)
        {
            List<List<int>> squares = new List<List<int>>
{ new List<int> {8,1,6,3,5,7,4,9,2 },
  new List<int> {6,1,8,7,5,3,2,9,4 },
  new List<int> {4,9,2,3,5,7,8,1,6 },
  new List<int> {2,9,4,7,5,3,6,1,8 },
  new List<int> {8,3,4,1,5,9,6,7,2 },
  new List<int> {4,3,8,9,5,1,2,7,6 },
  new List<int> {6,7,2,1,5,9,8,3,4 },
  new List<int> {2,7,6,9,5,1,4,3,8 }};

            var arr = s.SelectMany(o => o).ToArray();
            var result = squares.Select(o => o.Zip(arr, (a, b) => (a - b)).Sum()).Min();
            return result;
        }
        public static int pickingNumbers(List<int> a)
        {
            int result = 0;
            for (int i = 0; i <= a.Count - 1; i++)
            {
                int sum1 = 0;
                int sum2 = 0;
                for (int j = 0; j <= a.Count - 1; j++)
                {
                    if (a[i] >= a[j] && a[i] - a[j] <= 1)
                        sum1++;
                    if (a[i] <= a[j] && a[j] - a[i] <= 1)
                        sum2++;
                }
                int sum = sum1 > sum2 ? sum1 : sum2;
                result = sum > result ? sum : result;
            }
            return result;
        }

        static int[] climbingLeaderboard(int[] scores, int[] alice)
        {
            int[] arr = new HashSet<int>(scores).ToArray();
            alice = alice.OrderBy(o => o).ToArray();
            List<int> result = new List<int>();
            int k = arr.Length - 1;
            for (int j = 0; j < alice.Length; j++)
            {
                for (int i = k; i >= 0; i--)
                {
                    if (alice[j] > arr[0])
                    {
                        result.Add(1);
                        break;
                    }
                    if (alice[j] < arr[arr.Length - 1])
                    {
                        result.Add(arr.Length + 1);
                        break;
                    }
                    if (arr[i] == alice[j])
                    {
                        result.Add(i + 1);
                        k = i;
                        break;
                    }
                    if (arr[i] < alice[j] && arr[i - 1] > alice[j])
                    {
                        k = i;
                        result.Add(i + 1);
                        break;
                    }

                }
            }
            foreach (var item in result)
                Console.WriteLine(item);
            return result.ToArray();
        }
        static int marsExploration(string s)
        {
            int sum = 0;
            for (int i = 0; i < s.Length - 1;)
            {
                string temp = s.Substring(i, 3);
                i = i + 3;
                if (temp == "SOS")
                    continue;
                else
                {
                    if (temp.Substring(0, 1) != "S")
                        sum++;
                    if (temp.Substring(1, 1) != "O")
                        sum++;
                    if (temp.Substring(2, 1) != "S")
                        sum++;
                }
            }
            return sum;
        }

        static string hackerrankInString(string s)
        {
            int k = 0;
            string[] arr = new string[] { "h", "a", "c", "k", "e", "r", "r", "a", "n", "k" };
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    k = s.IndexOf(arr[j]);
                    if (k >= 0)
                    {
                        if (j == arr.Length - 1)
                            return "YES";
                        i = 0;
                        s = s.Substring(k + 1);
                    }
                    else
                        return "NO";
                }
            }
            return "";
        }

        static string pangrams(string s)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            foreach (char item in alphabet)
            {
                if (s.ToLower().IndexOf(item) < 0)
                {
                    return "not pangram";
                }
            }
            return "pangram";
        }
        static int alternate(string s)
        {
            HashSet<char> hs = new HashSet<char>(s.ToCharArray());
            int max = 0;
            for (int i = 0; i < hs.Count; i++)
            {
                for (int j = i + 1; j < hs.Count; j++)
                {
                    string pattern = "([^" + hs.ElementAt(i) + hs.ElementAt(j) + "])";
                    string temp = Regex.Replace(s, pattern, "");
                    if (isTwoCharactors(temp))
                    {
                        max = max > temp.Length ? max : temp.Length;
                    }
                }
            }
            return max;
        }
        static bool isTwoCharactors(string s)
        {
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == s[i + 1])
                    return false;
            }
            return true;
        }
        static string caesarCipher(string s, int k)
        {
            string all = "abcdefghijklmnopqrstuvwxyz";
            //            char[] arr =all.ToCharArray();
            List<string> arr = new List<string>();
            for (int i = 0; i < s.Length; i++)
            {
                int index = all.IndexOf(s.Substring(i, 1).ToLower());
                if (index >= 0)
                {
                    int newIndex = index + k > 25 ? (index + k) % 26 : index + k;
                    string temp = (all.Substring(newIndex, 1));
                    if (char.IsUpper(char.Parse(s.Substring(i, 1))))
                    {
                        temp = temp.ToUpper();
                    }
                    arr.Add(temp);
                }
                else
                    arr.Add(s.Substring(i, 1));
            }
            return string.Join("", arr);

        }

        static string[] weightedUniformStrings(string s, int[] queries)
        {
            string all = "abcdefghijklmnopqrstuvwxyz";
            char[] arr = s.ToCharArray();
            HashSet<int> list = new HashSet<int>();
            int sum = all.IndexOf(arr[0]) + 1;
            char previous = arr[0];
            list.Add(sum);
            int index = sum;
            for (int i = 1; i < s.Length; i++)
            {
                if (arr[i] == previous)
                {
                    sum += index;
                }
                else
                {
                    index = arr[i] - 'a' + 1;
                    sum = index;
                }
                list.Add(sum);
                previous = arr[i];
            }
            string[] resultstr = new string[queries.Length];

            for (int i = 0; i < queries.Length; i++)
            {
                if (list.Contains(queries[i]))
                    resultstr[i] = "Yes";
                else
                    resultstr[i] = "No";
            }
            return resultstr;
        }
        static void separateNumbers(string s)
        {
            string first = "";
            string temp = "";
            for (int i = 1; i <= s.Length / 2; i++)
            {
                first = s.Substring(0, i);
                long x = long.Parse(first);
                temp = "";
                while (true)
                {
                    if (temp.Length >= s.Length)
                        break;
                    temp += x.ToString();
                    x++;
                }
                if (temp == s)
                {
                    break;
                }

            }
            if (temp == s)
            {
                Console.WriteLine("YES " + first);
            }
            else
                Console.WriteLine("NO");
        }
        static string funnyString(string s)
        {
            byte[] bt = System.Text.Encoding.ASCII.GetBytes(s);
            byte[] bt1 = bt.Reverse().ToArray();
            bool isNotFunny = false;
            for (int i = 0; i <= bt.Length - 2; i++)
            {
                if (Math.Abs(bt[i] - bt[i + 1]) != Math.Abs(bt1[i] - bt1[i + 1]))
                {
                    isNotFunny = true;
                    break;
                }
            }
            if (isNotFunny)
                return "Not Funny";
            else
                return "Funny";
        }
        static int gemstones(string[] arr)
        {
            string all = "abcdefghijklmnopqrstuvwxyz";
            int result = 0;
            foreach (var item in all.ToCharArray())
            {
                bool include = true;
                foreach (var item1 in arr)
                {
                    if (!item1.Contains(item))
                    {
                        include = false;
                        break;
                    }
                }
                if (include)
                    result++;
            }
            return result;

        }

        static int alternatingCharacters(string s)
        {
            string temp = s;
            while (true)
            {
                if (s.IndexOf("AA") < 0 && s.IndexOf("BB") < 0)
                    break;
                s = s.Replace("AA", "A");
                s = s.Replace("BB", "B");
            }
            return temp.Length - s.Length;

        }
        static int beautifulBinaryString(string b)
        {
            var a = b.Replace("010", "");
            return (b.Length - b.Replace("010", "").Length) / 3;
        }

        static HashSet<string> permute(char[] arry, int l, int r, HashSet<string> hs)
        {
            if (l == r)
                hs.Add(new string(arry));
            else
            {
                for (int i = l; i <= r; i++)
                {
                    swap(arry, l, i);
                    permute(arry, l + 1, r, hs);
                    swap(arry, l, i); //backtrack
                }
            }
            return hs;
        }

        static void swap(char[] arr, int l, int i)
        {
            char tmp;
            tmp = arr[l];
            arr[l] = arr[i];
            arr[i] = tmp;
        }
        static string swap1(string s)
        {
            string result = "";
            foreach (var item in s.ToArray())
            {
                result += item == '1' ? "0" : "1";
            }
            return result;
        }
        public static HashSet<string> test(int k, int m, int n, HashSet<string> hs)
        {
            HashSet<string> hs1 = new HashSet<string>();
            if (m == 0)
                return hs1;
            if (k == m + n)
                return hs;
            if (hs.Count == 0)
            {
                hs1.Add("1");
                hs1.Add("0");
            }
            else
            {
                for (int i = 0; i < hs.Count; i++)
                {
                    int iCount = hs.ElementAt(i).Split("1").Length - 1;
                    if (iCount < m)
                        hs1.Add(hs.ElementAt(i) + "1");
                    if (hs.ElementAt(i).Length - iCount < n)
                        hs1.Add(hs.ElementAt(i) + "0");
                }
            }
            test(k + 1, m, n, hs1);
            return hs;
        }
        public static HashSet<string> CombArrayZeroOneTwo(int[] c, int m, int n)
        {
            HashSet<string> hsTop = new HashSet<string>();
            HashSet<string> hsBottom = new HashSet<string>();
            for (int k = 0; k < c.Length; k++)
            {
                if (hsTop.Count == 0)
                {
                    if (c[k] == 0)
                    {
                        hsTop.Add("0");
                        hsBottom.Add("0");
                    }
                    if (c[k] == 2)
                    {
                        hsTop.Add("1");
                        hsBottom.Add("1");
                    }
                    if (c[k] == 1)
                    {
                        hsTop.Add("1");
                        hsTop.Add("0");
                        hsBottom.Add("1");
                        hsBottom.Add("0");
                    }
                    continue;
                }
                HashSet<string> hs1 = new HashSet<string>();
                HashSet<string> hs2 = new HashSet<string>();
                int iCount = hsTop.Count;
                for (int i = 0; i < iCount; i++)
                {
                    if (c[k] == 2)
                    {
                        hs1.Add(hsTop.ElementAt(i) + "1");
                        hs2.Add(hsBottom.ElementAt(i) + "1");
                        continue;
                    }
                    if (c[k] == 0)
                    {
                        hs1.Add(hsTop.ElementAt(i) + "0");
                        hs2.Add(hsBottom.ElementAt(i) + "0");
                        continue;
                    }
                    int iOne = hsTop.ElementAt(i).Split("1").Length - 1;
                    int iZero = hsTop.ElementAt(i).Split("0").Length - 1;
                    int iOne1 = hsBottom.ElementAt(i).Split("1").Length - 1;
                    int iZero1 = hsBottom.ElementAt(i).Split("0").Length - 1;
                    if (iOne < m)
                        hs1.Add(hsTop.ElementAt(i) + "1");
                    if (iZero1 < m)
                        hs2.Add(hsBottom.ElementAt(i) + "0");
                    if (iZero < n)
                        hs1.Add(hsTop.ElementAt(i) + "0");
                    if (iOne1 < n)
                        hs2.Add(hsBottom.ElementAt(i) + "1");
                }
                hsTop = hs1;
                hsBottom = hs2;
            }
            return hsTop;
        }
        static int utopianTree(int n)
        {
            double result = 1;
            if (n == 0)
                return 1;
            for (int i = 1; i <= n; i++)
            {
                result = result * (i % 2 == 0 ? 1 : 2) + (i % 2 == 0 ? 1 : 0);
            }
            return (int)result;
        }
        static string angryProfessor(int k, int[] a)
        {
            int ontime = a.Count(o => o <= 0);
            if (ontime >= k)
                return "NO";
            else
                return "YES";

        }
        static int beautifulDays(int i, int j, int k)
        {
            int result = 0;
            for (int x = i; x <= j; x++)
            {
                if ((reverse(x) - x) % k == 0)
                    result++;
            }
            return result;
        }
        public static int reverse(int number)
        {
            int reverse = 0;
            while (number != 0)
            {
                reverse = 10 * reverse + number % 10;
                number = number / 10;
            }
            return reverse;
        }
        static int viralAdvertising(int n)
        {
            int result = 2;
            int sum = 2;
            if (n == 1)
                return 2;
            else
            {
                for (int i = 2; i <= n; i++)
                {
                    result = result * 3 / 2;
                    sum += result;
                }
            }
            return sum;

        }
        static int saveThePrisoner(int n, int m, int s)
        {

            int a = s + m - 1;
            if (a > n)
            {
                if (a % n == 0)
                {
                    return n;
                }
                return a % n;
            }

            return a;
        }
        static int cookies(int k, int[] A)
        {
            int result = 0;
            int iLess = A.Count(o => o < k);
            int iMore = A.Count(o => o >= k);
            List<int> list = A.OrderByDescending(o => o).ToList();

            if (!list.Any(o => o < k))
                return 0;
            if (list.Count == 1 && list[0] < k)
                return -1;
            int iCount = list.Count;
            while (iCount > 1)
            {
                int sum = list[list.Count - 1] + 2 * list[list.Count - 2];
                if (sum >= k)
                {
                    return result + (int)Math.Ceiling((decimal)list.Count(o => o < k) / 2);
                }
                list.RemoveRange(list.Count - 2, 2);
                int index = list.Count(o => o >= sum);
                list.Insert(index, sum);
                result++;
                if (!list.Any(o => o < k))
                    break;
                iCount--;
            }
            if (list.Count > 0 && list[0] < k)
                return -1;
            return result;
        }
        static int[] reverseArray(int[] a)
        {
            int[] b = new int[a.Length];
            int j = 0;
            for (int i = a.Length - 1; i >= 0; i--)
            {
                b[j] = a[i];
                j++;
            }
            return b;
        }
        static int hourglassSum(int[][] arr)
        {
            int sum = 0, temp = 0;
            for (int i = 0; i < arr[0].Length - 2; i++)
            {
                temp = 0;
                for (int j = 0; j < arr.Length - 2; j++)
                {
                    temp = arr[j][i] + arr[j][i + 1] + arr[j][i + 2] + arr[j + 1][i + 1] + arr[j + 2][i] + arr[j + 2][i + 1] + arr[j + 2][i + 2];
                    if (i == 0 && j == 0)
                        sum = temp;
                    sum = temp > sum ? temp : sum;
                }
            }

            return sum;
        }
        static int[] matchingStrings(string[] strings, string[] queries)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < queries.Length; i++)
            {
                result.Add(strings.Count(o => (o == queries[i])));
            }
            return result.ToArray();
        }
        public static int solve(int h, List<int> wallPoints, List<int> lengths)
        {
            int result = 0;
            for (int i = 0; i < wallPoints.Count; i++)
            {
                int temp = (int)(Math.Ceiling((double)(wallPoints[i] - lengths[i] / 4)) - h);
                result = result > temp ? result : temp;
            }
            return result;
        }
        public static void solve(int n, List<int> a)
        {
            decimal result = a[0];
            a = a.OrderBy(o => o).ToList();
            int sum = a.Sum(o => o);
            int k = a.Count;
            for (int i = k - 1; i >= 0; i--)
            {
                if ((decimal)sum / (n - (k - 1 - i)) > a[i])
                {
                    result = (decimal)sum / (n - (k - 1 - i));
                    break;
                }
                sum -= a[i];
            }
            // Print your result
            Console.Write(result);

        }
        public static List<int> solve(int n, int m, List<int> h, List<List<int>> rounds)
        {
            List<int> result = new List<int>();
            foreach (List<int> round in rounds)
            {
                List<int> hSort = h.Where(o => o >= round[0] && o <= round[1]).OrderBy(o => o).ToList();
                long temp = 0;
                bool stop = false;

                for (int k = 1; k <= hSort.Count && !stop; k++)
                {
                    for (int i = 0; i < k && !stop; i++)
                    {
                        for (int j = 0; j < k && !stop; j++)
                        {
                            temp += hSort[i] + hSort[j];
                            if (temp >= round[2])
                            {
                                result.Add(hSort[k - 1]);
                                stop = true;
                                break;
                            }
                        }
                    }
                }
                if (temp < round[2])
                {
                    result.Add(-1);
                }
            }
            return result;

        }
        public static List<string> solve(List<string> names)
        {
            List<string> result = new List<string>();
            HashSet<string> compare = new HashSet<string>();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < names.Count; i++)
            {
                string currname = names[i];
                bool isPrefixFound = false;
                for (int j = 1; j <= currname.Length; j++)
                {
                    string prefix = currname.Substring(0, j);
                    if (!isPrefixFound && !compare.Contains(prefix))
                    {
                        result.Add(prefix);
                        isPrefixFound = true;
                    }
                    compare.Add(prefix);
                }
                int occu = 0;
                if (dict.ContainsKey(currname))
                {
                    occu = dict[currname];
                }
                occu++;
                if (!isPrefixFound)
                {
                    result.Add(currname + (occu >= 2 ? " " + occu : ""));
                }
                dict[currname] = occu;
            }
            return result;
        }
        public static int helperPolish(int index, string expression)
        {
            if (index == 0)
                return 0;
            int first = int.Parse(expression.Substring(index, 1));
            int second = int.Parse(expression.Substring(index + 1, 1));
            int lastindex = expression.Substring(0, index + 1).LastIndexOf("+");
            if (lastindex == -1)
            {
                lastindex = expression.Substring(0, index + 1).LastIndexOf("-");
                expression = expression.Substring(0, lastindex + 1) + expression.Substring(lastindex + 1);
                return first - second + helperPolish(index - 2, expression);
            }
            else
            {
                expression = expression.Substring(0, lastindex + 1) + expression.Substring(lastindex + 1);
                return first + second + helperPolish(index - 2, expression);
            }
        }
        public static string solve(int n, int k)
        {
            string all = "abcdefghijklmnopqrstuvwxyz";
            if (n == 1 && k == 1)
                return "a";
            if (n == 5 && k == 2)
                return "aabaa";
            string result = "";
            int x = 0;
            int y = 0;
            for (int i = k - 1; i >= 0 && k >= 3; i++)
            {
                y++;
                if (y == 1)
                    x = 1;
                if (y == 2)
                    x = 2;
                if (y >= 3)
                {
                    x = (int)Math.Pow(2, y - 1);
                    for (int j = 0; j < y - 3; j++)
                    {
                        x += (int)Math.Pow(2, j);
                    }
                }
                string curr = all.Substring(i, 1);
                for (int a = 0; a < x; a++)
                {
                    if (x == 1)
                        result = curr;
                    else
                    {
                        result = curr + result + curr;
                    }
                }

            }
            if (result.Length == n)
                return result;
            return "NONE";
        }
        static string solve(List<List<int>> board)
        {
            for (int i = 0; i < board.Count; i++)
            {
                for (int j = 0; j < board[i].Count; j++)
                {
                    int curr = board[i][j];
                    if (i - 1 >= 0 && board[i - 1][j] == curr)
                        return "No";
                    if (i + 1 < board[i].Count && board[i + 1][j] == curr)
                        return "No";
                    if (j - 1 >= 0 && board[i][j - 1] == curr)
                        return "No";
                    if (j + 1 < board.Count && board[i][j + 1] == curr)
                        return "No";
                }
            }

            return "Yes";
        }
        static int solve(List<int> a)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int result = 0;
            int first = 1, second = 1;
            for (int k = 0; k < a.Count; k++)
            {
                first = 1;
                for (int i = k; i < a.Count - 1 + k; i++)
                {
                    int x = i >= a.Count ? i - a.Count : i;
                    first *= a[x];
                    if (dict.ContainsKey(first))
                    {
                        if (dict[first] == 1)
                            result++;
                        continue;
                    }
                    second = 1;
                    for (int j = i + 1; j < a.Count + k; j++)
                    {
                        int y = j >= a.Count ? j - a.Count : j;
                        second *= a[y];
                    }
                    int gcdresult = (int)gcd((uint)first, (uint)second);
                    dict[first] = gcdresult;
                    if (gcdresult == 1)
                        result++;
                }
            }
            return result;
        }
        static ulong gcd(uint a, uint b)
        {
            while (b != 0 && a != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }
            return a == 0 ? b : a;
        }
        static int whoGetsTheCatch(int n, int x, int[] X, int[] V)
        {
            // Complete this function
            int result = -1;
            int duplicate = -1;
            decimal compare = int.MaxValue;
            for (int i = 0; i < X.Length; i++)
            {
                var curr = Math.Abs((decimal)(X[i] - x) / V[i]);
                if (compare >= curr)
                {
                    result = i;
                    if (compare == curr)
                        duplicate = result;
                    compare = curr;
                }
            }
            if (duplicate == result)
                return -1;
            return result;
        }
        // static long numberOfLists(long s, int m, int d)
        // {
        //     // Complete this function
        //     long result = 0;
        //     for (int i = 1; i <= m; i++)
        //     {
        //         for (int j = 0; j <= d; j++)
        //         {
        //             if (i + j > s)
        //                 break;
        //             if (i + j == s)
        //                 result++;
        //             if (i + j < s)
        //             {

        //             }
        //             if (i + j == 1)
        //                 result++;
        //             if (i + j == 2)
        //                 result += s - 1;
        //         }
        //     }
        // }
        static int[] f;
        public static int fib(int n)
        {
            // ----///use loop, dynamic programming
            // List<int> list = new List<int>();
            // list.Add(0);
            // list.Add(1);
            // int k=2;
            // while(k<=n){
            //     list.Add(list[k-1]+list[k-2]);
            //     k++;
            // }
            // return list[n];
            // -----////////////////// use recursion
            // if (n <= 1)
            //     return n;
            // else
            //     return fib(n - 1) + fib(n - 2);
            ///----space optimized 
            // int a=0,b=1,c=0;
            // if(n==0) return a;
            // for(int i=2;i<=n;i++){
            //     c=a+b;
            //     a=b;
            //     b=c;
            // }       
            // return b;     
            ///-----using power of matric {{1,1},{1,0}}
            int[,] F = new int[,] { { 1, 1 }, { 1, 0 } };
            if (n == 0)
                return 0;
            power(F, n - 1);
            return F[0, 0];
            // ///----using formula
            // double phi=(1+Math.Sqrt(5))/2;
            // return (int)Math.Round(Math.Pow(phi,n)/Math.Sqrt(5)); 
        }
        public static void multiply(int[,] F, int[,] M)
        {
            int[,] mul = new int[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    mul[i, j] = 0;
                    for (int k = 0; k < 2; k++)
                        mul[i, j] += F[i, k] * M[k, j];
                }

            }
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    F[i, j] = mul[i, j];

            // int x = F[0, 0] * M[0, 0] + F[0, 1] * M[1, 0];
            // int y = F[0, 0] * M[0, 1] + F[0, 1] * M[1, 1];
            // int z = F[1, 0] * M[0, 0] + M[1, 0] * F[1, 1];
            // int w = F[1, 0] * M[0, 1] + M[1, 1] * F[1, 1];

            // F[0, 0] = x;
            // F[0, 1] = y;
            // F[1, 0] = z;
            // F[1, 1] = w;
        }
        public static void power(int[,] F, int n)
        {
            //--matrix power
            // int[,] M = new int[,] { { 1, 1 }, { 1, 0 } };
            // for (int i = 2; i <= n; i++)
            // {
            //     multiply(F, M);
            // }
            ///---optimized
            if (n == 0 || n == 1)
                return;
            int[,] M = new int[,] { { 1, 1 }, { 1, 0 } };
            power(F, n / 2);
            multiply(F, F);
            if (n % 2 != 0)
                multiply(F, M);
        }
        static int MinOfCubedDP(int k)
        {
            int[] DP = new int[k + 1];
            int j = 1, t = 1;
            DP[0] = 0;
            for (int i = 1; i <= k; i++)
            {
                DP[i] = int.MaxValue;
                while (j <= i)
                {
                    if (j == i)
                        DP[i] = 1;
                    else if (DP[i] > DP[i - j])
                        DP[i] = DP[i - j] + 1;
                    t++;
                    j = t * t * t;
                }
                t = j = 1;
            }
            return DP[k];
        }
        public static int MinSquareCount(int n)
        {
            int[] result = new int[n + 1];
            result[0] = 0;
            int x = 1, y = 1;
            for (int i = 1; i <= n; i++)
            {
                result[i] = int.MaxValue;
                while (x <= i)
                {
                    if (x == i)
                        result[i] = 1;
                    else if (result[i] > result[i - x])
                        result[i] = result[i - x] + 1;
                    y++;
                    x = y * y;
                }
                x = y = 1;
            }
            return result[n];
        }
        public static int PaperCut(int m, int n)
        {
            if (m < n)
            {
                int temp = m;
                m = n;
                n = temp;
            }
            int result = 0;
            while (n > 0)
            {
                result += m / n;
                int rem = m % n;
                m = n;
                n = rem;
            }
            return result;
        }

        // static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        // {
        //     if (length == 1) return list.Select(t => new T[] { t });

        //     return GetPermutations(list, length - 1)
        //         .SelectMany(t => list.Where(e => !t.Contains(e)), (t1, t2) => t1.Concat(new T[] { t2 }));
        // }
        /////////////
        static void Main(string[] args)
        {
            Console.WriteLine("----");
            // HashSet<string> hash = new HashSet<string>();
            // generateAllBinaryStringsByPattern(new int[] { 2, 1, 0, 1 }, 0, 2, 2, hash);
            // for (int i = 0; i < hash.Count; i++)
            // {
            //     string temp = hash.ElementAt(i);
            //     int k = temp.ToCharArray().Count(o => o == '1' );
            //     if (k == 2)
            //     {
            //         Console.Write(temp+" ");
            //     }
            // }
            // Console.WriteLine();
            // for (int i = hash.Count-1; i >=0; i--)
            // {
            //     string temp = hash.ElementAt(i);
            //     int k = temp.ToCharArray().Count(o => o == '1' );
            //     if (k == 2)
            //     {
            //         Console.Write(temp+" ");
            //     }
            // }
            // int[][] arr = new int[][] { new int[] { -1, -1, 0, -9, -2, -2 }, new int[] { -2, -1, -6, -8, -2, -5 }, new int[] { -1, -1, -1, -2, -3, -4 } };
            // Console.WriteLine(GetPermutation("abc"));
            //Console.WriteLine(cookes(9, new int[] { 1, 62, 14 }));
            //Console.WriteLine(whoGetsTheCatch(4, 400, new int[] { 500, 500, 900, 200 }, new int[] { 2, 4, 25, 5 }));
            //CombArrayZeroOneTwo(new int[] { 2, 1, 0, 1 }, 2, 2);
            //Console.WriteLine(swap1("1100"));
            // var hs = permute("abc".ToArray(), 0, 2, new HashSet<string>());
            // foreach (var item in hs)
            //     Console.WriteLine(item);
            //int[][] arr = new int[3][] { new int[] { 4, 8, 2 }, new int[] { 4, 5, 7 }, new int[] { 6, 1, 6 } };
            //Console.WriteLine(weightedUniformStrings("abccddde", new int[3]));
            //Console.WriteLine(beautifulBinaryString("0101010"));
            //Console.WriteLine('a'>'A');
            //Console.WriteLine(8/3);
            //PrintAllCombinations pa = new PrintAllCombinations();
            //Console.WriteLine(sockMerchant(4, new int[] { 1, 1, 3, 1, 2, 1, 3, 3, 3, 3 }));
            //pa.printAllCombinations();
            //CombArray(arr, 3, 2);
            //   Console.WriteLine(recursiveSum(arr, 10, 0, new Dictionary<string, int>()));
            //insertionSort2(4, new int[] { 4, 4, 3, 4 });
            //Console.WriteLine(string.Compare("b","b"));   
            //testQuickSort(new int[] { 1, 2, 3, 4, 5, 5 }, 0, 5);
            // var arr = quicksort(new int[] { 1, 7, 8, 9,2, 10, 5 }, 0, 6);
            //testSortArr(new int[] { 4, 2, 3, 1, 5 });
            //testSortedSet();
            //testSortedList();
            //ReturnAllPossible ap = new ReturnAllPossible();
            //ap.ReturnAll(new int[]{1,1,2,0,1,1,2},4,4);
            //testHashSet();
            //testLinkedList();
            //testQueue();
            //testStack();
            //countNumber();
        }
    }
}
