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
		Vector2 cursorPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//Set velocity and rotation manually. WARNING: These aren't assured to interact properly in the physics simulation.
		//Similarly, if forces and torques are used, do updating in FixedUpdate()
		Motion motion = gameObject.GetComponent<Motion> ();
		Held held = gameObject.GetComponent<Held> ();

		float tempAngle = InputUtilities.AngleBetween (transform.position, cursorPos);
		Vector2 tempVec = InputUtilities.GetDualAxis ();

		motion.SetAngle (tempAngle);
		motion.SetDirection (tempVec);

		if (Input.GetButtonDown ("Fire1")) {
			held.Use ();
		}
		if (Input.GetButtonDown ("Interact")) {
			RaycastHit2D clicked = Physics2D.Raycast (cursorPos, Vector2.zero, 0f);
			if (clicked.collider != null && Mathf.Abs((transform.position - clicked.collider.transform.position).magnitude) < 5) {
				held.Set (clicked.collider.attachedRigidbody);
			}
		}
		if (Input.GetButtonDown ("Drop")) {
			held.Drop ();
		}
	}
}