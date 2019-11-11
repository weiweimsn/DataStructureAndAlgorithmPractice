package app;

import java.util.HashSet;
import java.util.Set;
import java.util.Stack;

import examples.TreeNode;

class BinaryTree {

    TreeNode<Integer> buildTree(int[] preorderSequence, int[] inorderSequence) {

        Stack<TreeNode<Integer>> stack = new Stack<>();
        Set<TreeNode<Integer>> set = new HashSet<>();

        TreeNode<Integer> root = null;
        Integer preorderIndex = 0;
        Integer inorderIndex = 0;

        for (; preorderIndex < preorderSequence.length;) {
            TreeNode<Integer> node = null;
            do {
                node = new TreeNode<Integer>(preorderSequence[preorderIndex]);
                if (root == null) {
                    root = node;
                    stack.push(root);
                    continue;
                }
                if (set.contains(stack.peek()) == false) {
                    stack.peek().LeftChild = node;
                } else {
                    set.remove(stack.peek());
                    stack.pop().RightChild = node;
                }
                stack.push(node);
            } while (preorderSequence[preorderIndex++] != inorderSequence[inorderIndex]
                    && preorderIndex < preorderSequence.length);

            node = null;
            while (stack.isEmpty() == false && stack.peek().Data == inorderSequence[inorderIndex]
                    && inorderIndex < inorderSequence.length) {
                node = stack.pop();
                inorderIndex++;
            }
            stack.push(node);
            set.add(node);
        }

        return root;
    }

    // Function to print tree in Inorder
    void printInorder(TreeNode<Integer> root) {
        if (root == null)
            return;

        /* first recur on left child */
        printInorder(root.LeftChild);

        /* then print the data of node */
        System.out.print(root.Data + " ");

        /* now recur on right child */
        printInorder(root.RightChild);
    }

    void printPreOrder(TreeNode<Integer> root) {
        if (root == null)
            return;
        System.out.print(root.Data + " ");
        printPreOrder(root.LeftChild);
        printPreOrder(root.RightChild);
    }

    // driver program to test above functions
    public static void main(String args[]) {
        BinaryTree tree = new BinaryTree();

        int pre[] = new int[] { 1, 2, 4, 8, 9, 5, 10, 11, 3, 6, 7, 12, 13 };
        int in[] = new int[] { 9, 8, 4, 2, 10, 5, 11, 1, 6, 3, 13, 12, 7 };

        TreeNode<Integer> root = tree.buildTree(pre, in);

        System.out.println("Preorder Travel Order is: ");
        tree.printPreOrder(root);
        System.out.println();

        System.out.println("Inorder Travel Order is: ");
        tree.printInorder(root);
    }
}