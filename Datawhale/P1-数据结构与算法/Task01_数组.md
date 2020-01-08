
## 1����
* ������һ�ֳ��õ����ݽṹ
* ���Կ��������Ա���ƹ�
* ����Ԫ�ض���������������ͬһ��������
### 1.1 �߼��ṹ
������n(N>=1)����ͬ�������͵�����Ԫ�ص��������У�
�����Ǿ��й̶���ʽ���������������򼯣�
ע�⣺�������ϲ��ܽ��в��롢ɾ������Ԫ�صȲ���
����Ĳ�����
* ȡֵ����ȡ����һ���±��Ӧ������Ԫ��
* ��ֵ���洢���޸ĸ���һ���±��Ӧ������Ԫ��
* ���
* ����
* ��������Ԫ������Ԫ��Ϊ������
* ��ת����תԪ��˳��
### 1.2 �ڴ�ӳ��
������һ������洢�ṹ
�����ִ洢�����ǣ�
* ����Ϊ����
* ����Ϊ����
### 1.3 C#�е�����
C#֧��һά���顢��ά���顢��������
�������йܶ��Ϸ���ռ䣬���������ͣ�
```
���÷���
public abstract class Array : ICloneable, IList, ICollection, IEnumerable     
{
public bool IsFixedSize{get;}
public iint Length{get;}

//��ȡ Array ���ȣ�ά������         
public int Rank { get; } 
 
//ʵ�ֵ� IComparable �ӿڣ���.Array �������ض�Ԫ�ء�         
public static int BinarySearch(Array array, object value); 
 
//ʵ�ֵ� IComparable<T>���ͽӿڣ��� Array �������ض�Ԫ�ء�   
public static int BinarySearch<T>(T[] array, T value); 
 
//ʵ�� IComparable �ӿڣ��� Array ��ĳ����Χ������ֵ��        
public static int BinarySearch(Array array, int index, int length,object value); 
 
//ʵ�ֵ� IComparable<T>���ͽӿڣ��� Array ������ֵ��       
public static int BinarySearch<T>(T[] array,  int index, int length, T value); 
 
//Array ����Ϊ�㡢false �� null������ȡ����Ԫ�����͡�    
public static void Clear(Array array, int index, int length); 
 
//System.Array ��ǳ������      
public object Clone(); 
 
//�ӵ�һ��Ԫ�ؿ�ʼ���� Array �е�һϵ��Ԫ�� //����һ Array �У��ӵ�һ��Ԫ�ؿ�ʼ����      
public static void Copy(Array sourceArray,  Array destinationArray, int length);       

//��һά Array ������Ԫ�ظ��Ƶ�ָ����һά Array �С�       
public void CopyTo(Array array, int index); 
 
//����ʹ�ô��㿪ʼ������������ָ�� Type ��ά���Ķ�ά Array�� 
public static Array CreateInstance(Type elementType,  params int[] lengths);

//���� ArrayIEnumerator��      
public IEnumerator GetEnumerator(); 
 
//��ȡ Array ָ��ά�е�Ԫ������       
public int GetLength(int dimension); 
 
//��ȡһά Array ��ָ��λ�õ�ֵ��      
public object GetValue(int index); 

//��������һά Array �е�һ��ƥ�����������       
public static int IndexOf(Array array, object value); 
 
//��������.Array �е�һ��ƥ�����������        
public static int IndexOf<T>(T[] array, T value); 
 
//��������һά Array �к�һ��ƥ�����������      
public static int LastIndexOf(Array array, object value); 
 
//��ת����һά Array ��Ԫ�ص�˳��      
public static void Reverse(Array array); 
 
//���ø�һά Array ��ָ��λ�õ�Ԫ�ء�      
public void SetValue(object value, int index); 
 
//������һά Array �е�Ԫ�ؽ�������     
public static void Sort(Array array); 
} 
```
### 1.4 ��ϰ����
#### ��ϰһ�����ö�̬���������ݴ������

��дһ�δ��룬Ҫ������һ������N���ö�̬����A�����2~N֮������5��7�ı�������������顣
C#����
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
#### ��ϰ�����������ľ�������
[https://leetcode-cn.com/problems/toeplitz-matrix/](https://leetcode-cn.com/problems/toeplitz-matrix/)

���һ�������ÿһ���������ϵ����µĶԽ����Ͼ�����ͬԪ�أ���ô����������������ľ���

����һ��M x N�ľ��󣬵��ҽ��������������ľ���ʱ����True��
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

#### ��ϰ��������֮��

[https://leetcode-cn.com/problems/3sum/](https://leetcode-cn.com/problems/3sum/)

����һ������ n ������������`nums`���ж�`nums`���Ƿ��������Ԫ��`a��b��c`��ʹ��`a + b + c = 0`���ҳ��������������Ҳ��ظ�����Ԫ�顣

ע�⣺���в����԰����ظ�����Ԫ�顣
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
