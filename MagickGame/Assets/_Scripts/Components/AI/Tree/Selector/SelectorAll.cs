// A SelectorNode that tries all of it's children, and returns SUCCESS if at least one succeeded, otherwise returns FAILURE
namespace Components.AI.Tree.Selector {
	class SelectorAll: SelectorNode {
		public SelectorAll(params TreeNode[] children): base(children) {}

		public override CompletionState Act(EgoComponent root) {
			bool successFlag = false;
			foreach (TreeNode child in Children) {
				if(child.Act(root) == CompletionState.SUCCESS) successFlag = true;
			}
			return successFlag ? CompletionState.SUCCESS : CompletionState.FAIL;
		}
	}
}
