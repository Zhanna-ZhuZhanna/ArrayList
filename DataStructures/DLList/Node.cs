﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.DLList
{
    class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node()
        {
            Next = null;
            Previous = null;
        }

        public Node(int value)
        {
            Next = null;
            Previous = null;
            Value = value;
        }
    }
}
