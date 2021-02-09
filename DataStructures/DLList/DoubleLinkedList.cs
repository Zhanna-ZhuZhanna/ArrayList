using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DLList
{
   public class DoubleLinkedList:IList
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
                if (index < 0) 
                    throw new Exception("Index can't be less than zero!");
                if (index > Length) 
                    throw new Exception("Index is out of range!");
                return GetNode(index).Value;
            }
            set
            {
                if (index < 0) 
                    throw new Exception("Index can't be less than zero!");
                if (index > Length) 
                    throw new Exception("Index is out of range!");
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
            if (index < 0) 
                throw new Exception("Index is out of range!");
            if (index > Length) 
                throw new Exception("Index is out of range!");
            if (values.Length == 0)
                throw new Exception("The array of values is empty!");
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

        public int GetIndexByValue(int value)
        {
            for(int i=0;i<Length;i++)
            {
                if (this[i] == value) return i;
            }
            throw new Exception("There is not such a value in the list...");
        }

        public void Remove(int n)
        {
            if (n > Length)
                throw new Exception("The amount of elements you want to remove is bigger than length of the list!");
            if (n < 0)
                throw new Exception("The amount of elements to remove have to be grater than zero!");
            if (Length == n)
            {
                Length = 0;
                _head = null;
                _tail = null;
            }
            else
            {
                Node tmp = _tail;
                int i = 0;
                while (i < n)
                {
                    tmp = tmp.Previous;
                    i++;
                }
                tmp.Next = null;
                _tail = tmp;
                Length -= n;
            }

        }

        public void RemoveFromBeginning(int n)
        {
            if (n > Length) 
                throw new Exception("The amount of elements you want to remove is bigger than length of the list!");
            if (n < 0) 
                throw new Exception("The amount of elements to remove have to be grater than zero!");
            if (Length == n)
            {
                Length =0;
                _head = null;
                _tail = null;
            }
            else
            {
                Node tmp = _head;
                int i = 0;
               while(i<n)
                {
                    tmp = tmp.Next;
                    i++;
                }
                tmp.Previous = null;
                _head = tmp;
                Length -= n;
            }
        }

        public void RemoveFromIndex(int index, int n)
        {
            if (n < 0 || n + index > Length) 
                throw new Exception("The amount of elements can't be less than zero and grater than length of list!");
            if (index < 0 || index > Length - 1)
                throw new Exception("Index can't be less than zero and grater than length of list!");
            int i = 0;
            if (index != 0)
            {
                Node nodeBeforeRemoving = GetNode(index).Previous;
                if(n+index==Length)
                {
                    nodeBeforeRemoving.Next = null;
                    _tail = nodeBeforeRemoving;
                    Length -= n;
                }
                else
                {
                    Node tmp = nodeBeforeRemoving.Next;
                    while(i<n)
                    {
                        tmp = tmp.Next;
                        i++;
                    }
                    tmp.Previous = nodeBeforeRemoving;
                    nodeBeforeRemoving.Next = tmp;
                    Length -= n;
                }
            }
            else
            {
                RemoveFromBeginning(n);
            }
        }

        public int GetMaxElement()
        {
            if (Length == 0)
                throw new Exception("There is not any elements for searching max!");
            Node tmp = _head.Next;
            int max = _head.Value;
            while(tmp!=null)
            {
               
                if (tmp.Value > max)
                    max = tmp.Value;
                tmp = tmp.Next;
            }
            return max;
        }

        public int GetMinElement()
        {
            if (Length == 0)
                throw new Exception("There is not any elements for searching max!");
            Node tmp = _head.Next;
            int min = _head.Value;
            while (tmp != null)
            {

                if (tmp.Value < min)
                    min = tmp.Value;
                tmp = tmp.Next;
            }
            return min;
        }

        public int GetMaxElementIndex()
        {
            if (Length == 0)
                throw new Exception("There is not any elements for searching max!");
            Node tmp = _head.Next;
            int max = _head.Value;
            while (tmp != null)
            {

                if (tmp.Value > max)
                    max = tmp.Value;
                tmp = tmp.Next;
            }
            return GetIndexByValue(max);
        }

        public int GetMinElementIndex()
        {
            if (Length == 0)
                throw new Exception("There is not any elements for searching max!");
            Node tmp = _head.Next;
            int min = _head.Value;
            while (tmp != null)
            {

                if (tmp.Value < min)
                    min = tmp.Value;
                tmp = tmp.Next;
            }
            return GetIndexByValue(min);
        }

        public void RemoveAllElementsByValue(int value)
        {
            Node tmp = _head;
            bool check = false;
            while (tmp != null)
            {
                if (tmp.Value == value)
                {
                    if (tmp.Previous != null && tmp.Next != null)
                    {
                        tmp.Previous.Next = tmp.Next;
                        tmp.Next.Previous = tmp.Previous;
                    }
                    else if (tmp.Next == null && tmp.Previous == null)
                    {
                        _head = null;
                        _tail = null;
                    }
                    else if (tmp.Next == null)
                    {
                        tmp.Previous.Next = tmp.Next;
                        _tail = tmp.Previous;
                    }
                    else if (tmp.Previous == null)
                    {
                        tmp.Next.Previous = tmp.Previous;
                        _head = tmp.Next;
                    }
                    check = true;
                    Length--;
                    
                }
                tmp = tmp.Next;
            }
            if (!check)
                throw new Exception("There is not such a value in the list!");
        }

        public void RemoveFirstElementByValue(int value)
        {
            Node tmp = _head;
            bool check = false;
            while(tmp!=null)
            {
                if(tmp.Value==value)
                {
                    if (tmp.Previous != null && tmp.Next != null)
                    {
                        tmp.Previous.Next = tmp.Next;
                        tmp.Next.Previous = tmp.Previous;
                    }
                    else if(tmp.Next==null && tmp.Previous==null)
                    {
                        _head = null;
                        _tail = null;
                    }
                   else if(tmp.Next==null)
                    {
                        tmp.Previous.Next = tmp.Next;
                        _tail = tmp.Previous;
                    }
                   else if(tmp.Previous==null)
                    {
                        tmp.Next.Previous = tmp.Previous;
                        _head = tmp.Next;
                    }
                    check = true;
                    Length--;
                    break;
                }
                tmp = tmp.Next;
            }
            if (!check)
                throw new Exception("There is not such a value in the list!");
        }


        public void SortAscending()
        {
            Node tmp = _head;
            Node newHead = _head;
            if (Length > 0)
            {
                while (tmp.Next != null)
                {
                    if (tmp.Value > tmp.Next.Value)
                    {
                       tmp= SwapNodes(tmp, tmp.Next);
                        if (tmp.Previous == null)
                        {
                            newHead = tmp;
                        }
                        tmp = newHead;
                    }
                    else
                    {
                        tmp = tmp.Next;
                    }

                }
                _head = newHead;
                _tail = tmp;
            }
        }
        public void SortDescending()
        {
            Node tmp = _head;
            Node newHead = _head;
            if (Length > 0)
            {
                while (tmp.Next != null)
                {
                    if (tmp.Value < tmp.Next.Value)
                    {
                        tmp = SwapNodes(tmp, tmp.Next);
                        if (tmp.Previous == null)
                        {
                            newHead = tmp;
                        }
                        tmp = newHead;
                    }
                    else
                    {
                        tmp = tmp.Next;
                    }

                }
                _head = newHead;
                _tail = tmp;
            }
        }
        private Node SwapNodes(Node firstNode, Node secondNode)
        {
            if (firstNode.Previous != null&& secondNode.Next!=null)
            {
                firstNode.Previous.Next = secondNode;

                secondNode.Previous = firstNode.Previous;
                firstNode.Previous = secondNode;

                secondNode.Next.Previous = firstNode;
                firstNode.Next = secondNode.Next;
                secondNode.Next = firstNode;
            }
            else if(secondNode.Next != null)
            {
                firstNode.Previous = secondNode;
                firstNode.Next = secondNode.Next;
                secondNode.Next.Previous = firstNode;
                secondNode.Previous = null;
                secondNode.Next = firstNode;
            }
            else if(firstNode.Previous!=null)
            {
                secondNode.Previous = firstNode.Previous;
                secondNode.Previous.Next = secondNode;
                secondNode.Next = firstNode;
                firstNode.Previous = secondNode;
                firstNode.Next = null;
            }
            else
            {
                secondNode.Next = firstNode;
                firstNode.Previous = secondNode;
                secondNode.Previous = null;
                firstNode.Next = null;
            }
           return secondNode;
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
