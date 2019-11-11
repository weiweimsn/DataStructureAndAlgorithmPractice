// https://www.geeksforgeeks.org/full-and-complete-binary-tree-from-given-preorder-and-postorder-traversals/

package examples;

public class BinaryTree_PreOrder_PostOrder {
    // A recursive function to construct Full
    // from pre[] and post[]. preIndex is used
    // to keep track of index in pre[]. l is
    // low index and h is high index for the
    // current subarray in post[]

    // variable to hold index in pre[] array
    static int preindex;

    static TreeNode<Integer> constructTreeUtil(int pre[], int post[], int l, int h, int size) {

        // Base case
        if (preindex >= size || l > h)
            return null;

        // The first node in preorder traversal is
        // root. So take the node at preIndex from
        // preorder and make it root, and increment
        // preIndex
        TreeNode<Integer> root = new TreeNode<Integer>(pre[preindex]);
        preindex++;

        // If the current subarry has only one
        // element, no need to recur or
        // preIndex > size after incrementing
        if (l == h || preindex >= size)
            return root;
        int i;

        // Search the next element of pre[] in post[]
        for (i = l; i <= h; i++) {
            if (post[i] == pre[preindex])
                break;
        }
        // Use the index of element found in
        // postorder to divide postorder array
        // in two parts. Left subtree and right subtree
        if (i <= h) {
            root.LeftChild = constructTreeUtil(pre, post, l, i, size);
            root.RightChild = constructTreeUtil(pre, post, i + 1, h, size);
        }
        return root;
    }

    // The main function to construct Full
    // Binary Tree from given preorder and
    // postorder traversals. This function
    // mainly uses constructTreeUtil()
    static TreeNode<Integer> constructTree(int pre[], int post[], int size) {
        preindex = 0;
        return constructTreeUtil(pre, post, 0, size - 1, size);
    }

    static void printInorder(TreeNode<Integer> root) {
        if (root == null)
            return;
        printInorder(root.LeftChild);
        System.out.print(root.Data + " ");
        printInorder(root.RightChild);
    }

    public static void main(String[] args) {

        int pre[] = { 1, 2, 4, 8, 9, 5, 3, 6, 7 };
        int post[] = { 8, 9, 4, 5, 2, 6, 7, 3, 1 };

        int size = pre.length;
        TreeNode<Integer> root = constructTree(pre, post, size);

        System.out.println("Inorder traversal of the constructed tree:");
        printInorder(root);

        // Inorder traversal of the constructed tree:
        // 8 4 9 2 5 1 6 3 7
    }
}