// Dispatch this event to create a Hardpoint-Mountpoint connection and parent the objects.
namespace Components.Attachment.Event {
	class AttachEvent: EgoEvent {
		// Child must have a Mountpoint component, Parent must have a Hardpoint component, Child must not equal Parent.
		// Warning! Do not remove relevant components from Parent or Child whilst connected.
		public readonly EgoComponent Child, Parent;

		public AttachEvent(EgoComponent child, EgoComponent parent) {
			Child = child;
			Parent = parent;
		}
	}
}
