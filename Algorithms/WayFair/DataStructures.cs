using System;
using System.Collections;
using System.Linq;

namespace Algorithms.WayFair
{
    public class DataStructures
    {
        public int MaxDepthViaRecursion(TreeNode root)
        {
            if (root == null) return 0;

            return Math.Max(this.MaxDepthViaRecursion(root.left), this.MaxDepthViaRecursion(root.right)) + 1;
        }

        public int MaxDepthViaLoop(TreeNode root)
        {
            var res = 0;
            var queue = new Queue();
            if (root != null) queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var size = queue.Count;
                res++;
                for (int i = 0; i < size; i++)
                {
                    var top = (TreeNode)queue.Dequeue();

                    if (top.left != null)
                    {
                        queue.Enqueue(top.left);
                    }

                    if (top.right != null)
                    {
                        queue.Enqueue(top.right);
                    }
                }
            }

            return res;
        }
    }
}
