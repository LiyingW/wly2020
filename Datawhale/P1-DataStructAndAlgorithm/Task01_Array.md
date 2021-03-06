
## 1数组
* 数组是一种常用的数据结构
* 可以看作是线性表的推广
* 数据元素多样，但必须属于同一数据类型
### 1.1 逻辑结构
数组是n(N>=1)个相同数据类型的数据元素的有限序列；
数组是具有固定格式和数量的数据有序集；
注意：在数据上不能进行插入、删除数据元素等操作
数组的操作：
* 取值：读取给定一组下标对应的数据元素
* 赋值：存储或修改给定一组下标对应的数据元素
* 清空
* 复制
* 排序：数据元素排序（元素为可排序）
* 反转：反转元素顺序
### 1.2 内存映像
数组是一种随机存储结构
有两种存储方法是：
* 以行为主序
* 以列为主序
### 1.3 C#中的数组
C#支持一维数组、多维数组、交错数组
数组在托管堆上分配空间，是引用类型；
```
常用方法
public abstract class Array : ICloneable, IList, ICollection, IEnumerable     
{
public bool IsFixedSize{get;}
public iint Length{get;}

//获取 Array 的秩（维数）。         
public int Rank { get; } 
 
//实现的 IComparable 接口，在.Array 中搜索特定元素。         
public static int BinarySearch(Array array, object value); 
 
//实现的 IComparable<T>泛型接口，在 Array 中搜索特定元素。   
public static int BinarySearch<T>(T[] array, T value); 
 
//实现 IComparable 接口，在 Array 的某个范围中搜索值。        
public static int BinarySearch(Array array, int index, int length,object value); 
 
//实现的 IComparable<T>泛型接口，在 Array 中搜索值。       
public static int BinarySearch<T>(T[] array,  int index, int length, T value); 
 
//Array 设置为零、false 或 null，具体取决于元素类型。    
public static void Clear(Array array, int index, int length); 
 
//System.Array 的浅表副本。      
public object Clone(); 
 
//从第一个元素开始复制 Array 中的一系列元素 //到另一 Array 中（从第一个元素开始）。      
public static void Copy(Array sourceArray,  Array destinationArray, int length);       

//将一维 Array 的所有元素复制到指定的一维 Array 中。       
public void CopyTo(Array array, int index); 
 
//创建使用从零开始的索引、具有指定 Type 和维长的多维 Array。 
public static Array CreateInstance(Type elementType,  params int[] lengths);

//返回 ArrayIEnumerator。      
public IEnumerator GetEnumerator(); 
 
//获取 Array 指定维中的元素数。       
public int GetLength(int dimension); 
 
//获取一维 Array 中指定位置的值。      
public object GetValue(int index); 

//返回整个一维 Array 中第一个匹配项的索引。       
public static int IndexOf(Array array, object value); 
 
//返回整个.Array 中第一个匹配项的索引。        
public static int IndexOf<T>(T[] array, T value); 
 
//返回整个一维 Array 中后一个匹配项的索引。      
public static int LastIndexOf(Array array, object value); 
 
//反转整个一维 Array 中元素的顺序。      
public static void Reverse(Array array); 
 
//设置给一维 Array 中指定位置的元素。      
public void SetValue(object value, int index); 
 
//对整个一维 Array 中的元素进行排序。     
public static void Sort(Array array); 
} 
```
### 1.4 练习部分
#### 练习一：利用动态数组解决数据存放问题

编写一段代码，要求输入一个整数N，用动态数组A来存放2~N之间所有5或7的倍数，输出该数组。
C#代码
```
static void Main(string[] args)
        {
            Console.WriteLine("N=");
            string str = Console.ReadLine();
            int n=0;
            if (int.TryParse(str, out n))
            {
                DArray<int> dArr = new DArray<int>();
                int j = 0;
                for (int i = 2; i <= n; i++)
                {
                    if (i%5 == 0 || i%7 == 0)
                    {
                        dArr.Append(i);
                    }
                }
                Console.Write(dArr);
            }
        }
```
#### 练习二：托普利茨矩阵问题
[https://leetcode-cn.com/problems/toeplitz-matrix/](https://leetcode-cn.com/problems/toeplitz-matrix/)

如果一个矩阵的每一方向由左上到右下的对角线上具有相同元素，那么这个矩阵是托普利茨矩阵。

给定一个M x N的矩阵，当且仅当它是托普利茨矩阵时返回True。
```
public class Solution {
    public bool IsToeplitzMatrix(int[][] matrix) 
    {
        for(int i = 0; i < matrix.Length - 1; i++)
        {
            for(int j = 0; j < matrix[i].Length - 1; j++)
            {
                if(matrix[i][j] != matrix[i+1][j+1])
                {
                    return false;
                }
            }
        }
        return true;
    }
}
```

#### 练习三：三数之和

[https://leetcode-cn.com/problems/3sum/](https://leetcode-cn.com/problems/3sum/)

给定一个包含 n 个整数的数组`nums`，判断`nums`中是否存在三个元素`a，b，c`，使得`a + b + c = 0`？找出所有满足条件且不重复的三元组。

注意：答案中不可以包含重复的三元组。
```
public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
            Array.Sort(nums);
            IList<IList<int>> all = new List<IList<int>>();
    
            int len = nums.Length;
            int x = 0, y, z;
            List<int> li;
            for (; x < len-1; x++)
            {
                if (nums[x] > 0)
                    break;
                if (x > 0 && nums[x] == nums[x - 1])
                    continue;
                z = x + 1;
                y=len - 1;
                while (z < y )
                {
                    int num = nums[x] + nums[y] + nums[z];
                    if (num > 0)
                        while (y>z && nums[y] == nums[--y]) ;
                    else if (num < 0)
                        while ( y>z &&  nums[z] == nums[++z]) ;
                    else
                    {
                        li = new List<int>();
                        li.Add(nums[x]);
                        li.Add(nums[z]);
                        li.Add(nums[y]);
                        all.Add(li);
                        while(y>x && nums[y]==nums[--y]);
                    }
                }
            }
            return all;
    }
}
```
