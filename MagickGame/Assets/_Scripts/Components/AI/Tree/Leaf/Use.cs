using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Attachments;
using Components.Action.Event;
using Components.AI.Tree;

namespace Components.AI.Tree.Leaf {
	class Use: TreeNode {
		public override State Act(EgoComponent root) {
			Hardpoint hardpoint;
			if (root.TryGetComponents(out hardpoint) && hardpoint.Attached != null) {
				EgoEvents<UseEvent>.AddEvent(new UseEvent(root, hardpoint.Attached.GetComponent<EgoComponent>()));
				return State.SUCCESS;
			}
			return State.FAIL;
		}
	}
}
