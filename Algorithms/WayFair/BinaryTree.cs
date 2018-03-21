using System;

namespace Algorithms.WayFair
{
    
    public class TreeNode {
           public string name;
           public double value; 
           public TreeNode left, right;
           
        // Constructor  to create a single node 
		public TreeNode (string name, double d) {
              this.name = name;
              value = d;
              left = null;
              right = null;
           }
    }


	// The Binary tree itself
	public class BinarySearchTree
	{
		// Implements:

		// Count()
		// Clear()
		// Insert()
		// Delete()
		// FindSymbol()
		//
		// Usage:
		//
		//  TBinarySTree bt = new TBinarySTree();
		//  bt.Insert ("Bill", "3.14");
		//  bt.Insert ("John". 2.71");
		//  etc.
		//  node = bt.FindSymbol ("Bill");
		//  WriteLine ("Node value = {0}\n", node.value);
		//

	    private TreeNode root;     // Points to the root of the tree
		private int _Count = 0;
	    
     	public BinarySearchTree()
		{
		    root = null;
			_Count = 0;
		}
		 		
		
		// Recursive destruction of binary search tree, called by method Clear
		// and destroy. Can be used to kill a sub-tree of a larger tree.
		// This is a hanger on from its Delphi origins, it might be dispensable
		// given the garbage collection abilities of .NET
        private void KillTree (ref TreeNode p) {
           if (p != null) {
             KillTree (ref p.left);
             KillTree (ref p.right);
             p = null;
		   }
        }

		/// <summary>
		/// Clear the binary tree.
		/// </summary>
		public void Clear() {
		   KillTree (ref root);
		   _Count = 0;
		} 
			
		/// <summary>
		/// Returns the number of nodes in the tree
		/// </summary>
		/// <returns>Number of nodes in the tree</returns>
		public int Count() {
			return _Count;
		}      

		/// <summary>
		/// Find name in tree. Return a reference to the node
		/// if symbol found else return null to indicate failure.
		/// </summary>
		/// <param name="name">Name of node to locate</param>
		/// <returns>Returns null if it fails to find the node, else returns reference to node</returns>
		public TreeNode FindSymbol (string name) {
              TreeNode np = root;
              int cmp;
              while (np != null) {
                    cmp = string.Compare(name, np.name);
                    if (cmp == 0)   // found !
                       return np;

                    if (cmp < 0) 
                       np = np.left;
                    else
                       np = np.right;
              }
              return null;  // Return null to indicate failure to find name
		}
		
		
	    // Recursively locates an empty slot in the binary tree and Inserts the node
		private void Add (TreeNode node, ref TreeNode tree) {
		  if (tree == null) 
		     tree = node;
		  else {
			  // If we find a node with the same name then it's 
			  // a duplicate and we can't continue
			  int comparison = string.Compare(node.name, tree.name);
			  if (comparison == 0) 
				  throw new Exception ();
             
			  if (comparison < 0) { 
                 Add (node, ref tree.left);
             } else {
                 Add (node, ref tree.right);
             }
   		  }
		}
		
		/// <summary>
		/// Add a symbol to the tree if it's a new one. Returns reference to the new
		/// node if a new node Inserted, else returns null to indicate node already present.
		/// </summary>
		/// <param name="name">Name of node to add to tree</param>
		/// <param name="d">Value of node</param>
		/// <returns> Returns reference to the new node is the node was Inserted.
		/// If a duplicate node (same name was located then returns null</returns>
		public TreeNode Insert (string name, double d) {
            TreeNode node = new TreeNode(name, d);
			try {  
				if (root == null) 
					root = node;
				else
					Add (node, ref root); 
				_Count++;
				return node;
			} catch (Exception) {
				return null;
			}
		}

		// Searches for a node with name key, name. If found it returns a reference
		// to the node and to thenodes parent. Else returns null.
		private TreeNode FindParent (string name, ref TreeNode parent) {
			TreeNode np = root;
			parent = null;
			int cmp;
			while (np != null) {
				cmp = string.Compare(name, np.name);
				if (cmp == 0)   // found !
					return np;

				if (cmp < 0) { 
					parent = np;
					np = np.left;
				}
				else {
					parent = np;
					np = np.right;
				}
			}
			return null;  // Return null to indicate failure to find name
		}

		/// <summary>
		/// Find the next ordinal node starting at node startNode.
		/// Due to the structure of a binary search tree, the
		/// successor node is simply the left most node on the right branch.
		/// </summary>
		/// <param name="startNode">Name key to use for searching</param>
		/// <param name="parent">Returns the parent node if search successful</param>
		/// <returns>Returns a reference to the node if successful, else null</returns>
		public TreeNode FindSuccessor (TreeNode startNode, ref TreeNode parent) {
			parent = startNode;
			// Look for the left-most node on the right side
			startNode = startNode.right; 
			while (startNode.left != null) {
				parent = startNode;
				startNode = startNode.left;
			}
			return startNode;
		}

		/// <summary>
		/// Delete a given node. This is the more complex method in the binary search
		/// class. The method considers three senarios, 1) the Deleted node has no
		/// children; 2) the Deleted node as one child; 3) the Deleted node has two
		/// children. Case one and two are relatively simple to handle, the only
		/// unusual considerations are when the node is the root node. Case 3) is
		/// much more complicated. It requires the location of the successor node.
		/// The node to be Deleted is then replaced by the sucessor node and the
		/// successor node itself Deleted. Throws an exception if the method fails
		/// to locate the node for deletion.
		/// </summary>
		/// <param name="key">Name key of node to Delete</param>
		public void Delete (string key) {
			TreeNode parent = null;
			// First find the node to Delete and its parent
			TreeNode nodeToDelete = FindParent (key, ref parent);
			if (nodeToDelete == null) 
				throw new Exception ("Unable to Delete node: " + key.ToString());  // can't find node, then say so 
			
			// Three cases to consider, leaf, one child, two children

			// If it is a simple leaf then just null what the parent is pointing to
			if ((nodeToDelete.left == null) && (nodeToDelete.right == null)) {
				if (parent == null) {
					root = null;
					return;
				}

				// find out whether left or right is associated 
				// with the parent and null as appropriate
				if (parent.left == nodeToDelete)
					parent.left = null;
				else
					parent.right = null;
				_Count--;
				return;
			}

			// One of the children is null, in this case
			// Delete the node and move child up
			if (nodeToDelete.left == null) {
				// Special case if we're at the root
				if (parent == null) {
					root = nodeToDelete.right;
					return;
				}

				// Identify the child and point the parent at the child
				if (parent.left == nodeToDelete)
                    parent.right = nodeToDelete.right;
				else 
					parent.left = nodeToDelete.right;
				nodeToDelete = null; // Clean up the Deleted node
				_Count--;
				return;
			}

			// One of the children is null, in this case
			// Delete the node and move child up
			if (nodeToDelete.right == null) {
				// Special case if we're at the root			
				if (parent == null) {
					root = nodeToDelete.left;
					return;
				}

				// Identify the child and point the parent at the child
				if (parent.left == nodeToDelete)
					parent.left = nodeToDelete.left;
				else 
					parent.right = nodeToDelete.left;
				nodeToDelete = null; // Clean up the Deleted node
				_Count--;
				return;
			}

			// Both children have nodes, therefore find the successor, 
			// replace Deleted node with successor and remove successor
			// The parent argument becomes the parent of the successor
			TreeNode successor = FindSuccessor (nodeToDelete, ref parent);
			// Make a copy of the successor node
			TreeNode tmp = new TreeNode (successor.name, successor.value);
			// Find out which side the successor parent is pointing to the
			// successor and remove the successor
			if (parent.left == successor)
				parent.left = null;
			else
				parent.right = null;

			// Copy over the successor values to the Deleted node position
			nodeToDelete.name = tmp.name;
			nodeToDelete.value = tmp.value;
			_Count--;
		}


		// Simple 'drawing' routines
		private string DrawNode (TreeNode node) {
			if (node == null)
				return "empty";

			if ((node.left == null) && (node.right == null))
				return node.name;
			if ((node.left != null) && (node.right == null))
				return node.name + "(" + DrawNode (node.left) + ", _)";
			
			if ((node.right != null) && (node.left == null))
				return node.name + "(_, " + DrawNode (node.right) + ")";

			return node.name + "(" + DrawNode (node.left) + ", " + DrawNode (node.right) + ")";
		}


		/// <summary>
		/// Return the tree depicted as a simple string, useful for debugging, eg
		/// 50(40(30(20, 35), 45(44, 46)), 60)
		/// </summary>
		/// <returns>Returns the tree</returns>
 		public string DrawTree() {
			return DrawNode (root);
		}

        public TreeNode RootNode()
        {
            return root;
        }
    }
}
