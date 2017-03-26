using Components.AI.Tree;

// Deals with updating and controlling entities' BehaviorTrees
namespace Systems {
	class BehaviorTreeSystem: EgoSystem<EgoConstraint<BehaviorTree>> {

		// Update the behavior trees of every entity
		public override void Update() {
			constraint.ForEachGameObject((egoComponent, behaviorTree) => behaviorTree.TrunkNode.Act(egoComponent));
		}
	}
}
