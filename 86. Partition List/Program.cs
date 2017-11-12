using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _86.Partition_List
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class Solution
    {
        private List<int> vals = new List<int>();
        void GetAllVals(ListNode n)
        {
            if (null != n)
            {
                vals.Add(n.val);
                GetAllVals(n.next);
            }
        }
        public ListNode Partition(ListNode head, int x)
        {
            if (null == head)
            {
                return null;
            }
            GetAllVals(head);
            var result = vals.Where(v => v < x).Concat(vals.Where(v => v >= x).ToList()).ToList();
            ListNode preNode = new ListNode(0) { next = null };
            return result.Select(r =>
            {
                var tmp = new ListNode(r) { next = null };
                preNode.next = tmp;
                preNode = tmp;
                return tmp;
            }).ToList().First();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            (new Solution()).Partition(new ListNode(1){ next= new ListNode(2) },0);
        }
    }
}
