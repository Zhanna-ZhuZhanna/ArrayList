using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DLList
{
   public class DoubleLinkedList
    {
       
        private Node _head { get; set; }
        private Node _tail { get; set; }
        public int Length { get; private set; }
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

        public int this[int index]
        {
            get
            {
                if (index < 0) throw new Exception("Index can't be less than zero!");
                if (index > Length) throw new Exception("Index is out of range!");

                return GetNode(index).Value;
            }
            set
            {
                if (index < 0) throw new Exception("Index can't be less than zero!");
                if (index > Length) throw new Exception("Index is out of range!");
                GetNode(index).Value = value;
            }
        }

        public void Add(int[] values)
        {
            Node tmp = _tail;
            if (tmp != null)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    Node cur = new Node(values[i]);
                    tmp.Next = cur;
                    cur.Previous = tmp;
                    tmp = tmp.Next;
                    Length++;
                }
                _tail = tmp;
            }
            else if (values.Length > 0)
            {
                _head = new Node(values[0]);
                _head.Previous = null;
                tmp = _head;
                Length++;
                for (int i = 1; i < values.Length; i++)
                {
                    Node cur = new Node(values[i]);
                    tmp.Next = cur;
                    cur.Previous = tmp;
                    tmp = tmp.Next;
                    Length++;
                }
                _tail = tmp;
                _tail.Next = null;
            }

        }

        public void AddToTheBeginning(int[] values)
        {
            
            if (values.Length != 0)
            {
                Node curRoot = new Node(values[0]);
                Length += values.Length;
                Node cur = curRoot;
                cur.Previous = null;
                for (int i = 1; i < values.Length; i++)
                {
                    cur.Next = new Node(values[i]);
                    cur.Next.Previous = cur;
                    cur = cur.Next;
                }
                if(_head!=null)
                {
                    _head.Previous = cur;
                    cur.Next = _head;
                }
                else
                {
                    _tail = cur;
                }
                _head = curRoot;
            }
        }

        public void AddToTheIndex(int[] values, int index)
        {
            if (index < 0) throw new Exception("Index is out of range!");
            if (index > Length) throw new Exception("Index is out of range!");
            if (values.Length == 0) throw new Exception("The array of values is empty!");
            if (index >0 && index<Length)
            {
                Node curRoot = _head;
                Node cur = GetNode(index - 1);

                Node curNextNode = cur.Next;
                Node tmp = new Node(values[0]);
                cur.Next = tmp;
                tmp.Previous = cur;
                for (int i = 1; i < values.Length; i++)
                {
                    tmp.Next = new Node(values[i]);
                    tmp.Next.Previous = tmp;
                    tmp = tmp.Next;
                }
                tmp.Next = curNextNode;
                Length += values.Length;
                _head = curRoot;
            }
            else if(index==Length)
            {
                Add(values);
            }
            else
            {
                AddToTheBeginning(values);
            }
        }





        public void ReverseTheList()
        {
            if (Length != 0)
            {
                Node oldHead = _head;
                Node tmp = oldHead.Next;
                oldHead.Next = null;
                oldHead.Previous = tmp;
                Node cur = oldHead;
                while (tmp.Next != null)
                {
                    tmp.Previous = tmp.Next;
                    tmp.Next = cur;
                    cur = tmp;
                    tmp = tmp.Previous;
                }
                tmp.Next = tmp.Previous;
                tmp.Previous = null;
                _head = tmp;
                _tail = oldHead;
            }
        }
        public override bool Equals(object obj)
        {
            DoubleLinkedList objList = (DoubleLinkedList)obj;
            if(objList.Length!=Length)
            {
                return false;
            }
            else if(Length==0)
            {
                return true;
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

        private Node GetNode(int index)
        {
            Node tmp;
            if(Length/2 >index)
            {
                int i = 0;
                tmp = _head;
                while(i<index)
                {
                    tmp = tmp.Next;
                    i++;
                }
            }
            else
            {
                int i = Length-1;   
                tmp = _tail;
                while(i>index)
                {
                    tmp = tmp.Previous;
                    i--;
                }
            }
            return tmp;
        }
    }
}
