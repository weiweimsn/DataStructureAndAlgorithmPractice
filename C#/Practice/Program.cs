using Practice.Tree.Libs;
using Practice.Tree.src.Examples;
using Practice.Tree.src.My_Code;
using System;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> tree1_root = new Node<int>(3);
            tree1_root.right = new Node<int>(5);
            tree1_root.left = new Node<int>(4);
            tree1_root.left.left = new Node<int>(1);
            tree1_root.left.right = new Node<int>(2);
            tree1_root.left.right.left = new Node<int>(0);

            Node<int> tree2_root = new Node<int>(4);
            tree2_root.left = new Node<int>(1);
            tree2_root.right = new Node<int>(2);

            IsSubTree_Class isSubtree_class = new IsSubTree_Class();
            bool isSubTree = isSubtree_class.IsSubtree(tree1_root, tree2_root);

            //CreateBinaryTreeWithStackAndSet tree = new CreateBinaryTreeWithStackAndSet();
            //int[] inorderSequence = new int[] { 9, 8, 4, 2, 10, 5, 11, 1, 6, 3, 13, 12, 7 };
            //int[] pre = new int[] { 1, 2, 4, 8, 9, 5, 10, 11, 3, 6, 7, 12, 13 };
            //int len = inorderSequence.Length; 

            //Node<int> root = tree.buildTree(pre, inorderSequence);

            //tree.printInorder(root); 
        }
    }
}
