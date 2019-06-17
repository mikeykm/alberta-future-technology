using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //test2();
            ReturnAllPossible ap = new ReturnAllPossible();
            ap.ReturnAll(new int[]{1,1,2,0,1,1,2},4,4);
        }
        public static void test2(){
            List<int> list = new List<int>();
            list.Add(33);
            list.Add(38);
            list.Add(84);
            foreach(var item in gradingStudents(list))
            Console.WriteLine(item);
        }
        public static List<int> gradingStudents(List<int> grades)
        {
            List<int> result = new List<int>();
            for(int i=0;i<=grades.Count-1;i++){
                if(grades[i]<38)
                    result.Add(grades[i]);
                else{
                    string str = grades[i].ToString();
                    string lastOne = str.Substring(str.Length-1,1);
                    if(lastOne=="3" ||lastOne=="8")
                        result.Add(grades[i]+2);
                    else if(lastOne=="4" ||lastOne=="9")
                        result.Add(grades[i]+1);
                    else
                    {
                        result.Add(grades[i]);
                    }
                    
                }    
            }
            return result;
        }
    }
}
