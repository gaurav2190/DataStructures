namespace DataStructures
{
    public class BinarySearchTree
    {
        public TreeNode SearchBST(TreeNode root, int val) {
            if(root == null)
                return null;
            if(root.val == val)
                return root;
            
            var leftResult = SearchBST(root.left, val);
            
            if(leftResult != null)
                return leftResult;
            
            var rightResult = SearchBST(root.right, val);
            if(rightResult != null)
                return rightResult;
            
            return null;        
        }
    }
}