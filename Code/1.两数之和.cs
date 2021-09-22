/*
 * @lc app=leetcode.cn id=1 lang=csharp
 *
 * [1] 两数之和
 */

// @lc code=start
using System.Collections;
using System.Collections.Generic;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
         for (int i = 0; i < nums.Length; i++)
         {
             var curr =nums[i];
             for (int j =i+1; j <nums.Length; j++)
             {
                 var next =nums[j];
                 if(curr+next==target){
                     return new int[]{i,j};
                 }
             }
         }
         return new int[]{0};

        // var hash = new Dictionary<int, int>();
        // hash.Add(nums[0],0);
        // for (int i = 0; i < nums.Length; ++i)
        // {
        //     var currNum = nums[i];
        //     var sub = target - currNum;
        //     if (hash.ContainsKey(sub))
        //     {
        //         hash.TryGetValue(sub, out var value);
        //         return new int[] { value, i };
        //     }
        //     hash.Add(currNum, i);
        // }
        // return new int[] { 0 };
    }
}
// @lc code=end

