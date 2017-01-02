using UnityEngine;
using UnityEditor;

public sealed class PlayerController : MonoBehaviour
{
	// Use this for initialization
	void Start () {
		if (gameObject.GetComponent<Motion> () == null) {
			throw new Exceptions.InsufficientComponentRequisiteException ("GameObject with attached PlayerController " +
				"must also have a Motion Component");
		}
		if (gameObject.GetComponent<Held> () == null) {
			throw new Exceptions.InsufficientComponentRequisiteException ("GameObject with attached PlayerController " +
				"must also have a Held Component");
		}
	}

	// Update is called once per frame
	void Update () {
		//Set velocity and rotation manually. WARNING: These aren't assured to interact properly in the physics simulation.
		//Similarly, if forces and torques are used, do updating in FixedUpdate()
		Motion motion = gameObject.GetComponent<Motion> ();

		float tempAngle = InputUtilities.AngleBetween (transform.position, Camera.main.ScreenToWorldPoint (Input.mousePosition));
		Vector2 tempVec = InputUtilities.GetDualAxis ();

		motion.SetAngle (tempAngle);
		motion.SetDirection (tempVec);

		if (Input.GetButtonDown ("Fire1")) {
			Held held = gameObject.GetComponent<Held> ();
			if (held.Empty ()) {
				Vector2 cameraPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				RaycastHit2D clicked = Physics2D.Raycast (cameraPos, Vector2.zero, 0f);
				if (clicked.collider != null) {
					held.Set (clicked.collider.attachedRigidbody);
				}
			} else {
				held.Use (0);
			}
		}
	}
}