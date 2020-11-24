using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LList
{
   public class LinkedList : IList
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

        public int GetIndexByValue(int value)
        {
            Node cur = _root;
            int i = 0;
            bool check = false;
            while(i<Length)
            {
                if (cur.Value == value)
                {
                    check = true;
                    break;
                }
                cur = cur.Next;
                i++;
            }
            if (!check) throw new Exception("List doesn't contain such a value.");
            else return i;
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

        public void Remove(int n=1)
        {
            if (n < 0 || n > Length) throw new Exception("The amount of elements can't be less than zero and grater than length of list!");
            int i = 0;
            if (n != 0)
            {
                Node cur = _root;
                while (i > Length - n)
                {
                    cur = cur.Next;
                    i++;
                }
                cur.Next = null;
                Length = Length - n;
            }
            
        }
        public void RemoveFromBeginning(int n=1)
        {
            if(n<0||n>Length) throw new Exception("The amount of elements can't be less than zero and grater than length of list!");
            int i = 0;
            Node cur = _root;
            while(i<n)
            {
                cur = cur.Next;
                i++;
            }
            _root = cur;
            Length -= n;
        }
        public void RemoveFromIndex(int index, int n)
        {
            if(n<0||n+index>Length) throw new Exception("The amount of elements can't be less than zero and grater than length of list!");
            if (index < 0 || index > Length - 1) throw new Exception("Index can't be less than zero and grater than length of list!");
            int i = 0;
            if(index!=0)
            {
                Node curRoot = _root;
                Node cur = curRoot; ;
                while (i<index-1)
                {
                    cur = cur.Next;
                    i++;
                }
                Node pnt = cur;
                Length -= n;
                while(n>0)
                {
                    pnt = pnt.Next;
                    n--;
                }
                cur.Next = pnt.Next;
                _root = curRoot;
            }
            else
            {
                Length -= n;
                while (0<n)
                {
                    _root = _root.Next;
                    n--;
                }
                
            }
        }
        public int GetMaxElement()
        {
            if (_root != null)
            {
                int max = _root.Value;
                Node cur = _root.Next;
                while(cur!=null)
                {
                    if (max < cur.Value) max = cur.Value;
                    cur = cur.Next;
                }
                return max;
            }
            else throw new Exception("The list is empty!");
        }
        public int GetMinElement()
        {
            if (_root != null)
            {
                int min = _root.Value;
                Node cur = _root.Next;
                while (cur != null)
                {
                    if (min> cur.Value) min = cur.Value;
                    cur = cur.Next;
                }
                return min;
            }
            else throw new Exception("The list is empty!");
        }
        public int GetMaxElementIndex()
        {
            if (_root != null)
            {
                int index = 0;
                int i = 1;
                int max = _root.Value;
                Node cur = _root.Next;
                while (cur != null)
                {
                    if (max < cur.Value)
                    { 
                        max = cur.Value;
                        index = i;
                    }
                    cur = cur.Next;
                    i++;
                }
                return index;
            }
            else throw new Exception("The list is empty!");
        }
        public int GetMinElementIndex()
        {
            if (_root != null)
            {
                int index = 0;
                int i = 1;
                int min = _root.Value;
                Node cur = _root.Next;
                while (cur != null)
                {
                    if (min > cur.Value)
                    {
                        min = cur.Value;
                        index = i;
                    }
                    cur = cur.Next;
                    i++;
                }
                return index;
            }
            else throw new Exception("The list is empty!");
        }
        public void RemoveFirstElementByValue(int value)
        {
            if (_root != null)
            {
                bool check = false;
                int i = 0;
                Node curRoot = _root;
                Node cur = curRoot;
                Node prev = cur;
                while (i < Length)
                {
                    if (cur.Value == value)
                    {
                        if (i == 0)
                        {
                            if (cur.Next != null) curRoot = cur.Next;
                            else curRoot = null;
                            check = true;
                            Length--;
                            break;
                        }
                        else if (i == Length - 1)
                        {
                            prev.Next = null;
                            Length--;
                            check = true;
                            break;
                        }
                        else
                        {
                            prev.Next = cur.Next;
                            Length--;
                            check = true;
                            break;
                        } 
                    }
                    if (i > 0)
                    {
                        prev = cur;
                    }
                    cur = cur.Next;
                    i++;
                }
                if (!check)
                {
                    throw new Exception("The list doesn't contain such a value!");
                }
                else _root = curRoot;
            }
            else throw new Exception("The list is empty!");
        }
        public void RemoveAllElementsByValue(int value)
        {
            if (_root != null)
            {
                bool check = false;
                bool change = false;
                int i = 0;
                Node curRoot = _root;
                Node cur = curRoot;
                Node prev = cur;
                while (i < Length)
                {
                    if (cur.Value == value)
                    {
                        if (i == 0)
                        {
                            if (cur.Next != null)
                            { 
                                curRoot = cur.Next;
                                prev = curRoot;
                                //i = -1;
                            }
                            else curRoot = null;
                            check = true;
                            change = true;
                            i--;
                            Length--;
                        }
                        else if (i == Length - 1)
                        {
                            prev.Next = null;
                            Length--;
                            check = true;
                        }
                        else
                        {
                            prev.Next = cur.Next;
                            change = true;
                            Length--;
                            i--;
                            check = true;
                        }
                    }
                    if (i > 0)
                    {
                        if (!change)
                        {
                            prev = cur;
                        }
                       else change = false;
                    }
                    cur = cur.Next;
                    i++;
                    change = false;
                }
                if (!check)
                {
                    throw new Exception("The list doesn't contain such a value!");
                }
                else _root = curRoot;
            }
            else throw new Exception("The list is empty!");
        }
        public void ReverseTheList()
        {
            if (Length != 0)
            {
                Node oldRoot = _root;
                Node tmp;
                while (oldRoot.Next != null)
                {
                    tmp = oldRoot.Next;
                    oldRoot.Next = tmp.Next;
                    tmp.Next = _root;
                    _root = tmp;
                }
            }
        }
        public void SortAscending()
        {
            int i = 0;
            Node tmp;
            Node curRoot = _root;
            Node cur=curRoot;
            Node curPrev=cur; 
            while(i<Length-1)
            {
                if(cur.Next.Value<cur.Value)
                {
                    tmp = cur.Next;
                    cur.Next = tmp.Next;
                    tmp.Next = cur;
                    if(i==0)
                    {
                        curRoot = tmp;
                    }
                    else
                    {
                        curPrev.Next = tmp;
                    }
                    cur = curRoot;
                    i = 0;
                }
                else
                {
                    i++;
                    if(cur.Next!=null)
                    {
                        curPrev = cur;
                        cur = cur.Next;
                    }
                }
            }
            _root = curRoot;
        }
        public void SortDescending()
        {
            int i = 0;
            Node tmp;
            Node curRoot = _root;
            Node cur = curRoot;
            Node curPrev = cur;
            while (i < Length - 1)
            {
                if (cur.Next.Value > cur.Value)
                {
                    tmp = cur.Next;
                    cur.Next = tmp.Next;
                    tmp.Next = cur;
                    if (i == 0)
                    {
                        curRoot = tmp;
                    }
                    else
                    {
                        curPrev.Next = tmp;
                    }
                    cur = curRoot;
                    i = 0;
                }
                else
                {
                    i++;
                    if (cur.Next != null)
                    {
                        curPrev = cur;
                        cur = cur.Next;
                    }
                }
            }
            _root = curRoot;
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
