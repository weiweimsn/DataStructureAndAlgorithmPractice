using Practice.Tree.Libs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Tree.src
{
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
    class GFG
    {
        public Node<char> root;
        public static int preIndex = 0;
        /* Recursive function to construct binary  
        of size len from Inorder traversal in[]  
        and Preorder traversal pre[]. Initial values  
        of inStrt and inEnd should be 0 and len -1.  
        The function doesn't do any error checking for  
        cases where inorder and preorder do not form a tree */
        public virtual Node<char> buildTree(char[] inorderArr, char[] preorderArr, int inStrt, int inEnd)
        {
            if (inStrt > inEnd)
            {
                return null;
            }

            /* Pick current node from Preorder traversal 
            using preIndex and increment preIndex */

            Node<char> tNode = new Node<char>(preorderArr[preIndex++]);

            /* If this node has no children then return */
            if (inStrt == inEnd)
            {
                return tNode;
            }

            /* Else find the index of this 
            node in Inorder traversal */
            int inIndex = search(inorderArr, inStrt,
                                 inEnd, tNode.data);

            /* Using index in Inorder traversal,  
            construct left and right subtress */
            tNode.left = buildTree(inorderArr, preorderArr, inStrt, inIndex - 1);
            tNode.right = buildTree(inorderArr, preorderArr, inIndex + 1, inEnd);

            return tNode;
        }

        /* UTILITY FUNCTIONS */

        /* Function to find index of value in arr[start...end]  
        The function assumes that value is present in in[] */
        public virtual int search(char[] arr, int strt,
                                  int end, char value)
        {
            int i;
            for (i = strt; i <= end; i++)
            {
                if (arr[i] == value)
                {
                    return i;
                }
            }
            return i;
        }

        /* This funtcion is here just to test buildTree() */
        public virtual void printInorder(Node<char> node)
        {
            if (node == null)
            {
                return;
            }

            /* first recur on left child */
            printInorder(node.left);

            /* then print the data of node */
            Console.Write(node.data + " ");

            /* now recur on right child */
            printInorder(node.right);
        }
    }
}
