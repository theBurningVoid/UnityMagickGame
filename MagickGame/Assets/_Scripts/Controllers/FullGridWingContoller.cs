using UnityEngine;
using Tile;
using System.Collections.Generic;

public class FullGridWingContoller : MonoBehaviour {
	public TileTypePalette wingTileTypePalette;
	public GameObject floorObjPrefab;
	private TileType[,] tileTypeMap;
	public int numberOfRooms = 5;

	// Use this for initialization
	void Start () {
		
	}

	public enum FullGridRoomGenType{
		LookALike,//Generates a bunch of equally sized rectangular rooms and aligns them to a grid like in the old snes games
		Varied//Generates a bunch of varyingly sized rectangular rooms and tries to pack them together as tightly as possible
	}
	//all room sizes include the walls
	public const int minRoomSize = 5;
	public const int maxRoomSize = 25;
	public const int minRoomCount = 5;
	public const int maxRoomCount = 30;

	//method to be called for the generation of a TileTypeMap, checks input for correctness (nulls, missing tile types, out of range room size and count), outputs appropriate error messages, 
	//    and either outputs null or clamps room sizes and count then calls the appropriate method to actually generate the tileTypeMap
	//only LookALike is supported for genType at the moment
	public static TileType[,] GenerateTileTypeMap(TileTypePalette tTypePalette, FullGridRoomGenType genType, int numRooms, int roomWidth = 7, int roomHeight = 7, int roomWidthBias = 7, int roomHeightBias = 7)
	{
		if (tTypePalette == null) {Debug.LogError ("tTypePalette is null, this should not be the case"); return null;}

		TileType wall = tTypePalette.FindRole(TileRoleID.FullWall);
		TileType floor = tTypePalette.FindRole(TileRoleID.PlainFloor);

		//does the palette have a wall and floor
		if (wall == null || floor == null) {Debug.LogError ("tTypePalette does not have all the necessary TileTypes: Wall is <" + wall + "> Floor is <" + floor + ">."); return null;}

		int temp = numRooms;
		numRooms = Mathf.Clamp (numRooms, minRoomCount, maxRoomCount);
		if (numRooms != temp)
			Debug.Log ("numRooms outside range of " + minRoomCount + " to " + maxRoomCount + ", clamping to " + numRooms + ". ");

		switch (genType) {
		case FullGridRoomGenType.LookALike:
			temp = roomWidth;
			roomWidth = Mathf.Clamp (roomWidth, minRoomSize, maxRoomSize);
			if (roomWidth != temp)
				Debug.Log ("roomWidth outside range of " + minRoomSize + " to " + maxRoomSize + ", clamping to " + roomWidth + ". ");
			temp = roomHeight;
			roomHeight = Mathf.Clamp (roomHeight, minRoomSize, maxRoomSize);
			if (roomHeight != temp)
				Debug.Log ("roomHeight outside range of " + minRoomSize + " to " + maxRoomSize + ", clamping to " + roomHeight + ". ");
			return GenerateLookALikeTTypeMap (tTypePalette, roomWidth, roomHeight, numRooms);
			break;
		case FullGridRoomGenType.Varied:
			Debug.Log ("Varied genType unimplemented, returning null.");
//			temp = roomWidthBias;
//			roomWidthBias = Mathf.Clamp (roomWidthBias, minRoomSize, maxRoomSize);
//			if (roomWidthBias != temp)
//				Debug.Log ("roomWidthBias outside range of " + minRoomSize + " to " + maxRoomSize + ", clamping to " + roomWidthBias + ". ");
//			temp = roomHeightBias;
//			roomHeightBias = Mathf.Clamp (roomHeightBias, minRoomSize, maxRoomSize);
//			if (roomHeightBias != temp)
//				Debug.Log ("roomHeightBias outside range of " + minRoomSize + " to " + maxRoomSize + ", clamping to " + roomHeightBias + ". ");
//			return ...
			break;
		default:
			Debug.LogError ("Unknown genType " + genType + " used, returning null.");
			break;
		}

		return null;
	}



	private static TileType[,] GenerateLookALikeTTypeMap(TileTypePalette tTypePalette, int roomWidth, int roomHeight, int numRooms)
	{
		
		List<Vector2> roomPositions = new List<Vector2>();
		List<Vector2> doorPositions = new List<Vector2> ();
		roomPositions.Add(Vector2.zero);//starting room

		//decide on room and door placement
		for (int roomsDone = 1; roomsDone < numRooms; roomsDone++) {
			Vector2 branchOffRoom = roomPositions[Random.Range(0, roomPositions.Count)];
			//pick direction
			Vector2 direction = VectorUtilities.RandomV2Direction();

			if (!roomPositions.Contains (branchOffRoom + direction)) {//is there room for a... room here
				roomPositions.Add (branchOffRoom + direction);
				doorPositions.Add (branchOffRoom + (direction / 2.0f));
			} else {//we already made a room here
				roomsDone--;//we weren't able to make a room this round
				if (!doorPositions.Contains (branchOffRoom + (direction / 2.0f))) {//is there room for a door
					//TODO maybe have it be random whether a new door is made between 2 rooms that already exist but for now 100% chance
					doorPositions.Add (branchOffRoom + (direction / 2.0f));
				}
			}
		}
		//find the the min and max x and y values from roomPositions
		Vector2 minRoomPos = Vector2.zero;
		Vector2 maxRoomPos = Vector2.zero;
		foreach (Vector2 v in roomPositions) {
			minRoomPos = Vector2.Min (minRoomPos, v);
			maxRoomPos = Vector2.Max (maxRoomPos, v);
		}

		int numRoomsWidth = (int) (maxRoomPos.x - minRoomPos.x + 1), numRoomsHeight = (int) (maxRoomPos.y - minRoomPos.y + 1);//the width and height in rooms
		//room walls are designed to overlap at the moment
		TileType[,] output = new TileType[numRoomsWidth * (roomWidth - 1) + 1, numRoomsHeight * (roomHeight - 1) + 1];//shared walls means a -1 for each rooms width and height except for the the topmost rooms' height and the rightmost rooms' width
		TileType wall = tTypePalette.FindRole(TileRoleID.FullWall);
		TileType floor = tTypePalette.FindRole(TileRoleID.PlainFloor);

		for (int i = 0; i < roomPositions.Count; i++) {
			Vector2 correctedRoomPos = roomPositions [i] - minRoomPos;
			correctedRoomPos = Vector2.Scale(correctedRoomPos, new Vector2(roomWidth - 1, roomHeight - 1));
			for (int x = 0; x < roomWidth; x++) {
				for (int y = 0; y < roomHeight; y++) {
					if (x == 0 || x == roomWidth - 1 || y == 0 || y == roomHeight - 1)
						output [x + (int) correctedRoomPos.x, y + (int) correctedRoomPos.y] = wall;
					else
						output [x + (int) correctedRoomPos.x, y + (int) correctedRoomPos.y] = floor;
				}
			}
		}

		return output;
	}
	
	public void Generate()
	{
		tileTypeMap =  GenerateTileTypeMap (wingTileTypePalette, FullGridRoomGenType.LookALike, numberOfRooms);




		if (tileTypeMap != null) {
			for (int x = 0; x < tileTypeMap.GetLength (0); x++) {
				for (int y = 0; y < tileTypeMap.GetLength (1); y++) {
					if (tileTypeMap [x, y] != null) {
						GameObject gObj = (GameObject) Instantiate (tileTypeMap [x, y].GetPrefab (), new Vector3 (x, y), Quaternion.identity, this.transform);
						gObj.SetActive (true);
					}
				}
			}
		} else
			Debug.LogError ("tileTypeMap was returned as null");
	}

	public void ClearImmediateAllChildren()
	{
		Debug.Log (this.transform.childCount + " children to clear.");
		MiscUtilities.DestroyImmediateAllChildren (this.transform);
	}

//	void Update()
//	{
//		
//	}
}
