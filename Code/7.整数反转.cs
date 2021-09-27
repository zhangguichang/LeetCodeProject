/*
 * @lc app=leetcode.cn id=7 lang=csharp
 *
 * [7] 整数反转
 */

// @lc code=start
using System;
public class Solution
{
    public int Reverse(int x)
    {
        if (x == 0) return x;
        var index = "";
        var last = Math.Abs(x % 10);//3
        var front = Math.Abs(x / 10);//12
        Console.WriteLine("last->" + last);
        Console.WriteLine("front->" + front);
        index += last;
        while (front > 0)
        {
            last = front % 10;//2
            front = Math.Abs(front / 10);//1
            Console.WriteLine("last2->" + last);
            Console.WriteLine("front2->" + front);
            index += last;
        }
        // if(index.IndexOf("-")>1){
        //     index.Split("-","");
        //     return -Convert.ToInt32(index);
        // }
        Console.WriteLine("result" + index);
        return Convert.ToInt32(index);

    }
}
// @lc code=end

