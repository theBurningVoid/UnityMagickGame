using UnityEngine;
using System.Collections;
using System;
using System.Reflection;

public class FireProjectile : BranchNode {
	// Projectile contains a rigidbody
	public GameObject projectile;

	public FireProjectile(GameObject projectile){
		this.projectile = projectile;
	}

	public override State Act (BranchNode parent)
	{
		double theta = transform.rotation.eulerAngles.z*Mathf.Deg2Rad;
		Vector2 force = new Vector2 ((float)Math.Cos (theta), (float)Math.Sin (theta));
		force.Normalize ();
		// generate new projectile, add motion in direction at speed
		GameObject bullet = Instantiate (projectile);
		bullet.transform.rotation = transform.rotation;
		bullet.transform.position = transform.position;
		bullet.SetActive (true);
		bullet.GetComponent <Motion>().SetDirection(force);

		return State.SUCCESS;
	}
}
