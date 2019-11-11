using Practice.Tree.Libs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Tree.src.My_Code
{
    class CreateBinaryTreeWithStackAndSet
    {
        static HashSet<Node<int>> set = new HashSet<Node<int>>();
        static Stack<Node<int>> stack = new Stack<Node<int>>();

        public Node<int> buildTree(int[] preorder, int[] inorder)
        {

            Node<int> root = null;
            int inOrderIndex  = 0;
            for (int pre = 0; pre < preorder.Length;) {

                Node<int> node = null;
                do
                {
                    node = new Node<int>(preorder[pre]);
                    if (root == null)
                    {
                        root = node;
                    }
                    if (stack.Count > 0)
                    {
                        if (set.Contains(stack.Peek()))
                        {
                            set.Remove(stack.Peek());
                            stack.Pop().right = node;
                        }
                        else
                        {
                            stack.Peek().left = node;
                        }
                    }
                    stack.Push(node);
                } while (preorder[pre++] != inorder[inOrderIndex] && pre < preorder.Length);

                node = null;
                while (stack.Count > 0 && inOrderIndex < inorder.Length &&
                        stack.Peek().data == inorder[inOrderIndex]) {
                    node = stack.Pop();
                    inOrderIndex++;
                }

                if (node != null)
                {
                    set.Add(node);
                    stack.Push(node);
                }
            }

            return root;
        }

        // Function to print tree in Inorder
        void PrintInorder(Node<int> node)
        {
            if (node == null)
                return;

            /* first recur on left child */
            PrintInorder(node.left);

            /* then print the data of node */
            Console.Write(node.data + " ");

            /* now recur on right child */
            PrintInorder(node.right);
        }


    }
}
