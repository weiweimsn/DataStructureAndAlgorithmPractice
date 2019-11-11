using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Tree.Libs
{
    class Node<T>
    {
        public T data;
        public Node<T> left;
        public Node<T> right;
        public Node(T x) { data = x; }
    }
}
