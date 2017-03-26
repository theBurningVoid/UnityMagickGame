// Dispatch this event to break the Hardpoint-Mountpoint connection and unparent the specified child.
namespace Systems.Events {
	class DetachEvent: EgoEvent {
		// Must have been connected by an AttachEvent and not had relevant components removed
		public readonly EgoComponent Child;

		public DetachEvent(EgoComponent child) {
			Child = child;
		}
	}
}
