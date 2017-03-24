using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Components.Behavior_Tree;

// Tries all of it's children, and returns SUCCESS if at least one succeeded, otherwise returns FAILURE
namespace Components.AI.Tree.Selector {
	class SelectorAll: SelectorNode {
		public SelectorAll(params TreeNode[] children): base(children) {}

		public override State Act(EgoComponent root) {
			bool successFlag = false;
			foreach (TreeNode child in Children) {
				if(child.Act(root) == State.SUCCESS) successFlag = true;
			}
			return successFlag ? State.SUCCESS : State.FAIL;
		}
	}
}
