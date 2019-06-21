using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arr = new int[] { 1, 2, 1, 0, 1 };
            CombArray(arr, 3, 2);
            //   Console.WriteLine(recursiveSum(arr, 10, 0, new Dictionary<string, int>()));
            //insertionSort2(4, new int[] { 4, 4, 3, 4 });
            //Console.WriteLine(string.Compare("b","b"));   
            //testQuickSort(new int[] { 1, 2, 3, 4, 5, 5 }, 0, 5);
            // var arr = quicksort(new int[] { 1, 7, 8, 9,2, 10, 5 }, 0, 6);
            foreach (var item in arr)
            {
                //Console.WriteLine(item);
            }
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
    }
}
