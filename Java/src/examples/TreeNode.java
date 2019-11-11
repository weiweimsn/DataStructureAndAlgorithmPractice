package examples;

public class TreeNode<T> {
    public T Data;
    public TreeNode<T> LeftChild;
    public TreeNode<T> RightChild;

    public TreeNode(T x) {
        Data = x;
    }
}