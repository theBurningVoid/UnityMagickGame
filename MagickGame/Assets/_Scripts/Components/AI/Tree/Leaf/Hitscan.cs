using UnityEngine;
using Components.Behavior_Tree;

namespace Components.AI.Tree.Leaf {
	public class Hitscan : TreeNode {
		public override State Act(EgoComponent root) {
			//RaycastHit2D clicked = Physics2D.Raycast (transform.position, transform.right);
			Transform transform = root.transform;
			Debug.DrawRay(transform.position, transform.right, Color.red, 100, false);
			return State.SUCCESS;
		}
	}
}