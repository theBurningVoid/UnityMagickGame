using UnityEngine;
using System.Collections;
using System;

public class MotionFlawless : Motion {
	public override void SetAngle(float theta) {
		Rigidbody2D body = gameObject.GetComponent<Rigidbody2D> ();

		body.MoveRotation (theta*Mathf.Rad2Deg);
	}

	public override void SetDirection(Vector2 directionVector) {
		Rigidbody2D body = gameObject.GetComponent<Rigidbody2D> ();

		if (directionVector.magnitude > 1) {
			directionVector.Normalize();
		}

		body.velocity = directionVector * maxSpeed;
	}
}