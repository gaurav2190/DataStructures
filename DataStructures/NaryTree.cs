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
            
            foreach(var item in root.children)
            {
                Postorder(item, orderList);
            }
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
            while(queue.Count > 0)
            {
                while(queue.Count > 0)
                {
                    node = queue.Dequeue();
                    temp.Add(node.val);
                    if(node.children.Count > 0)
                        childrenTemp.AddRange(node.children);
                }
                
                result.Add(new List<int>(temp));
                temp.Clear();
                
                foreach(var item in childrenTemp)
                {
                    queue.Enqueue(item);
                }
                childrenTemp.Clear();
            }
            
            return result;
        }

        public int MaxDepth(NaryNode root) {
            if(root == null)
                return 0;
            if(root.children == null || root.children.Count == 0)
                return 1;
            
            int maxDepth = -1;
            int tempDepth = -1;
            foreach(var item in root.children)
            {
                tempDepth = MaxDepth(item);
                
                if(maxDepth < tempDepth)
                    maxDepth = tempDepth;
            }
            
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