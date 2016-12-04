using UnityEngine;
using System.Diagnostics;

public class PlayerController : MonoBehaviour
{
	private Tool equipped;

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<MotionFlawless> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Set velocity and rotation manually. WARNING: These aren't assured to interact properly in the physics simulation.
		//Similarly, if forces and torques are used, do updating in FixedUpdate()
		Motion motion = this.gameObject.GetComponent<MotionFlawless>();

		Vector2 tempVec = InputUtilities.GetDualAxis ();

		float tempAngle = InputUtilities.AngleBetween (this.transform.position, Camera.main.ScreenToWorldPoint (Input.mousePosition));

		motion.SetAngle (tempAngle);
		motion.SetDirection (tempVec);
	}

    void FixedUpdate() {
        
    }

	void Equip(Tool tool) {
		equipped.EquippedBy(null);
		equipped = tool;
		equipped.EquippedBy(this.gameObject);
	}
}