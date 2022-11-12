using System.Collections.Generic;

namespace DataStructures
{
    public class Recursion
    {
        public ListNode ReverseList(ListNode head) {
            if(head == null || head.next == null)
                return head;
                       
            var dummyHead = new ListNode(-1);
            dummyHead.next = head;
            
            Rev(dummyHead, head);
            
            return dummyHead.next; 
        }
        
        public ListNode Rev(ListNode prev, ListNode node)
        {
            if(node.next == null)
                return node;
            
            var node1 = Rev(node, node.next);
            prev.next = node.next;
            node1.next = node;
            node.next = null;
            
            return node;
        }

        public IList<int> GetRow(int rowIndex) {
            if(rowIndex == 0)
                return new List<int>{ 1 };
            var list = new List<int>();
            var table = new Dictionary<string,int>();
            
            list.Add(1);
            for(int i = 1; i< rowIndex; i++)
            {
                list.Add(GetElement(rowIndex, i, table));
            }
            
            list.Add(1);
            
            return list;
        }
        
        public int GetElement(int i, int j, Dictionary<string,int> table)
        {
            var key = i+","+j;
            
            if(table.ContainsKey(key))
                return table[key];
            if(i < 0 || j < 0)
                return 0;
            
            if(i == j || j == 0)
                return 1;
            
            var result = GetElement(i-1, j-1, table)+GetElement(i-1, j, table);
            table.Add(key, result);
            return result;
        }
    }

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }
}