using UnityEngine;

// Stores a point at which some attachable object may be attached. Also includes a reference to that object for convenience.
namespace Components.Attachment {
	[DisallowMultipleComponent]
	public class Hardpoint : MonoBehaviour {
		public Vector2 LocalVector2D = new Vector2(1,0); //Right-middle, assuming diameter of 1
		public EgoComponent Attached = null; //Nullable
	}
}