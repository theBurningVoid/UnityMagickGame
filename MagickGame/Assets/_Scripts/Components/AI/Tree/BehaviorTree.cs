using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Components.AI.Tree;
using UnityEngine;

namespace Components.Behavior_Tree {
	[DisallowMultipleComponent]
	class BehaviorTree: MonoBehaviour {
		public TreeNode TrunkNode;

		public static BehaviorTree Initialize(GameObject entity, TreeNode trunk) {
			BehaviorTree tree = entity.AddComponent<BehaviorTree>();
			tree.TrunkNode = trunk;
			return tree;
		}
	}
}
