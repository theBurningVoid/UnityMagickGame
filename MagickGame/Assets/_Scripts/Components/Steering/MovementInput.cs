using UnityEngine;

// Stores the input axes by which the attached entity determines its movement
namespace Components.Steering {
	public class MovementInput: MonoBehaviour {
		public string HorizontalAxis = "Horizontal";
		public string VerticalAxis = "Vertical";
	}
}
