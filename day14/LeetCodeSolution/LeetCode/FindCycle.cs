using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }


    public class FindCycle
    {
        public async Task<bool> FindCycles(ListNode head)
        {
            if(head == null)
            {
                return false;
            }
            ListNode slow = head;
            ListNode fast = head;
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if(slow == fast)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
