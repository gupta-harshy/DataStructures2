using DataStructures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    internal class LinkedListCycle
    {
        public bool HasCycle(ListNode head)
        {
            if (head == null) return false;
            ListNode slowptr, fastptr;
            slowptr = fastptr = head;
            while (fastptr != null && fastptr.next != null)
            {
                fastptr = fastptr.next.next;
                slowptr = slowptr.next;
                if(slowptr == fastptr) return true;
            }
            return false;
        }
    }
}
