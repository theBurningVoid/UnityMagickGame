using UnityEngine;
using System.Collections;
using System;

public class Chase : MonoBehaviour {
	//following
	public Vector2 following;
	
	// Update is called once per frame
	void Update () {
		//request of motion to move towards target
		Motion myMotion = GetComponent <Motion> ();
		myMotion.SetDirection ((Vector2)(transform.position) - following);
	}
}
