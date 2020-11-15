using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LList
{
   public class LinkedList
    {
        public int Length { get; private set; }
        private Node _root { get; set; }

        public LinkedList()
        {
            _root =null;
            Length = 0;
        }
        public LinkedList(int value)
        {
            _root = new Node(value);
            Length = 1;
        }
         public LinkedList(int[] values)
        {
            if (values.Length == 0)
            {
                _root = null;
                Length = 0;
            }
            else
            {
                Length = values.Length;
                _root = new Node(values[0]);
                Node tmp = _root;
                for (int i = 1; i < values.Length; i++)
                {
                    tmp.Next = new Node(values[i]);
                    tmp = tmp.Next;
                }
            }
        }
        public int this[int index]
        {
            get
            {
                if (index < 0) throw new Exception("Index can't be less than zero!");
                if (index > Length) throw new Exception("Index is out of range!");
                Node cur = _root;
                for(int i=0;i<index;i++)
                {
                    cur = cur.Next;
                }
                return cur.Value;
            }
            set
            {
                if (index < 0) throw new Exception("Index can't be less than zero!");
                if (index > Length) throw new Exception("Index is out of range!");
                Node cur = _root;
                for(int i=0;i<=index;i++)
                {
                    cur = cur.Next;
                }
                cur.Value = value;
            }
        }

        public void Add(int[] values)
        {
            Node tmp = _root;
            if (tmp != null)
            {
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }
                for (int i = 0; i < values.Length; i++)
                {
                    Node cur = new Node(values[i]);
                    tmp.Next = cur;
                    tmp = tmp.Next;
                    Length++;
                }
            }
            else if(values.Length>0)
            {
                _root = new Node(values[0]);
                tmp = _root;
                Length++;
                for (int i = 1; i < values.Length; i++)
                {
                    Node cur = new Node(values[i]);
                    tmp.Next = cur;
                    tmp = tmp.Next;
                    Length++;
                }

            }
          
        }

        public void AddToTheBeginning(int[] values)
        {
            if (values.Length != 0)
            {
                Node curRoot = new Node(values[0]);
                Length+=values.Length;
                Node cur = curRoot;
                for(int i=1;i<values.Length;i++)
                {
                    cur.Next = new Node(values[i]);
                    cur = cur.Next;
                }
                cur.Next = _root;
                _root = curRoot;
            }
        }

        public void AddToTheIndex(int[] values, int index)
        {
            if (index < 0) throw new Exception("Index is out of range!");
            if (index > Length) throw new Exception("Index is out of range!");
            if (values.Length == 0) throw new Exception("The array of values is empty!");
            if (index != 0)
            {
                Node curRoot = _root;
                Node cur = curRoot;
                for (int i = 0; i < index - 1; i++)
                {
                    cur = cur.Next;
                }
                Node curNextNode = cur.Next;
                Node tmp = new Node(values[0]);
                cur.Next = tmp;
                for (int i = 1; i < values.Length; i++)
                {
                    tmp.Next = new Node(values[i]);
                    tmp = tmp.Next;
                }
                tmp.Next = curNextNode;
                Length += values.Length;
                _root = curRoot;
            }
            else
            {
                Node tmp = new Node(values[0]);
                Node curRoot = tmp;
                for (int i = 1; i < values.Length; i++)
                {
                    tmp.Next = new Node(values[i]);
                    tmp = tmp.Next;
                }
                tmp.Next = _root;
                Length += values.Length;
                _root = curRoot;
            }
        }
        public override string ToString()
        {
            string s = "";
            Node tmp = _root;
            for(int i=0; i<Length;i++)
            {
                s += tmp.Value + "; ";
                tmp = tmp.Next;
            }
            return s;
        }
        public override bool Equals(object obj)
        {
            LinkedList objList = (LinkedList)obj;
            if(objList.Length!=Length)
            {
                return false;
            }
            else
            {
                Node objTmp = objList._root;
                Node tmp = _root;
                for (int i=0;i<Length;i++)
                {
                    if (tmp.Value != objTmp.Value) return false;

                    objTmp = objTmp.Next;
                    tmp = tmp.Next;
                }
            }
            return true;
            
        }
    }
}
