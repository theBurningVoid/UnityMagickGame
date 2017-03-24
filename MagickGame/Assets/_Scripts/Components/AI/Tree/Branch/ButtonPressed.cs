using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Components.Behavior_Tree;
using UnityEngine;

namespace Components.AI.Tree.Branch {
	class ButtonPressed : BranchNode {
		public String Button;

		public ButtonPressed(TreeNode child, String button) : base(child) {
			Button=button;
		}

		public override State Act(EgoComponent root) {
			if (Input.GetButtonDown(Button)) {
				return Child.Act(root);
			}
			return State.FAIL;
		}
	}
}
