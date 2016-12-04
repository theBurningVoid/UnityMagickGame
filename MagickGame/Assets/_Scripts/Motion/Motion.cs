using UnityEngine;
using System.Collections;
using System;

/**
 * This class is meant as both a means of controlling the motion of entities and spells, and
 * to allow for detailed customization of motion without making a new controller.
 * 
 * Extend this to create new steering behaviors, but beware that any object should only ever have one
 * component subclassing Motion.
**/
public abstract class Motion : MonoBehaviour {
	public float maxSpeed = 5;

	public abstract void SetAngle (float theta);

	public abstract void SetDirection (Vector2 directionVector);
}