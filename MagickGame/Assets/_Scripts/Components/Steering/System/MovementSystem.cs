using Components.Steering.Event;
using UnityEngine;

// Deals with updating the motion of entities

namespace Components.Steering.System {
	public class MovementSystem : EgoSystem<EgoConstraint<MovementInput>> {
		public override void Start() {
			EgoEvents<SetVelocityByEvent>.AddHandler(Handle);
			EgoEvents<RotateToEvent>.AddHandler(Handle);
		}

		public override void Update() {
			constraint.ForEachGameObject((egoComponent, movementInput) => {
					float horizontal = Input.GetAxisRaw(movementInput.HorizontalAxis);
					float vertical = Input.GetAxisRaw(movementInput.VerticalAxis);
					EgoEvents<SetVelocityByEvent>.AddEvent(new SetVelocityByEvent(egoComponent, new Vector2(horizontal, vertical)));

					Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
					float theta = InputUtilities.AngleBetween(egoComponent.transform.position, cursorPos);
					EgoEvents<RotateToEvent>.AddEvent(new RotateToEvent(egoComponent, theta));
				}
			);
		}

		void Handle(SetVelocityByEvent e) {
			Rigidbody2D rigidbody2D;
			MovementLimiter movementLimiter;
			if (e.Actor.TryGetComponents(out rigidbody2D) && e.Actor.TryGetComponents(out movementLimiter)) {
				if (e.PercentMaxVelocity.magnitude > 1) {
					e.PercentMaxVelocity.Normalize();
				}
				rigidbody2D.velocity = e.PercentMaxVelocity*movementLimiter.MaxLinearSpeed;
			}
		}

		void Handle(RotateToEvent e) {
			Rigidbody2D rigidbody2D;
			if (e.Actor.TryGetComponents(out rigidbody2D)) {
				rigidbody2D.MoveRotation(e.TargetFacing*Mathf.Rad2Deg);
			}
		}
	}
}