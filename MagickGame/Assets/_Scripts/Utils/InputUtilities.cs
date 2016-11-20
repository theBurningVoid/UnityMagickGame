using UnityEngine;
using System.Collections;

//This may be useless, but I haven't found a similar resource in unity yet.
public class InputUtilities {
	public const string axisX = "Horizontal";
	public const string axisY = "Vertical";
	private static Vector2 tempVector = new Vector2();

	public static Vector2 GetDualAxis(string axis1 = axisX, string axis2 = axisY) {
		tempVector.Set (Input.GetAxisRaw (axis1), Input.GetAxisRaw (axis2));
		return tempVector;
	}

	public static float AngleBetween(Vector2 pos, Vector2 target) {
		return Mathf.Atan2 (target.y - pos.y, target.x - pos.x);
	}
}
