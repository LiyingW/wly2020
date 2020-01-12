using System;
using System.Collections.Generic;
using System.Text;

namespace P1_ConsoleDemo
{
   public interface IQueue<T>
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
}
