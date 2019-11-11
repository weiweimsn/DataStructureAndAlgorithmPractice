using Practice.Tree.Libs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Tree.src.Examples
{
    class IsSubTree_Class
    {
        public bool IsSubtree(Node<int> s, Node<int> t)
        {
            if (s == null || t == null)
            {
                return false;
            }

            Node<int> root = this.FindTargetNode(s, t);
            bool result = this.Check(root, t);
            Console.WriteLine(result);
            return result;
        }

        private Node<int> FindTargetNode(Node<int> s, Node<int> t)
        {
            if (s == null)
            {
                return null;
            }
            if (s.data == t.data)
            {
                return s;
            }

            if(FindTargetNode(s.left, t) != null)
            {
                return s.left;
            }  
            if (FindTargetNode(s.right, t) != null)
            {
                return s.right;
            }
            return null;
        }

        private bool Check(Node<int> s, Node<int> t)
        {
            if (s == null && t == null)
            {
                return true;
            }
            if(s == null || t == null)
            {
                return false;
            }
            if (s.data != t.data)
            {
                return false;
            }

            // if current node value equals t.value
            return Check(s.left, t.left) && Check(s.right, t.right);
        }
    }
}

