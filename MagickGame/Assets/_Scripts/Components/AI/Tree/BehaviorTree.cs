using UnityEngine;

// Base component for storing an entity's behavior tree structure
namespace Components.AI.Tree {
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
