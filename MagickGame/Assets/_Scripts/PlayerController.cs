using UnityEngine;
using System.Collections;
using System.Xml.Schema;

public class PlayerController : MonoBehaviour
{
    public float speed = 30000;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
        //Set velocity and rotation manually. WARNING: These aren't assured to interact properly in physics interactions.
        //Similarly, if forces and torques are used, do updating in FixedUpdate()
        Rigidbody2D body = this.GetComponent<Rigidbody2D>();

        //Velocity is set to the unit vector of the direction it represents, scaled to the character's speed variable.
        //Seems to be a stopping delay if directional button is held, but not when just pressed and released.
        Vector2 velocity = body.velocity;
        velocity.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        velocity.Normalize();
        body.velocity = ScaleVectorByScalar(velocity, speed*Time.deltaTime);

        //Sets rotation to the angle between the mouse position translated to world coordinates and object position.
        //Beware that if changed to use velocity or torque, object will turn 360 deg when going from -180 to 180 or vice versa
        Vector2 mousePos = GetOrthographicVector(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        float targetAngle = Mathf.Atan2(mousePos.y - body.position.y, mousePos.x - body.position.x)*Mathf.Rad2Deg;
	    body.rotation = targetAngle;
	}

    void FixedUpdate()
    {
        
    }

    Vector2 ScaleVectorByScalar(Vector2 vec, float scalar) {
        vec.Set(vec.x*scalar, vec.y*scalar);
        return vec;
    }

    Vector2 GetOrthographicVector(Vector3 vec) {return new Vector2(vec.x, vec.y);}
}
