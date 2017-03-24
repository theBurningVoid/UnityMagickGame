using UnityEngine;

// Stores a point at which an attachable object attaches itself to some Hardpoint. Also contains relative rotation value.
namespace Components.Attachment {
	[DisallowMultipleComponent]
	class Mountpoint: MonoBehaviour {
		public Vector2 LocalVector2D = new Vector2(0, 0);
		public float LocalRotation = 0;
	}
}
