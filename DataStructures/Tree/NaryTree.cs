namespace DataStructures{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class NaryTree
    {
        public IList<int> Preorder(NaryNode root, IList<int> preOrderList = null) {
            if(preOrderList == null)
                preOrderList = new List<int>();
            
            if(root == null)
                return new List<int>();
            
            preOrderList.Add(root.val);
            
            foreach(var item in root.children)
            {
                Preorder(item, preOrderList);
            }
            
            return preOrderList;
        }

        public IList<int> Postorder(NaryNode root, IList<int> orderList = null) { 
            if(orderList == null)
                orderList = new List<int>();
            
            if(root == null)
                return orderList;
            
            // first process children
            foreach(var item in root.children)
            {
                Postorder(item, orderList);
            }

            // then the node.
            orderList.Add(root.val);
                    
            return orderList;
        }

        public IList<IList<int>> LevelOrder(NaryNode root) {

            /**
                The idea here is similar to how it was in Binary tree.
                we do traverse nodes at each level in one go.
            **/
            var result = new List<IList<int>>();
            if(root == null)
                return result;
            
            var queue = new Queue<NaryNode>();
            var temp = new List<int>();
            var childrenTemp = new List<NaryNode>();
            NaryNode node = null;
            queue.Enqueue(root);
            int currentCount = 0;
            while(queue.Count > 0)
            {
                currentCount = queue.Count;
                while(currentCount > 0)
                {
                    node = queue.Dequeue();
                    temp.Add(node.val);
                    currentCount--;
                }
                
                result.Add(new List<int>(temp));
                temp.Clear();
            }
            
            return result;
        }

        public int MaxDepth(NaryNode root) {
            if(root == null)
                return 0;
            
            // termination case for recursion.
            if(root.children == null || root.children.Count == 0)
                return 1;
            
            int maxDepth = -1;
            int tempDepth = -1;
             
            // check for each child at each level.
            foreach(var item in root.children)
            {
                tempDepth = MaxDepth(item);
                
                if(maxDepth < tempDepth)
                    maxDepth = tempDepth;
            }
            
            // once calculated we add it by 1 to take current node into consideration.
            return maxDepth + 1;
        }
    }

    public class NaryNode {
        public int val;
        public IList<NaryNode> children;

        public NaryNode() {}

        public NaryNode(int _val) {
            val = _val;
        }

        public NaryNode(int _val,IList<NaryNode> _children) {
            val = _val;
            children = _children;
        }
    }
}