using UnityEngine;

public class VectorUtilities {
	//public static Vector2 GetOrthographicVector(Vector3 vec) {return new Vector2(vec.x, vec.y);}

	public static Vector4 FloorVectorDataToInts(Vector4 input)
	{
		return new Vector4 (Mathf.FloorToInt (input.x), Mathf.FloorToInt (input.y), Mathf.FloorToInt (input.z), Mathf.FloorToInt (input.w));
	}


	private enum Direction{left, right, up, down}
	public static Vector2 RandomV2Direction()
	{
		Vector2 direction = Vector2.zero;

		switch ((Direction) Random.Range (0, 4)) {
		case Direction.left:
			direction = Vector2.left;
			break;
		case Direction.right:
			direction = Vector2.right;
			break;
		case Direction.up:
			direction = Vector2.up;
			break;
		case Direction.down:
			direction = Vector2.down;
			break;
		}

		return direction;
	}
}