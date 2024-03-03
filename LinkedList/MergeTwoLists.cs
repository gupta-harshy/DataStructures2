using DataStructures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.LinkedList
{
    internal class MergeTwoLists
    {
        //public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        //{
        //    if(list1 == null) return list2;
        //    if(list2 == null) return list1;

        //    ListNode head, current;
        //    if(list1.val <= list2.val)
        //    {
        //        head = list1;
        //        current = list1;
        //        list1 = list1.next;
        //    }
        //    else
        //    {
        //        head = list2;
        //        current = list2;
        //        list2 = list2.next;
        //    }
        //    while(list1 != null && list2 != null)
        //    {
        //        if (list1.val <= list2.val)
        //        {
        //            current.next = list1;
        //            list1 = list1.next;
        //        }
        //        else
        //        {
        //            current.next = list2;
        //            list2 = list2.next;
        //        }
        //        current = current.next;
        //    }

        //    current.next = list1 ?? list2;

        //    return head;
        //}
    }
}
