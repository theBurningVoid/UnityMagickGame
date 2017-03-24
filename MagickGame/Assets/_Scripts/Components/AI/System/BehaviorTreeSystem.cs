using Components.Behavior_Tree;

namespace Components.AI.System {
	class BehaviorTreeSystem: EgoSystem<EgoConstraint<BehaviorTree>> {
		public override void Update() {
			constraint.ForEachGameObject((egoComponent, behaviorTree) => behaviorTree.TrunkNode.Act(egoComponent));
		}
	}
}
