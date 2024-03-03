using DataStructures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    internal class AddTwoNumbers
    {
        public ListNode AddTwoNumbersFunc(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode();
            ListNode temp = head;
            int carry = 0;
            int sum = 0;
            while (l1 != null && l2 != null)
            {
                sum = l1.val + l2.val + carry;
                temp.next = new ListNode(sum % 10);
                temp = temp.next;
                carry = sum / 10;
                l1 = l1.next;
                l2 = l2.next;
            }
            while (l1 != null)
            {
                sum = l1.val + carry;
                temp.next = new ListNode(sum % 10);
                temp = temp.next;
                carry = sum / 10;
                l1 = l1.next;
            }
            while (l2 != null)
            {
                sum = l2.val + carry;
                temp.next = new ListNode(sum % 10);
                temp = temp.next;
                carry = sum / 10;
                l2 = l2.next;
            }
            if (carry == 1)
            {
                temp.next = new ListNode(carry);
                temp = temp.next;
            }
            return head.next;
        }
    }
}
