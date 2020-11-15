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
            Length = values.Length;
            _root = new Node(values[0]);
            Node tmp = _root;
            for(int i=1;i<values.Length;i++)
            {
                
                tmp.Next = new Node(values[i]);
                tmp = tmp.Next;
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
            if(objList.Length!=this.Length)
            {
                return false;
            }
            else
            {
                Node objTmp = objList._root;
                Node tmp = this._root;
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
