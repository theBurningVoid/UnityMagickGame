using UnityEngine;
using Components.Behavior_Tree;

namespace Components.AI.Tree.Branch {
	public class Delay : BranchNode {
		protected float delayAmt;

		public Delay(BranchNode child, float sec): base(child) {
			this.delayAmt = sec;
		}

		public override State Act(EgoComponent root) {
			new WaitForSeconds(delayAmt);
			return Child.Act(root);
		}
	}
}
