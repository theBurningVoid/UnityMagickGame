namespace Components.AI.Tree.Selector {
	public abstract class SelectorNode : TreeNode {
		// A Priority-ordered list of children to select from to run
		public TreeNode[] Children;

		public SelectorNode(params TreeNode[] children) {
			Children = children;
		}
	}
}