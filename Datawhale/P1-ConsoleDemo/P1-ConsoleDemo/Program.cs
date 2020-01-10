using System;

namespace P1_ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] h = new int[]{5, 3, 6, 8, 4, 1, 2,9, 7};
            int k = 3;
            bool result = Stack.RailRoad(h, k);

            while (result == false)
            {
                Console.WriteLine("缓冲轨道数量不满足使用，请输入数字扩充。");
                k = k + Convert.ToInt32(Console.ReadLine());
                result = Stack.RailRoad(h, k);
            }

        }
    }
}
