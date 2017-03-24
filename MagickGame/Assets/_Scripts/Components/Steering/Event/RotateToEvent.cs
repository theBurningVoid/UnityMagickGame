namespace Components.Steering.Event {
	class RotateToEvent: EgoEvent {
		public readonly EgoComponent Actor;
		public readonly float TargetFacing;

		public RotateToEvent(EgoComponent actor, float targetFacing) {
			Actor = actor;
			TargetFacing = targetFacing;
		}
	}
}
