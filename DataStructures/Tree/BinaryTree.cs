namespace DataStructures
{
    using System.Collections.Generic;
    using System.Collections;
    using System.Text;
    using System;

    public class BinaryTree
    {
        private static int pIndex = 0;
        public string InOrder(TreeNode node, int level)
        {
            if(node == null)
                return level.ToString();
            
            var order = new StringBuilder();
            level++;
            order.Append(InOrder(node.left, level));
            order.Append(node.val);
            order.Append(InOrder(node.right, level));

            return order.ToString();             
        }

        //public static int pIndex = 0;
        /// <summary>
        /// Build Tree from given Post and In order array/
        /// </summary>
        /// <param name="inorder"></param>
        /// <param name="postorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree(int[] inorder, int[] postorder) 
        {
            pIndex = postorder.Length;
            var result = BuildTreePostInOrder(inorder, postorder, 0, inorder.Length-1);
            
            return result;
        }
    
        public TreeNode BuildTreePostInOrder(int[] inorder, int[] postorder, int start, int end)
        {
            /**
                here we are recursive approach. We keep a track of static index pointer which starts from last index goes
                all the way to 0 of post order array.

                As we know that in postorder array starting from last you would get Right sub tree first and then left 
                sub tree. hence we set Right child before left. In this process we keep decrementing the pIndex so that
                it reaches to the correct index when we start setting left sub tree of the nodes.
                this is kinda of divide and conquer strategy which we use to seggragate left and right subtree elements 
                inside in order array.  
            **/
            if(start > end)
                return null;
            
            pIndex--;
            var node = new TreeNode(postorder[pIndex]);

            if(start == end)
                return node;
            var index = SearchIndex(inorder, start, end, postorder[pIndex]);

            if(index == -1)
                return null;

            node.right = BuildTreePostInOrder(inorder, postorder, index+1, end);
            node.left = BuildTreePostInOrder(inorder, postorder, start, index-1);

            return node;
        }

        public int SearchIndex(int[] inorder,int start, int end, int val)
        {
            for(int i = start; i<= end; i++)
            {
                if(inorder[i] == val)
                    return i;
            }

            return -1;
        }

        public TreeNode BuildTree2(int[] preorder, int[] inorder) {
            pIndex = -1;
            var result = BuildTreePreInOrder(preorder, inorder, 0, inorder.Length-1);
            
            return result;
        }

        public TreeNode BuildTreePreInOrder(int[] preorder, int[] inorder, int start, int end)
        {
            /**
            Here logic is different from earlier in the way how we deal with the pIndex;
            In this case we initialize pIndex with -1 and then start incrementing down the recursion tree
            we set first left sub tree in this case as Pre order has left subtree elements before right sub tree elements.
            **/
            if(start > end)
                return null;
            pIndex++;
            var node = new TreeNode(preorder[pIndex]);
            
            if(start == end)
                return node;
            
            var index = SearchIndex(inorder, node.val, start, end);
            
            node.left = BuildTreePreInOrder(preorder, inorder, start, index-1);
            node.right = BuildTreePreInOrder(preorder, inorder, index+1, end);
            
            return node;        
        }

        /// <summary>
        /// Connect nodes at the same level in binary tree.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public BinaryNode Connect(BinaryNode root) {
            /**
            Here we are taking approach of level order traversal of the binary tree where we use queue.
            with the help of queue and list, we get a list of nodes at the same level.
            we iterate over that and set the next pointer in each node.
            return the root.
            **/

            if(root == null)
                return null;
            var queue = new Queue<BinaryNode>();
            var temp = new List<BinaryNode>();

            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                while(queue.Count > 0)
                {
                    var item = queue.Dequeue();
                    temp.Add(item);
                }

                foreach (var item1 in temp)
                {
                    if(item1.left != null)
                        queue.Enqueue(item1.left);
                    if(item1.right != null)
                        queue.Enqueue(item1.right);
                }

                for(int i = 0; i < temp.Count-1; i++)
                {
                    temp[i].next = temp[i+1];
                }

                temp.Clear();
            }

            return root;            
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            /**
                Logic is build on DFS algo also preorder

                below we check in both left and right subtree the presence of p and q.

                if present it would return not null object.
                if for any node both left and right are not null, we return it and keep returning to the top
                as it is DFS, the condn for the lowest ancestor would be met first which would help in deciding the object.

                for other nodes we would check that either of left or right whichever is not nulll..return it.
            **/

            if(root == null || root == p || root == q)
                return root;

            var left = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);

            if(left != null && right != null)
                return root;

            return left!=null ? left : right;        
        }       
        
    }

    public class BinaryNode {
        public int val;
        public BinaryNode left;
        public BinaryNode right;
        public BinaryNode next;

        public BinaryNode() {}

        public BinaryNode(int _val) {
            val = _val;
        }

        public BinaryNode(int _val, BinaryNode _left, BinaryNode _right, BinaryNode _next) {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}