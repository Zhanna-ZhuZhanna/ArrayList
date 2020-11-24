using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DLList
{
   public class DoubleLinkedList
    {
        public int Length { get; private set; }
        private Node _head { get; set; }
        private Node _tail { get; set; }

        public DoubleLinkedList()
        {
            _head = null;
            _tail = null;
            Length = 0;
        }
        public DoubleLinkedList(int value)
        {
            _head = new Node(value);
            _head.Previous = null;
            _head.Next = null;
            _tail = _head;
            Length = 1;
        }

        public DoubleLinkedList(int[] values)
        {
            if(values.Length==0)
            {
                _head = null;
                _tail = null;
                Length = 0;
            }
            else
            {
                _head = new Node(values[0]);
                _head.Previous = null;
                Node tmp = _head;
                for (int i=1; i<values.Length;i++)
                {
                    tmp.Next = new Node(values[i]);
                    tmp.Next.Previous = tmp;
                    tmp = tmp.Next;
                }
                tmp.Next = null;
                _tail = tmp;
                Length = values.Length;
            }
        }



        public override bool Equals(object obj)
        {
            DoubleLinkedList objList = (DoubleLinkedList)obj;
            if(objList.Length!=Length)
            {
                return false;
            }
           else
            {
                Node tmp = _head;
                Node objTmp = objList._head;
                while(tmp.Next!=null)
                {
                    if (tmp.Value != objTmp.Value) return false;
                    tmp = tmp.Next;
                    objTmp = objTmp.Next;
                }
                while(tmp.Previous!=null)
                {
                    if (tmp.Value != objTmp.Value) return false;
                    tmp = tmp.Previous;
                    objTmp = objTmp.Previous;
                }
            }
            return true;
        }
        public override string ToString()
        {
            Node tmp = _head;
            string s = "";
            while(tmp!=null)
            {
                s += tmp.Value + "; ";
                tmp = tmp.Next;
            }
            return s;
        }
    }
}
