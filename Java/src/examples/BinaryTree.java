package examples;

import java.util.*;

class BinaryTree {
    static Set<TreeNode<Integer>> set = new HashSet<>();
    static Stack<TreeNode<Integer>> stack = new Stack<>();

    // Function to build tree using given traversal
    public TreeNode<Integer> buildTree(int[] preorder, int[] inorder) {

        TreeNode<Integer> root = null;
        for (int pre = 0, in = 0; pre < preorder.length;) {

            TreeNode<Integer> node = null;
            do {
                node = new TreeNode<Integer>(preorder[pre]);
                if (root == null) {
                    root = node;
                }
                if (!stack.isEmpty()) {
                    if (set.contains(stack.peek())) {
                        set.remove(stack.peek());
                        stack.pop().RightChild = node;
                    } else {
                        stack.peek().LeftChild = node;
                    }
                }
                stack.push(node);
            } while (preorder[pre++] != inorder[in] && pre < preorder.length);

            node = null;
            while (!stack.isEmpty() && in < inorder.length && stack.peek().Data == inorder[in]) {
                node = stack.pop();
                in++;
            }

            if (node != null) {
                set.add(node);
                stack.push(node);
            }
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