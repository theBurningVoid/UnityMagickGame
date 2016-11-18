using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
	Vector2 movementInputVector = new Vector2();

	private Tool equipped;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        //Set velocity and rotation manually. WARNING: These aren't assured to interact properly in the physics simulation.
        //Similarly, if forces and torques are used, do updating in FixedUpdate()
        Rigidbody2D body = this.GetComponent<Rigidbody2D>();

        //Velocity is set to the unit vector of the direction it represents, scaled to the character's speed variable.
		movementInputVector.Set(Input.GetAxisRaw(InputUtilities.axisX), Input.GetAxisRaw(InputUtilities.axixY));
		if(movementInputVector.magnitude > 1) movementInputVector.Normalize();
        body.velocity = movementInputVector*speed;

		//Sets rotation to the angle from the object position to the mouse position translated to world coordinates.
        //Beware that if changed to use velocity or torque, object will turn 360 deg when going from -180 to 180 or vice versa
		Vector2 mousePos = VectorUtilities.GetOrthographicVector(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        float targetAngle = Mathf.Atan2(mousePos.y - body.position.y, mousePos.x - body.position.x)*Mathf.Rad2Deg;
	    body.rotation = targetAngle;
	}

    void FixedUpdate()
    {
        
    }

	void Equip(Tool tool) {
		equipped.EquippedBy(null);
		equipped = tool;
		equipped.EquippedBy(this.gameObject);
	}
}