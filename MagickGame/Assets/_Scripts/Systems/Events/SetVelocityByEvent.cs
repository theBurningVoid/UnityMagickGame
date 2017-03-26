using UnityEngine;

// Dispatch this to move object by a factor of the given velocity, with magnitude clamped to [-1, 1]
namespace Systems.Events {
	public class SetVelocityByEvent : EgoEvent {
		public readonly EgoComponent Actor;
		public readonly Vector2 PercentMaxVelocity;

		public SetVelocityByEvent(EgoComponent actor, Vector2 percentMaxVelocity) {
			Actor = actor;
			PercentMaxVelocity = percentMaxVelocity;
		}
	}
}