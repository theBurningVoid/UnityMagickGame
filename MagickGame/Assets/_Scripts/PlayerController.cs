using UnityEngine;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using UnityEditor;

public sealed class PlayerController : MonoBehaviour
{
	// Use this for initialization
	void Start () {
		if (gameObject.GetComponent<Motion> () == null) {
			//error
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


	}
}