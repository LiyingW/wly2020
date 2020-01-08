# 2顺序表和链表
## 2.1 线性表
* 线性表是最简单、最基本、最常用的数据结构；
* 特定是数据元素之间存在一对一的线性关系；
* 除开始、结束数据元素外，其他数据元素都有且仅有一个直接前驱和直接后续；
* 两种存储结构：顺序存储和链式存储
## 2.2 顺序表
顺序存储的线性表叫顺序表，
表中存储单元连续，C#中用数组来实现
## 2.3 链表
链式存储的线性表是链表，存储单元不一定连续
在一个节点中，还有数据域存放数据元素本身信息，还有引用域存储其相邻的数据元素的地址信息。
* 单链表：只有一个引用域，村方其后直接后续节点的地址信息
* 双向链表：有两个引用域，存放其直接前驱节点和直接后续节点的地址信息
* 循环链表：最后一个及地点的引用域存放其头引用的值。
## 2.4 顺序表与链表
* 顺序表：随机存储，查找效率高，但插入和删除需要移动大量元素，效率低
* 联播啊：存储空间不要求连续，插入、删除效率高，但查找需要从头引用遍历链表，效率低。


## 2.5  练习题
### 2.5.1 合并两个有序链表

[https://leetcode-cn.com/problems/merge-two-sorted-lists/](https://leetcode-cn.com/problems/merge-two-sorted-lists/)

将两个有序链表合并为一个新的有序链表并返回。新链表是通过拼接给定的两个链表的所有节点组成的。
```
public class Solution {
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        var newList = new ListNode(0);
        //链表的节点
        var node = newList;
        while(l1 != null && l2 != null)
        {
            if(l1.val <l2.val)
            {
                node.next = l1;
                l1 = l1.next;
            }
            else
            {
                node.next = l2;
                l2 = l2.next;
            }    
            //更新节点
            node = node.next;
        }
        if(l1 != null)
            node.next = l1;
        
        if(l2 != null)
            node.next = l2;
        return newList.next;
    }
}
```

### 2.5.2 删除链表的倒数第N个节点

[https://leetcode-cn.com/problems/remove-nth-node-from-end-of-list/](https://leetcode-cn.com/problems/remove-nth-node-from-end-of-list/)

给定一个链表，删除链表的倒数第 *n* 个节点，并且返回链表的头结点。
```
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        int len = 1;
        var aNode = head;
        var bNode = head;

        while(aNode.next != null)
        {
            if(len > n)
            {
                bNode = bNode.next;
            }
            aNode = aNode.next;
            len++;
        }
        if(n ==len) return head.next;
        bNode.next = bNode.next.next;
        return head;
    }
```

### 2.5.3 旋转链表

[https://leetcode-cn.com/problems/rotate-list/](https://leetcode-cn.com/problems/rotate-list/)

给定一个链表，旋转链表，将链表每个节点向右移动*k*个位置，其中*k*是非负数。
```
   public ListNode RotateRight(ListNode head, int k) 
    {
        if (head == null || head.next == null) return head;
        ListNode aNode = head;
        int len = 0;
        while(k > 0 && aNode != null)
        {
            aNode = aNode.next;
            len++;
            k--;
        }
        if(aNode == null)
        {
            k = k % len; //余数
            aNode = head;
            while(k > 0)
            {
                aNode = aNode.next;
                k--;
            }
        }
        ListNode bNode = head;
        if(k == 0)
        {
            while(aNode.next != null)
            {
                aNode = aNode.next;
                bNode = bNode.next;
            }
        }
        aNode.next = head;
        head = bNode.next;
        bNode.next = null;
        return head;
    }
```
