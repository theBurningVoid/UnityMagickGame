using Attachments;
using Components.Action.Event;
using UnityEngine;

namespace Components.AI.Tree.Leaf {
	class Interact : TreeNode {
		public override State Act(EgoComponent root) {
			Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D clicked = Physics2D.Raycast(cursorPos, Vector2.zero, 0f);
			if (clicked.collider != null && Mathf.Abs((root.transform.position - clicked.collider.transform.position).magnitude) < 5) {
				EgoEvents<InteractEvent>.AddEvent(new InteractEvent(root, clicked.transform.GetComponent<EgoComponent>()));
				return State.SUCCESS;
			}
			return State.FAIL;
		}
	}
}
