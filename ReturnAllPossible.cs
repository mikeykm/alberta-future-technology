using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
public class ReturnAllPossible
{
public void ReturnAll(int[] CList, int M, int N){
    List<List<int>> row1 = new List<List<int>>();
    List<List<int>> row2 = new List<List<int>>();

    foreach(int C in CList){
        int iCount=row1.Count;
        for(int i=iCount-1;i>=0;i--){
            if(row1[i].Where(o=>o==1).Count()>M||row2[i].Where(o=>o==1).Count()>N) {
                row1.RemoveAt(i);
                row2.RemoveAt(i);
                continue;
                }

            if(C==1){
            row1.AddRange(helperForOne(row1[i],false));
            row2.AddRange(helperForOne(row2[i],true));
            row1.RemoveAt(i);
            row2.RemoveAt(i);
            }
            if(C==2 ||C==0){
            row1[i]=helperForTowAndZero(row1[i],C);
            row2[i]=helperForTowAndZero(row2[i],C);
            }
        }
        if(iCount==0){
            if(C==1){
            row1.AddRange(helperForOne(new List<int>(),false));
            row2.AddRange(helperForOne(new List<int>(),true));
            }
            if(C==2 ||C==0){
            row1.Add(helperForTowAndZero(new List<int>(),C));
            row2.Add(helperForTowAndZero(new List<int>(),C));
            }
        
        }
    }
    for(int i=row1.Count-1;i>=0;i--){
        if(row1[i].Where(o=>o==1).Count()!=M)
            row1.RemoveAt(i); 
    }    
    for(int i=row2.Count-1;i>=0;i--){
        if(row2[i].Where(o=>o==1).Count()!=N)
            row2.RemoveAt(i); 
    }
    foreach(var item in row1){
        Console.WriteLine(string.Join("",item));
    }    
    foreach(var item in row2){
        Console.WriteLine(string.Join("",item));
    }    
}
public List<int> helperForTowAndZero(List<int> item,int C){
    if(C==0)
        item.Add(0);
    if(C==2)
        item.Add(1);
    return item;
}
public List<List<int>> helperForOne(List<int> item1,bool reverse){
    List<List<int>> list = new List<List<int>>();
    List<int> item2 = item1.GetRange(0,item1.Count);
    if(reverse){
    item1.Add(1);
    item2.Add(0);
    }else{
    item1.Add(0);
    item2.Add(1);
    }
    list.Add(item1);
    list.Add(item2);
    return list;
}

}
    