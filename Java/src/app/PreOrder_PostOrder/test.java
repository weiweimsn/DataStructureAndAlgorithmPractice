package app.PreOrder_PostOrder;

import examples.TreeNode;

class test {
    public static void main(String[] args) {
        TreeNode<Integer> root = new TreeNode<>(1);
        root.LeftChild = new TreeNode<Integer>(2);
        root.RightChild = new TreeNode<Integer>(3);

        root.RightChild.LeftChild = new TreeNode<Integer>(4); // 3.left = 4;
        root.RightChild.RightChild = new TreeNode<Integer>(5); // 3.right = 5;

        root.RightChild.RightChild.LeftChild = new TreeNode<Integer>(6); // 5.left =6
        root.RightChild.RightChild.RightChild = new TreeNode<Integer>(7); // 5.right = 7

        System.out.println("Preorder Traversal Order is:");
        PreOrderTravel(root);

        System.out.println("\nPostorder Traversal Order is:");
        PostOrderTravel(root);
    }

    static void PreOrderTravel(TreeNode<Integer> root) {
        if (root == null)
            return;

        System.out.print(root.Data + "  ");
        PreOrderTravel(root.LeftChild);
        PreOrderTravel(root.RightChild);
    }

    static void PostOrderTravel(TreeNode<Integer> root) {
        if (root == null)
            return;
        PostOrderTravel(root.LeftChild);
        PostOrderTravel(root.RightChild);
        System.out.print(root.Data + "  ");
    }
}
