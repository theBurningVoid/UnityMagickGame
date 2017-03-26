// Dispatch this to rotate object to given angle, in radians
namespace Systems.Events {
	class RotateToEvent: EgoEvent {
		public readonly EgoComponent Actor;
		public readonly float TargetFacing;

		public RotateToEvent(EgoComponent actor, float targetFacing) {
			Actor = actor;
			TargetFacing = targetFacing;
		}
	}
}
