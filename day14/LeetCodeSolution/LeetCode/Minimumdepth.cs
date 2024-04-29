using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;

        public Node(int val = 0, Node left = null, Node right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

    }
    public class Minimumdepth
    {
        Node root;

        public async Task<int> MinDepth(Node root)
        {
            if(root == null)
            {
                return 0;
            }
            if(root.left == null && root.right == null)
            {
                return 1;
            }
            int min = int.MaxValue;
            if(root.left != null)
            {
                min = Math.Min(await MinDepth(root.left), min);
            }
            if(root.right != null)
            {
                min = Math.Min(await MinDepth(root.right), min);
            }
            return min + 1;
        }
    }
}
