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

        public TreeNode DeleteNode(TreeNode root, int key) {
            if(root == null)
                return null;
            
            var node = DeleteNodeBST(root, key);

            return node;
        }

        public TreeNode DeleteNodeBST(TreeNode node, int key)
        {
            // edge cases.
            if(node == null)
                return null;
            
            // when key is less than current node value move left. we return the modified tree hence node.left is assigned.
            if(key < node.val)
            {
                node.left = DeleteNodeBST(node.left, key);
                return node;
            }   
            // when it is greater
            else if(key > node.val)
            {
                node.right = DeleteNodeBST(node.right, key);
                return node;
            }   
            else
            {
                // when node.val is equal to key
                // if it is leaf node ...delete the node from the tree by return null.
                if(node.left == null && node.right == null)
                {
                    return null;
                }
                else if(node.left != null && node.right != null)
                {
                    // if it has both subtree as not null, then search the smallest in right subtree.
                    var leftMostNode = SearchLeft(node.right);

                    // replace the current node's value with that.
                    node.val = leftMostNode.val;

                    // delete the smalled node and assign the resultant tree to the right.
                    node.right = DeleteNodeBST(node.right, leftMostNode.val);

                    return node;
                }
                else if ( node.left != null)
                {
                    // if only left is not null, then assign it to current/ simply return it.
                    var left = node.left;
                    node = null;
                    return left;
                }
                else
                {
                    // similarly for right subtree.
                    var right = node.right;
                    node = null;
                    return right;
                }
            }
        }

        public TreeNode SearchLeft(TreeNode node)
        {
            var current = node;

            while(current.left != null)
            {
                current = current.left;
            }

            return current;
        }
    
        public (TreeNode pre, TreeNode succ) FindPS(TreeNode root, int key)
        {
            TreeNode temp = root;
    
            while(temp != null)
            {
                if(temp.val == key)
                    break;
                    
                if(temp.val < key)
                    temp = temp.right;
                else
                    temp = temp.left;
            }
            
        
            TreeNode left = temp.left;
            
            while(left!= null && left.right != null)
            {
                left = left.right;
            }
            
            TreeNode right = temp.right;
            
            while(right != null && right.left != null)
            {
                right = right.left;
            }
            
            return (left,right);
        }
    }
}