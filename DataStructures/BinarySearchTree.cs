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

        public TreeNode InsertIntoBST(TreeNode root, int val) {
            // check if the node passed as param is null then it is terminating condn return new object then.
            if(root == null)
                return new TreeNode(val);
            
            // if val is less then move to left subtree
            if(val < root.val)
                root.left = InsertIntoBST(root.left, val);
            // else move to right subtree.
            else if(val > root.val)
                root.right = InsertIntoBST(root.right, val);
            
            return root;
        }
    }
}