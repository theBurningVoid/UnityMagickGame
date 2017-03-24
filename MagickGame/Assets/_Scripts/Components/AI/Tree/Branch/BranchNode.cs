namespace Components.AI.Tree.Branch {
	public abstract class BranchNode : TreeNode {
		// The next node in line to be called
		public TreeNode Child;

		public BranchNode(TreeNode child) {
			Child = child;
		}
	}
}