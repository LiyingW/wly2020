using System;
using System.Threading;

namespace P1_ConsoleDemo
{
    class Program
    {
        /// <summary>
        /// 银行排队叫号
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                IBankQueue bankQueue = null;
                Console.WriteLine("请选择存储结构类型：1.顺序队列，2.链队列");
                string flag = Console.ReadLine();
                switch(flag)
                {
                    case "1":
                        Console.WriteLine("请输入队列可容纳人数：");
                        int count = Convert.ToInt32(Console.ReadLine());
                        bankQueue = new CSeqBankQueue(count);
                        break;
                    case "2":
                        bankQueue = new LinkBankQueue();
                        break;
                }
                int windowsnum = 5;
                ServiceWindow[] serviceWindows = new ServiceWindow[windowsnum];
                Thread[] serviceThread = new Thread[windowsnum];
                for (int i = 0; i < windowsnum; i++)
                {
                    serviceWindows[i] = new ServiceWindow();
                    serviceWindows[i].Bankq = bankQueue;
                    serviceThread[i] = new Thread(serviceWindows[i].service);
                    serviceThread[i].Name = (i + 1).ToString();
                    serviceThread[i].Start();
                }

                while(true)
                {
                    Console.WriteLine("点击获取号码：");
                    Console.ReadLine();
                    if (bankQueue != null && (bankQueue.GetLength() < bankQueue.MaxSize || flag == "2"))
                    {
                        int callnumber = bankQueue.GetCallNum();
                        Console.WriteLine("{2}：您的号码时：{0}，前面还有{1}位等待。", callnumber, bankQueue.GetLength(),DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        bankQueue.In(callnumber);
                    }
                    else
                        Console.WriteLine("请重试");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
            }
        }



        #region 车厢重拍
        ///// <summary>
        ///// 车厢重拍
        ///// </summary>
        ///// <param name="args"></param>
        //static void Main(string[] args)
        //{
        //    int[] h = new int[] { 5, 3, 6, 8, 4, 1, 2, 9, 7 };
        //    int k = 3;
        //    bool result = Stack.RailRoad(h, k);

        //    while (result == false)
        //    {
        //        Console.WriteLine("缓冲轨道数量不满足使用，请输入数字扩充。");
        //        k = k + Convert.ToInt32(Console.ReadLine());
        //        result = Stack.RailRoad(h, k);
        //    }

        //} 
        #endregion
    }
}
