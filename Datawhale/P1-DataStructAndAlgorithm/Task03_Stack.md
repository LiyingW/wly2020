
# 3. 栈与递归

## 3.1 栈 Stack
是操作限定在表的尾端进行的线性表
表为进行插入、删除等操作
表尾称为栈顶top，另一端固定叫栈底bottom
没有数据元素的栈叫空栈Empty Stack
S = （a<sub>1</sub>,a<sub>2</sub>,...,a<sub>n</sub>)
a<sub>1</sub> 栈底元素
a<sub>n</sub>栈顶元素
出入栈顺序：先进后出，后进先出
S=（D，R） D是数据元素的有限集合，R是数据元素之间关系的有限集合
栈的操作：栈顶插入、删除元素，取栈顶元素，判断栈是否为空
## 3.2 顺序栈
用连续的存储空间来存储栈中的数据元素，称为顺序栈 Sequence Stack 。一维数据存放顺序栈中的数据元素。
~~~cs
public class SeqStack<T>:IStack<T>{
    private int maxsize;
    private T[] data;  //顺序栈中的数据元素
    private int top;  //顺序栈的栈顶
}
~~~
## 3.3 链栈
链式存储的栈成为链栈Linked Stack
通常用单链表来表示，是单链表的简化
栈顶设在链表头部，不需要头结点
链栈节点类Node<T> 的实现
~~~cs
public class Node<T>
{
    private T data;  //数据域
    private Node<T> next;  //引用域
}
~~~
链栈类LinkStack<T> 的实现
~~~cs
public class LinkStack<T>:IStack<T>{
    private Node<T> top;  //栈顶指示器
    private int num; // 栈中结点的个数
}
~~~
链栈的基本操作：
* 求链栈的长度 GetLength()
* 清空操作Clear()
* 判断链栈是否为空IsEmpty()
* 入栈操作Push()
* 出战操作Pop()
* 获取链顶结点的值GetTop()

## 3.4 递归
一个算法直接调用自己或间接调用自己，就称这个算法是诋毁Recursive.
* 调用方式不同：直接递归Direct Recursion、简介递归 Indirect Recursion
* 必须有两个部分：初始部分、递归部分
* 递归调用的理解：通过一系列的自身调用，达到某一终止条件后，在按照嗲用路线逐步返回。

## 3.5 练习题
### 3.5.1 
根据要求完成车辆重排的程序代码

假设一列货运列车共有`n`节车厢，每节车厢将停放在不同的车站。假定`n`个车站的编号分别为`1`至`n`，货运列车按照第`n`站至第`1`站的次序经过这些车站。车厢的编号与它们的目的地相同。为了便于从列车上卸掉相应的车厢，必须重新排列车厢，使各车厢从前至后按编号`1`至`n`的次序排列。当所有的车厢都按照这种次序排列时，在每个车站只需卸掉最后一节车厢即可。

我们在一个转轨站里完成车厢的重排工作，在转轨站中有一个入轨、一个出轨和`k`个缓冲铁轨（位于入轨和出轨之间）。图（a）给出一个转轨站，其中有`k`个（`k=3`）缓冲铁轨`H1`，`H2` 和`H3`。开始时，`n`节车厢的货车从入轨处进入转轨站，转轨结束时各车厢从右到左按照编号`1`至`n`的次序离开转轨站（通过出轨处）。在图（a）中，`n=9`，车厢从后至前的初始次序为`5，8，1，7，4，2，9，6，3`。图（b）给出了按所要求的次序重新排列后的结果。

[![具有三个缓冲区铁轨的转轨站](https://upload-images.jianshu.io/upload_images/15936123-1c0e25f02e71e40f?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)](https://camo.githubusercontent.com/86edbf1123e9773856c1b48c8170d68832d2f622/68747470733a2f2f696d672d626c6f672e6373646e696d672e636e2f32303139313232323231353835393937342e706e67) 

编写算法实现火车车厢的重排，模拟具有`n`节车厢的火车“入轨”和“出轨”过程。

~~~cs
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
~~~

