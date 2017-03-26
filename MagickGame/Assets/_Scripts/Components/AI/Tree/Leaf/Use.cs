using Components.Attachment;
using Systems.Events;

// A leaf node that causes the actor to use the object it is holding
namespace Components.AI.Tree.Leaf {
	class Use: TreeNode {
		public override CompletionState Act(EgoComponent root) {
			Hardpoint hardpoint;
			if (root.TryGetComponents(out hardpoint) && hardpoint.Attached != null) {
				EgoEvents<UseEvent>.AddEvent(new UseEvent(root, hardpoint.Attached.GetComponent<EgoComponent>()));
				return CompletionState.SUCCESS;
			}
			return CompletionState.FAIL;
		}
	}
}
