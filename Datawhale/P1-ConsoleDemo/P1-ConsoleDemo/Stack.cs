using System;
using System.Collections.Generic;
using System.Text;

namespace P1_ConsoleDemo
{
    /// <summary>
    /// 车厢重排算法
    /// 使用入出栈
    /// </summary>
    public static class Stack
    {
       public  static bool RailRoad(int[] h,int k)
        {
            int n = h.Length;
            int noOut = 1;
            Stack<int>[] stacks = new Stack<int>[k];
            for (int i = 0; i < k; i++)
                stacks[i] = new Stack<int>();

            for(int i = 0; i<n;i++)
            {
                if (noOut == h[i])
                {
                    //符合出轨序号，直接进入出轨
                    Console.WriteLine("直接出轨：车厢号{0}直接出轨", h[i]);
                    noOut++;
                    //判断缓冲轨是否有可以出轨车厢
                    while (OutPut(stacks, noOut))
                        noOut++;
                }
                else
                {
                    //存入缓冲轨
                    if (!Hold(stacks, h[i]))
                        return false;
                }
            }

            return true;
        }
        #region 车厢入缓冲轨
        /// <summary>
        /// 车厢入缓冲轨
        /// </summary>
        /// <param name="stacks">缓冲轨栈</param>
        /// <param name="no">车厢号</param>
        /// <returns></returns>
        static bool Hold(Stack<int>[] stacks, int no)
        {
            int m = 0;  //最佳缓冲轨，默认第一轨
            int top = 0; //最佳缓冲轨栈顶元素，默认第一轨栈顶元素
            for (int i = 0; i < stacks.Length; i++)
            {
                if (stacks[i].Count == 0)
                {
                    m = top > no ? m: i;
                    top = no;
                    break;
                }
                else
                {
                    if (no < stacks[i].Peek())
                    {
                        if ( top == 0 || top > stacks[i].Peek())
                        {
                            top = stacks[i].Peek();
                            m = i;
                        }
                    }
                }
            }
            if (top == 0)
                return false;

            stacks[m].Push(no);
            Console.WriteLine("入缓冲轨：车厢号{0}入缓冲轨{1}", no, m + 1);

            return true;
        }
        #endregion

        #region 车厢出缓冲轨
        /// <summary>
        /// 车厢出缓冲轨
        /// </summary>
        /// <param name="stacks"></param>
        /// <param name="no"></param>
        /// <returns>是否有车厢从缓冲轨出</returns>
        static bool OutPut(Stack<int>[] stacks,int no)
        {
            for (int i = 0; i < stacks.Length; i++)
            {
                if (stacks[i].Count == 0)
                    continue;
                if(no == stacks[i].Peek())
                {
                    stacks[i].Pop();
                    Console.WriteLine("出缓冲轨：车厢号{0}出缓冲轨{1}", no, i + 1);

                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
