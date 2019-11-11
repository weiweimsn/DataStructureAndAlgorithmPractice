using Practice.Tree.Libs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Tree.src.My_Code
{
    class CreateTreeFromInOrderSequenceAndPostOrderSequence
    {
        public Node<char> BuildTree(char[] inorderSequence, char[] postorderSequence, int startIndex, int endIndex, int rootIndex_postSequence) 
        {
            if (rootIndex_postSequence == int.MinValue) rootIndex_postSequence = postorderSequence.Length - 1;
            if (rootIndex_postSequence < 0) return null;

            // find the las element from post order sequence, which is the root
            Node<char> tempNode = new Node<char>(postorderSequence[rootIndex_postSequence]);

            // find the root node index in the inorder sequence
            int rootIndexInInOrderSequence = Array.IndexOf(inorderSequence, tempNode.data);

            if (startIndex == endIndex) return tempNode;

            int rightMostSubTreeRootIndex_leftSubTree = this.findRightMostIndex(new ArraySegment<char>(inorderSequence, startIndex, rootIndexInInOrderSequence - startIndex).ToArray(), postorderSequence);
            int rightMostSubTreeRootIndex_rightSubTree = this.findRightMostIndex(new ArraySegment<char>(inorderSequence, rootIndexInInOrderSequence + 1, endIndex - rootIndexInInOrderSequence).ToArray(), postorderSequence);

            tempNode.left = BuildTree(inorderSequence, postorderSequence, startIndex, rootIndexInInOrderSequence - 1, rightMostSubTreeRootIndex_leftSubTree);
            tempNode.right = BuildTree(inorderSequence, postorderSequence, rootIndexInInOrderSequence + 1, endIndex, rightMostSubTreeRootIndex_rightSubTree);

            return tempNode;
            
        }

        private int findRightMostIndex(char[] targets, char[] array)
        {
            List<int> indexes = new List<int>();
            foreach(char target in targets)
            {
                int index = Array.IndexOf(array, target);
                indexes.Add(index);
            }

            indexes.Sort();
            // return the biggest index number
            if(indexes.Count == 0)
            {
                return -1;
            }
            return indexes[indexes.Count - 1];
        }

        public void PostOrderTravel(Node<char> root)
        {
            if (root == null) return;
            PostOrderTravel(root.left);
            PostOrderTravel(root.right);
            Console.WriteLine(root.data);
        }
    }


}

//static void Main(string[] args)
//{
//    CreateTreeFromInOrderSequenceAndPostOrderSequence tree = new CreateTreeFromInOrderSequenceAndPostOrderSequence();
//    char[] inorderArr = new char[] { '4', '8', '2', '5', '1', '6', '3', '7' }; // in-order sequence
//    char[] postorderArr = new char[] { '8', '4', '5', '2', '6', '7', '3', '1' }; // pre-order sequence
//    int len = postorderArr.Length;
//    Node<char> root = tree.BuildTree(inorderArr, postorderArr, 0, len - 1, len - 1);

//    // building the tree by printing inorder traversal 
//    Console.WriteLine("Inorder traversal of " + "constructed tree is : ");
//    tree.PostOrderTravel(root);
//}
