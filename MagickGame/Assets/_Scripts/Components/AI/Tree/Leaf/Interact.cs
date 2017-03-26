using Systems.Events;
using UnityEngine;

// A leaf node that causes the actor to interact with the object it is focusing on
namespace Components.AI.Tree.Leaf {
	class Interact : TreeNode {
		public override CompletionState Act(EgoComponent root) {
			// TODO: Generify for use by non-player entities
			// Add Focused component to detail object entity is currently considering
			Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D clicked = Physics2D.Raycast(cursorPos, Vector2.zero, 0f);
			if (clicked.collider != null && Mathf.Abs((root.transform.position - clicked.collider.transform.position).magnitude) < 5) {
				EgoEvents<InteractEvent>.AddEvent(new InteractEvent(root, clicked.transform.GetComponent<EgoComponent>()));
				return CompletionState.SUCCESS;
			}
			return CompletionState.FAIL;
		}
	}
}
