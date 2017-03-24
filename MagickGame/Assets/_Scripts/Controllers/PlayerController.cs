using Attachments;
using Components.Action.Event;
using Components.Attachment.Event;
using Components.Steering.Event;
using UnityEngine;
using UnityEditor;

public sealed class PlayerController : MonoBehaviour
{
	// Use this for initialization
	void Start () {
		/*if (gameObject.GetComponent<Motion> () == null) {
			throw new Exceptions.InsufficientComponentRequisiteException ("GameObject with attached PlayerController " +
				"must also have a Motion Component");
		}*/
	}

	// Update is called once per frame
	void Update() {
		Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//Set velocity and rotation manually. WARNING: These aren't assured to interact properly in the physics simulation.
		//Similarly, if forces and torques are used, do updating in FixedUpdate()

		EgoComponent egoComponent = GetComponent<EgoComponent>();

		float tempAngle = InputUtilities.AngleBetween(transform.position, cursorPos);
		Vector2 tempVec = InputUtilities.GetDualAxis();

		EgoEvents<RotateToEvent>.AddEvent(new RotateToEvent(egoComponent, tempAngle));
		EgoEvents<SetVelocityByEvent>.AddEvent(new SetVelocityByEvent(egoComponent, tempVec));

		
		if (Input.GetButtonDown("Interact")) {
			RaycastHit2D clicked = Physics2D.Raycast(cursorPos, Vector2.zero, 0f);
			if (clicked.collider != null && Mathf.Abs((transform.position - clicked.collider.transform.position).magnitude) < 5) {
				EgoEvents<InteractEvent>.AddEvent(new InteractEvent(egoComponent, clicked.transform.GetComponent<EgoComponent>()));
			}
		}

		Hardpoint hardpoint;
		if (egoComponent.TryGetComponents(out hardpoint) && hardpoint.Attached != null) {
			if (Input.GetButtonDown("Fire1")) {
				EgoEvents<UseEvent>.AddEvent(new UseEvent(egoComponent, hardpoint.Attached));
			}
			if (Input.GetButtonDown("Drop")) {
				EgoEvents<DetachEvent>.AddEvent(new DetachEvent(hardpoint.Attached));
			}
		}
	}
}