
# 4 队列 Queue
## 4.1 队列的定义及运算
* 是插入操作限定在表的尾部而其他操作限定在表的头部进行的线性表
* 当队列中没有数据元素是成为空队列Empty Queue
* 队列的操作是先进先出or 后进后出 （First In First Out  / Last In Last Out ）
* Q = (D,R)  D 是数据元素的有限集合，R是数据元素之间关系的有限集合
* 操作：
队尾插入、队头删除、去队头元素和判断队列是否为空
* 和栈一样，队列的元素是定义在逻辑结构层次上，而运算的具体实现是建立在物理存储结构层次上
* C#中，队列是从IEnumerable<T>、ICollection和IEnumberable 接口继承而来

```cs
public interface IQueu<T>{
      int GetLength();
      bool IsEmpty();
      void Clear();
      void In(T item);  //将值为item的新数据元素添加到队尾
      T Out();     //将队头元素从队列中取出，队列发生变化
      T GetFront();   //取队头元素的值，队列不发生变化
}
```
## 4.2 顺序队列
用一片连续的存储空间来存储队列中的数据元素，这样的队列成为顺序队列 Sequence Queue ，类似与顺序栈。
* front 队头指示器，rear 队尾指示器
* 当队列为空时，front = rear = -1
* 数据元素入队，rear + 1
* 数据元素出队，front +1
* rear 达到数据上限而front 为-1时，队列为满
## 4.3 循环顺序队列
将顺序队列堪称时首位相接的循环结构，头尾指示器的关系不变
```cs
public class CSeqQueue<T>:IQueue<T>{
  private int maxsize;
  private T[] data;
  private int front;
  private int rear;

  public int GetLength()
  {
    return (rear - front + maxsize)%maxsize;
  }
  public void Clear()
  {
     front = rear = -1; 
  }
  public bool IsEmpty()
  {  
    if(front == rear)
    {
      return true;
    }
    else
    {
      return false;
    }
  }
  public bool IsFull()
  {
    // (rear + 1)% maxsize 等于 front 
  }
  public void In(T item)
  {
    // data[++rear] = item;
  }
  public T Out()
  {
    T tmp = default(T);
    if(IsEmpty())
    {
      Console.WriteLine("Queue is empty");
      return tmp;
    }
    tmp = data[++front];
    return tmp;
  }
  public T GetFront()
  {
    //IsEmpty判断
    return data[front+1];
  }
```

## 4.4 链队列
队列的另一种存储方式时链式存储，称为链队列 Linked Queue
* 通常用单链表来表示，它的实现时单链表的简化

* 链队列长度：GetLength()  //return num
* 清空操作：Clear()   //front = rear = null;  num = 0;
* 链队列是否为空 IsEmpty()  // front == rar  &&  num == 0
* 入队操作：In()
 ```cs
Node<T> q = new Node<T>(item);
if(rear == null)
{
  front = rear = q;
}
else
{
  rear.Next = q;
  rear = q;
}
num++;
``` 
* 出队操作：Out()
```cs
public T Out()
{
  if(IsEmpty())
  {
    Console.WriteLine("Queue is empty");
    return default(T);
  }
  Node<T> p = front;
  front = front.Next;
  --num;
  return p.Data;
}

```     
* 获取链队列头结点的值：GetFront() //  return front.Data;

## 4.5 练习
### 4.5.1 模拟银行服务完成程序代码。

目前，在以银行营业大厅为代表的窗口行业中大量使用排队（叫号）系统，该系统完全模拟了人群排队全过程，通过取票进队、排队等待、叫号服务等功能，代替了人们站队的辛苦。

排队叫号软件的具体操作流程为：

顾客取服务序号
当顾客抵达服务大厅时，前往放置在入口处旁的取号机，并按一下其上的相应服务按钮，取号机会自动打印出一张服务单。单上显示服务号及该服务号前面正在等待服务的人数。

服务员工呼叫顾客 服务员工只需按一下其柜台上呼叫器的相应按钮，则顾客的服务号就会按顺序的显示在显示屏上，并发出“叮咚”和相关语音信息，提示顾客前往该窗口办事。当一位顾客办事完毕后，柜台服务员工只需按呼叫器相应键，即可自动呼叫下一位顾客。
编写程序模拟上面的工作过程，主要要求如下：

程序运行后，当看到“请点击触摸屏获取号码：”的提示时，只要按回车键，即可显示“您的号码是：XXX，您前面有YYY位”的提示，其中XXX是所获得的服务号码，YYY是在XXX之前来到的正在等待服务的人数。
用多线程技术模拟服务窗口（可模拟多个），具有服务员呼叫顾客的行为，假设每个顾客服务的时间是10000ms，时间到后，显示“请XXX号到ZZZ号窗口！”的提示。其中ZZZ是即将为客户服务的窗口号。

IQueue接口、循环顺序队列、链队列

```
 interface IQueue<T>
    {
        int GetLength();
        bool IsEmpty();
        void Clear();
        void In(T item);
        T Out();
        T GetFront();
    }
    #region 循环顺序队列
    /// <summary>
    /// 循环顺序队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CSeqQueue<T> : IQueue<T>
    {
        private int maxsize;
        private T[] data;
        private int front;
        private int rear;
        public T this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
        public int MaxSize { get { return maxsize; } set { maxsize = value; } }
        public int Front { get { return front; } set { front = value; } }

        public int Rear { get { return rear; } set { rear = value; } }

        public CSeqQueue(int size)
        {
            data = new T[size];
            maxsize = size;
            front = rear = -1;
        }

        public int GetLength()
        {
            return (rear - front + maxsize) % maxsize;
        }

        public void Clear()
        {
            front = rear = -1;
        }
        public bool IsEmpty()
        {
            if (front == rear)
                return true;
            return false;
        }
        public bool IsFull()
        {
            if ((rear + 1) % maxsize == front)
                return true;
            return false;
        }
        public void In(T item)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue is Full");
                return;
            }
            data[++rear] = item;
        }

        public T Out()
        {
            T tmp = default(T);
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return tmp;
            }
            tmp = data[++front];
            return tmp;
        }
        public T GetFront()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return default(T);
            }
            return data[front + 1];
        }
    }
    #endregion

    #region 链队列结点类
    /// <summary>
    /// 链队列结点类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        private T data;
        private Node<T> next;

        public Node(T val, Node<T> p)
        {
            data = val;
            next = p;
        }
        public Node(Node<T> p)
        {
            next = p;
        }
        public Node(T val)
        {
            data = val;
            next = null;
        }
        public Node()
        {
            data = default(T);
            next = null;
        }

        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }
    }
    #endregion

    #region 链队列
    /// <summary>
    /// 链队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkQueue<T> : IQueue<T>
    {
        private Node<T> front;
        private Node<T> rear;
        private int num;  //队列结点个数

        public Node<T> Front { get { return front; } set { front = value; } }
        public Node<T> Rear { get { return rear; } set { rear = value; } }
        public int Num { get { return num; } set { num = value; } }
        public LinkQueue()
        {
            front = rear = null;
            num = 0;
        }
        public int GetLength()
        {
            return num;
        }
        public void Clear()
        {
            front = rear = null;
            num = 0;
        }
        public bool IsEmpty()
        {
            if((front == rear) && (num == 0))
                return true;
            return false;
        }
        public void In(T item)
        {
            Node<T> q = new Node<T>(item);
            if(rear == null)
            {
                front = rear = q;
            }
            else
            {
                rear.Next = q;
                rear = q;
            }
            num++;
        }

        public T Out()
        {
            if(IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return default(T);
            }
            Node<T> p = front;
            front = front.Next;
            if(front == null)
            {
                rear = null;
            }
            --num;
            return p.Data;
        }
        public T GetFront()
        {
            if(IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return default(T);
            }
            return front.Data;
        }
    }
    #endregion
```

```
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
```

main 
```cs
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

```