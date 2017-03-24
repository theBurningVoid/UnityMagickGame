using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Attachments;
using Components.Attachment.Event;
using Components.Behavior_Tree;
using UnityEngine;

namespace Components.AI.Tree.Leaf {
	[DisallowMultipleComponent]
	class Drop: TreeNode {
		public override State Act(EgoComponent root) {
			Hardpoint hardpoint;
			if (root.TryGetComponents(out hardpoint) && hardpoint.Attached != null) {
				EgoEvents<DetachEvent>.AddEvent(new DetachEvent(hardpoint.Attached));
				return State.SUCCESS;
			}
			return State.FAIL;
		}
	}
}
