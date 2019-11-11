using Practice.Tree.Libs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Tree.src.My_Code
{
    class GFG
    {
        int preOrderIndex = 0;

        /// <summary>
        /// Assumption: no duplicate data in the tree
        /// </summary>
        /// <param name="preOrderSequences"></param>
        /// <param name="inorderSequences"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        /// 
         /*
         * Construct Tree from given Inorder and Preorder traversals
         * Let us consider the below traversals:
         * Inorder sequence: D B E A F C
         * Preorder sequence: A B D E C F
         * Output:
                     A
                   /   \
                 /       \
                B         C
               / \        /
             /     \    /
            D       E  F


          * https://www.geeksforgeeks.org/construct-tree-from-given-inorder-and-preorder-traversal/
         */
        public Node<char> buildTree(char[] inorderSequences, char[] preOrderSequences, int startIndex, int endIndex)
        {
            if(startIndex > endIndex)
            {
                return null;
            }

            Node<char> tempNode = new Node<char>(preOrderSequences[preOrderIndex++]);

            if(startIndex == endIndex)
            {
                return tempNode;
            }

            int inOrderSequenceIndex = Array.IndexOf(inorderSequences, tempNode.data);

            tempNode.left = buildTree(inorderSequences, preOrderSequences, startIndex, inOrderSequenceIndex - 1);
            tempNode.right = buildTree(inorderSequences, preOrderSequences, inOrderSequenceIndex + 1, endIndex);
            return tempNode;
        }

        public void PreOrderTravesal(Node<char> root)
        {
            if (root == null) return;
            Console.Write(root.data + "  ");
            PreOrderTravesal(root.left);
            PreOrderTravesal(root.right);
        }

        public void InOrderTravesal(Node<char> root)
        {
            if (root == null) return;
            InOrderTravesal(root.left);
            Console.WriteLine(root.data);
            InOrderTravesal(root.right);
        }

        //static void Main(string[] args)
        //{
        //    GFG tree = new GFG();
        //    char[] inorderArr = new char[] { 'D', 'B', 'E', 'A', 'F', 'C' }; // in-order sequence
        //    char[] preorderArr = new char[] { 'A', 'B', 'D', 'E', 'C', 'F' }; // pre-order sequence
        //    int len = inorderArr.Length;
        //    Node root = tree.buildTree(inorderArr, preorderArr, 0, len - 1);

        //    // building the tree by printing inorder traversal 
        //    Console.WriteLine("Inorder traversal of " + "constructed tree is : ");
        //    tree.InOrderTravesal(root);
        //}
    }
}
