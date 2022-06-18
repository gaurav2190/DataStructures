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
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}