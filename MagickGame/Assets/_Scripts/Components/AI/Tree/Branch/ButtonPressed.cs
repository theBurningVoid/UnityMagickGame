using System;
using UnityEngine;

// A BranchNode that passes to its child if a certain button has just been pressed.
namespace Components.AI.Tree.Branch {
	class ButtonPressed : BranchNode {
		public String Button;

		public ButtonPressed(TreeNode child, String button) : base(child) {
			Button=button;
		}

		public override CompletionState Act(EgoComponent root) {
			if (Input.GetButtonDown(Button)) {
				return Child.Act(root);
			}
			return CompletionState.FAIL;
		}
	}
}
