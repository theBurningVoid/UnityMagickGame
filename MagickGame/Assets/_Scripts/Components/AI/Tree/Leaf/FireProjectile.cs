using UnityEngine;
using System.Collections;
using System;
using System.Reflection;
using Components.AI.Tree;
using Components.Behavior_Tree;

public class FireProjectile : TreeNode {
	// Projectile contains a rigidbody
	public GameObject projectile;

	public FireProjectile(GameObject projectile){
		this.projectile = projectile;
	}

	public override State Act (EgoComponent root) {
		Transform transform = root.transform;
		double theta = transform.rotation.eulerAngles.z*Mathf.Deg2Rad;
		Vector2 force = new Vector2 ((float)Math.Cos (theta), (float)Math.Sin (theta));
		force.Normalize ();
		// generate new projectile, add motion in direction at speed

		EgoComponent bullet = Ego.AddGameObject(projectile);
		bullet.transform.rotation = transform.rotation;
		bullet.transform.position = transform.position;
		bullet.gameObject.SetActive (true);
		//bullet.GetComponent <Motion>().SetDirection(force);

		return State.SUCCESS;
	}
}
