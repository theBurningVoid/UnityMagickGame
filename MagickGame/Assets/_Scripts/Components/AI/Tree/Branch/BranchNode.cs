// A TreeNode that contains one child. 
// Used as a gate for its child, checking that a certain condition is met before calling its child.
namespace Components.AI.Tree.Branch {
	public abstract class BranchNode : TreeNode {
		// The next node in line to be called
		public TreeNode Child;

		public BranchNode(TreeNode child) {
			Child = child;
		}
	}
}