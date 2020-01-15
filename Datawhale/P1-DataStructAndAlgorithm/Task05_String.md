
# 5 字符串
## 5.1 概念
* 串由n(n>=0)字符组成的有限序列
* 连续存储
* C#中，字符串创建后不可修改
## 5.2 基本操作
* 串长：GetLength()
* 串比较：Compare(StringDS s)
* 子串：SubString(int index, int len)
* 串连接：Concat(StringDS s)
* 串插入：Insert(int index, StringDS s)
* 串删除：Delete(int index, int len)
* 串定位：Index(StringDS s)
## 5.3 C#中的串
表示一个恒定不变的字符序列集合
不能被其他类继承，直接继承自object
是引用类型
在托管堆上而不是在吸纳从的堆栈上分配空间
对串的所有操作的结果都是生成了新串而没有改变原串
```cs
public sealed class String:IComparable,ICloneable,IConvertible,IComparable<string>,IEnumerable<char>,IEnumerable,IEquatable<string>
{
  public String(char[] value);
  public static bool operator !=(string a, string b);
  public static bool operator ==(string a, string b);
  public object Clone();
  public static int Compare(string strA, string strB);
  public iint Compare(string strB);
  public static int CompareOrdinal(string strA,string strB);
  public static string Concat(string str0, string str1);
  public static string Copy(string str);
  public void CopyTo(iint sourceIndex,char[] destination, int   destinationIndex, int count);
  public bool StartsWith(string value, StringComparison comparisonType);
  public bool EndsWith(string value, StriingComparison comparisonType);
  public static string Format(string format,object arg0);
  public int IndexOf(string value);
  public string Insert(int startIndex, string value);
  public string Remove(int startIndex, int count);
  public string Replace(string oldVlaue,string newValue);
  public string Substring(int startIndex, int length);
  public string ToLower();
  public string ToUpper();
  public string Trim(params char[] trimChars);
}

```

## 5.4 练习题
### 5.4.1 给定一个字符串，请你找出其中不含有重复字符的最长子串的长度。
[https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/](https://leetcode-cn.com/problems/longest-substring-without-repeating-characters/)
```
输入: "abcabcbb"
输出: 3 
```
解释: 因为无重复字符的最长子串是 "abc"，所以其长度为 3。
 
```
    public int LengthOfLongestSubstring(string s)
     {
        int start = 0;
        int len = 0 ;
        int[] str = new int[128];
        for(int i = 0;i<s.Length;i++)
        {
            start = Math.Max(str[s[i]],start);
            len = Math.Max(len,i - start +1);
            str[s[i]] = i +1;
        }
        return len;
    }
```

### 5.4.2 给定一个字符串s和一些长度相同的单词 words。找出 s 中恰好可以由 words 中所有单词串联形成的子串的起始位置。
[https://leetcode-cn.com/problems/substring-with-concatenation-of-all-words/](https://leetcode-cn.com/problems/substring-with-concatenation-of-all-words/)
注意子串要与 words 中的单词完全匹配，中间不能有其他字符，但不需要考虑 words 中单词串联的顺序。
```
输入：
  s = "barfoothefoobarman",
  words = ["foo","bar"]
输出：[0,9]
```
解释：
从索引 0 和 9 开始的子串分别是 "barfoo" 和 "foobar" 。输出的顺序不重要, [9,0] 也是有效答案。

```
	from collections import Counter
        if not s or not words:return []
        one_word = len(words[0])
        all_len = len(words) * one_word
        n = len(s)
        words = Counter(words)
        res = []
        for i in range(0, n - all_len + 1):
            tmp = s[i:i+all_len]
            c_tmp = []
            for j in range(0, all_len, one_word):
                c_tmp.append(tmp[j:j+one_word])
            if Counter(c_tmp) == words:
                res.append(i)
        return res
```

### 5.4.3 替换子串得到平衡字符串

[https://leetcode-cn.com/problems/replace-the-substring-for-balanced-string/](https://leetcode-cn.com/problems/replace-the-substring-for-balanced-string/)

有一个只含有`'Q'`, `'W'`, `'E'`,`'R'`四种字符，且长度为 `n`的字符串。假如在该字符串中，这四个字符都恰好出现`n/4`次，那么它就是一个「平衡字符串」。

给你一个这样的字符串 `s`，请通过「替换一个子串」的方式，使原字符串` s`变成一个「平衡字符串」。你可以用和「待替换子串」长度相同的任何其他字符串来完成替换。

请返回待替换子串的最小可能长度。

如果原字符串自身就是一个平衡字符串，则返回 0。

示例1：

```source-python
输入：s = "QWER"
输出：0
解释：s 已经是平衡的了。
```

示例2：

```source-python
输入：s = "QQWE"
输出：1
解释：我们需要把一个 'Q' 替换成 'R'，这样得到的 "RQWE" (或 "QRWE") 是平衡的。
```

示例3：

```source-python
输入：s = "QQQW"
输出：2
解释：我们可以把前面的 "QQ" 替换成 "ER"。 
```

示例4：

```source-python
输入：s = "QQQQ"
输出：3
解释：我们可以替换后 3 个 'Q'，使 s = "QWER"。
```
``` 
 public int BalancedString(string s) {
        int n = s.Length;
        int num = n/ 4 ;  //平均次数
        if(n < 4 || n % 4 >0)
            return 0;
        
        Dictionary<char, int> dict = new Dictionary<char, int>();
        string copyS = String.Copy(s);

        int l = copyS.Length;
        while(copyS.Length >0)
        {
            char c =Convert.ToChar(copyS.Substring(0,1)); 
            string str = copyS.Replace(c.ToString(),"");
            if(l-str.Length > num)
                dict.Add(c,l-str.Length-num);
            l = str.Length;
        }
       
        int result = 0;
        Queue<int> queue = new Queue<int>();
        for(int i = 0;i<s.Length;i++)
        {
            if(dict.ContainsKey(s[i]))
            {
                dict[s[i]]--;
                queue.Enqueue(i);

                bool check= true;
                foreach(var v in dict.Values)
                {
                    if(v>0)
                    {
                        check = false;
                        break;
                    }
                }

                if(check)
                {
                    while(queue.Count != 0)
                    {
                        int j = queue.Peek();
                        queue.Dequeue();

                        result = Math.Min(result, i - j +1);
                        dict[s[j]]++;
                        if(dict[s[j]] >0)
                        {
                            break;
                        }
                    }
                }
            }
        }
        return result;
    }
```
