using UnityEngine;

namespace Components.Steering.Event {
	public class SetVelocityByEvent : EgoEvent {
		public readonly EgoComponent Actor;
		public readonly Vector2 PercentMaxVelocity;

		public SetVelocityByEvent(EgoComponent actor, Vector2 percentMaxVelocity) {
			Actor = actor;
			PercentMaxVelocity = percentMaxVelocity;
		}
	}
}