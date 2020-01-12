using System;
using System.Collections.Generic;
using System.Threading;

namespace P1_ConsoleDemo
{

    public interface IBankQueue:IQueue<int>
    {
        int GetCallNum();
        int MaxSize { get; }
    }

    public  class LinkBankQueue:LinkQueue<int>,IBankQueue
    {
        public int CallNumber { get; set; }
        public int MaxSize { get; }

        public LinkBankQueue()
        {
            MaxSize = default(int);
            CallNumber = 0;
        }
        public int GetCallNum()
        {
            if(IsEmpty() && CallNumber ==0)
            {
                CallNumber = 1;
            }
            else
            {
                CallNumber++;
            }
            return CallNumber;
        }
    }

    public class CSeqBankQueue:CSeqQueue<int>,IBankQueue
    {
        public int Callnumber { get; private set; }
        //public int MaxSize { get; }
        public CSeqBankQueue(int size):base(size)
        {
            Callnumber = 0;
        }
        public int GetCallNum()
        {
            if (IsEmpty() && Callnumber == 0)
                Callnumber = 1;
            else
                Callnumber++;
            return Callnumber;
        }
    }


    public class ServiceWindow
    {
        public IBankQueue Bankq { get; set; }
        public void service()
        {
            while(true)
            {
                lock(Bankq)
                {
                    Thread.Sleep(10000);
                    if(!Bankq.IsEmpty())
                    {
                        Console.WriteLine();
                        Console.WriteLine("{2}：请{0}号到{1}号窗口", Bankq.GetFront(), Thread.CurrentThread.Name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        Bankq.Out();
                    }
                }
            }
        }
    }
}
