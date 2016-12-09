using UnityEngine;

public class VectorUtilities {
	//public static Vector2 GetOrthographicVector(Vector3 vec) {return new Vector2(vec.x, vec.y);}

	public static Vector4 FloorVectorDataToInts(Vector4 input)
	{
		return new Vector4 (Mathf.FloorToInt (input.x), Mathf.FloorToInt (input.y), Mathf.FloorToInt (input.z), Mathf.FloorToInt (input.w));
	}
}