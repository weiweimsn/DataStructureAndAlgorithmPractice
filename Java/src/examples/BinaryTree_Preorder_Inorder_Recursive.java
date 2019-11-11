// https://www.geeksforgeeks.org/construct-tree-from-given-inorder-and-preorder-traversal/
package examples;

class BinaryTree_Preorder_Inorder_Recursive {
    public TreeNode<Character> root;
    public static int preIndex = 0;

    /*
     * Recursive function to construct binary of size len from Inorder traversal
     * in[] and Preorder traversal pre[]. Initial values of inStrt and inEnd should
     * be 0 and len -1. The function doesn't do any error checking for cases where
     * inorder and preorder do not form a tree
     */
    public TreeNode<Character> buildTree(char[] arr, char[] pre, int inStrt, int inEnd) {
        if (inStrt > inEnd) {
            return null;
        }

        /*
         * Pick current node from Preorder traversal using preIndex and increment
         * preIndex
         */
        TreeNode<Character> tNode = new TreeNode<Character>(pre[preIndex]);
        preIndex++;

        /* If this node has no children then return */
        if (inStrt == inEnd) {
            return tNode;
        }

        /*
         * Else find the index of this node in Inorder traversal
         */
        int inIndex = search(arr, inStrt, inEnd, tNode.Data);

        /*
         * Using index in Inorder traversal, construct left and right subtress
         */
        tNode.LeftChild = buildTree(arr, pre, inStrt, inIndex - 1);
        tNode.RightChild = buildTree(arr, pre, inIndex + 1, inEnd);

        return tNode;
    }

    /*
     * Function to find index of value in arr[start...end] The function assumes that
     * value is present in in[]
     */
    int search(char arr[], int strt, int end, char value) {
        int i;
        for (i = strt; i <= end; i++) {
            if (arr[i] == value)
                return i;
        }
        return i;
    }

    /* This funtcion is here just to test buildTree() */
    void printInorder(TreeNode<Character> node) {
        if (node == null)
            return;

        /* first recur on left child */
        printInorder(node.LeftChild);

        /* then print the data of node */
        System.out.print(node.Data + " ");

        /* now recur on right child */
        printInorder(node.RightChild);
    }

    // driver program to test above functions
    public static void main(String args[]) {
        BinaryTree_Preorder_Inorder_Recursive tree = new BinaryTree_Preorder_Inorder_Recursive();
        char in[] = new char[] { 'D', 'B', 'E', 'A', 'F', 'C' };
        char pre[] = new char[] { 'A', 'B', 'D', 'E', 'C', 'F' };
        int len = in.length;
        TreeNode<Character> root = tree.buildTree(in, pre, 0, len - 1);

        // building the tree by printing inorder traversal
        System.out.println("Inorder traversal of constructed tree is : ");
        tree.printInorder(root);
    }
}