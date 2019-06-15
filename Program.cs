using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Test obj = new Test();
            obj.test1();
            Console.WriteLine("------------");
            test2();
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
    class Test{
        public void test1(){
            int[] input= new int[]{1,2,3,4};
            if(input.Length%2==0){
                Console.WriteLine("even return 0");
            }
            if(input.Length%2==1){
                int result = 0;
                for(int i=0;i<=input.Length-1;i=i+2){
                    result=result^input[i];
                }
                Console.WriteLine(result);
            }

        }
    }
}
