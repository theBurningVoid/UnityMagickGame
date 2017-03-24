using Components.Attachment.Event;
using Components.Attachment;
using UnityEngine;

namespace Assets._Scripts.Components.Attachment.System {
	class AttachmentSystem: EgoSystem {
		public override void Start() {
			EgoEvents<AttachEvent>.AddHandler(Handle);
			EgoEvents<DetachEvent>.AddHandler(Handle);
		}

		// Handles Attaching Hardpoint-Mountpoint pairs
		void Handle(AttachEvent e) {
			Attachments.Hardpoint hardpoint;
			Mountpoint mountpoint;
			if (e.Parent != e.Child && e.Parent.TryGetComponents(out hardpoint) && e.Child.TryGetComponents(out mountpoint)) {
				e.Child.transform.SetParent(e.Parent.transform);
				Ego.SetParent(e.Parent, e.Child);
				e.Child.transform.localRotation = Quaternion.AngleAxis(mountpoint.LocalRotation, Vector3.forward);
				e.Child.transform.localPosition = hardpoint.LocalVector2D + mountpoint.LocalVector2D;

				// Makes sure attached body doesn't change parent's center of gravity or mass, and doesn't collide with the parent
				Rigidbody2D rigidbody2D;
				if(e.Child.TryGetComponents(out rigidbody2D)) {
					rigidbody2D.isKinematic=true;
					rigidbody2D.simulated=false;
				}

				hardpoint.Attached=mountpoint.GetComponent<EgoComponent>();
			}
		}

		// Handles Detaching Hardpoint-Mountpoint pairs
		void Handle(DetachEvent e) {
			Attachments.Hardpoint hardpoint;
			if (e.Child.parent.TryGetComponents(out hardpoint)) {
				e.Child.transform.SetParent(null);
				Ego.SetParent(null, e.Child);
				Rigidbody2D rigidbody2D;

				// Should actually return a rigidbody to their defaults for their dropped state, which is usually this
				if(e.Child.TryGetComponents(out rigidbody2D)) {
					rigidbody2D.isKinematic=false;
					rigidbody2D.simulated=true;
				}
			}

			hardpoint.Attached = null;
		}
	}
}
