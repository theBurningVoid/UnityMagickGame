using UnityEngine;
using System.Collections.Generic;

//monobehaviour script for converting rooms between the different wing types, as well as testing of room generation
//to be attached to the GameObject representing the room as a whole
public class RoomGenScript : MonoBehaviour {

	public enum WingType {
		Alchemy,
		Artifice,
		Dungeon
	}

	//this exists because the subfolders dividing the room, tile, etc. 
	//prefabs by wing type have the suffix "Wing" to clarify that they 
	//are dividing by wing type not by magic type where needed (example:
	//alchemy is both a type of magic and the name of a wing type)
	public static string getPrefabResourcesPath(WingType wType)
	{
		return wType.ToString () + "Wing/";
		//note the / which is used for Resources.Load instead of \
		//which is normally used for file system paths
	}
	
	public WingType wingType = WingType.Dungeon;

	[Range(5,63)]
	public int roomWidth = 5;
	[Range(5,63)]
	public int roomHeight = 5;

	public string saveAsName;

	private Dictionary<Vector2, GameObject> tiles = new Dictionary<Vector2, GameObject> ();

	public void GenerateBlankRoom () {
		
		GameObject floorTile = Resources.Load("Tiles/" + getPrefabResourcesPath(wingType) + wingType.ToString() + "Floor") as GameObject;
		GameObject wallTile = Resources.Load("Tiles/" + getPrefabResourcesPath(wingType) + wingType.ToString() + "Wall") as GameObject;
		GameObject cornerWallTile = Resources.Load("Tiles/" + getPrefabResourcesPath(wingType) + wingType.ToString() + "Corner") as GameObject;

		#region TileInputValidation
		if (floorTile == null) {
			Debug.Log ("floorTile is null, perhaps the asset has been moved/deleted or the path Tiles/" + wingType.ToString () + "Wing/ is incorrect?");
		}
		if (wallTile == null) {
			Debug.Log ("wallTile is null, perhaps the asset has been moved/deleted or the path Tiles/" + wingType.ToString () + "Wing/ is incorrect?");
		}
		if (cornerWallTile == null) {
			Debug.Log ("cornerWallTile is null, perhaps the asset has been moved/deleted or the path Tiles/" + wingType.ToString () + "Wing/ is incorrect?");
		}
		if (floorTile == null || wallTile == null || cornerWallTile == null) {
			Debug.Log ("Not all of the tiles loaded correctly, aborting room generation.");
			return;
		}
		#endregion

		ClearRoom ();

		Transform roomTran = new GameObject ("Room").transform;
		roomTran.SetParent (this.transform);

		
		Quaternion rightEdge = Quaternion.Euler(0, 0, 90);
		Quaternion topEdge = Quaternion.Euler(0, 0, 180);
		Quaternion leftEdge = Quaternion.Euler(0, 0, 270);


		#region CornerTileCreation
		Vector2 coords = new Vector2 (0, 0);
		tiles.Add (coords, Instantiate (cornerWallTile, coords, Quaternion.identity, roomTran) as GameObject);//bottomLeft corner

		coords = new Vector2 (roomWidth - 1, 0);
		tiles.Add (coords, Instantiate (cornerWallTile, coords, rightEdge, roomTran) as GameObject);//bottomRight corner

		coords = new Vector2 (roomWidth - 1, roomHeight - 1);
		tiles.Add (coords, Instantiate (cornerWallTile, coords, topEdge, roomTran) as GameObject);//topRight corner

		coords = new Vector2 (0, roomHeight - 1);
		tiles.Add (coords, Instantiate (cornerWallTile, coords, leftEdge, roomTran) as GameObject);//topLeft corner
		#endregion

		#region WallTileCreation
		for (int i = 1; i < roomWidth - 1; i++) {//from left to right 
			coords = new Vector2 (i, 0);//bottom edge of walls
			tiles.Add (coords, Instantiate (wallTile, coords, Quaternion.identity, roomTran) as GameObject);

			coords = new Vector2 (i, roomHeight - 1);//top edge of walls
			tiles.Add (coords, Instantiate (wallTile, coords, topEdge, roomTran) as GameObject);
		}

		for (int i = 1; i < roomHeight - 1; i++) {//bottom to top 
			coords = new Vector2 (roomWidth - 1, i);//right edge of walls
			tiles.Add (coords, Instantiate (wallTile, coords, rightEdge, roomTran) as GameObject);

			coords = new Vector2 (0, i);//left edge of walls
			tiles.Add (coords, Instantiate (wallTile, coords, leftEdge, roomTran) as GameObject);
		}
		#endregion

		#region FloorTileCreation
		//floor tiles column by column left to right, bottom to top
		for (int x = 1; x < roomWidth - 1; x++) {
			for (int y = 1; y < roomHeight - 1; y++) {
				coords = new Vector2 (x, y);
				tiles.Add (coords, Instantiate (floorTile, coords, Quaternion.identity, roomTran) as GameObject);
			}
		}
		#endregion




		#region PolygonColliderCreation
		PolygonCollider2D pCol = roomTran.gameObject.AddComponent<PolygonCollider2D>();
		pCol.pathCount = 2;

		//setting up first path, which defines the outer bounds
		Vector2[] path1 = new Vector2[4];
		path1 [0] = new Vector2 (0, 0);//bottomLeft
		path1 [1] = new Vector2 (roomWidth, 0);//bottomRight
		path1 [2] = new Vector2 (roomWidth, roomHeight);//topRight
		path1 [3] = new Vector2 (0, roomHeight);//topBottom
		//setting up second path, which defines the inner bounds (ie the bounds the player will be interacting with)
		Vector2[] path2 = new Vector2[4];
		path2 [0] = new Vector2 (1, 1);//bottomLeft
		path2 [1] = new Vector2 (roomWidth - 1, 1);//bottomRight
		path2 [2] = new Vector2 (roomWidth - 1, roomHeight - 1);//topRight
		path2 [3] = new Vector2 (1, roomHeight - 1);//topBottom

		pCol.SetPath (0, path1);
		pCol.SetPath (1, path2);

		//this way a point vertex of (0,0) will be the bottomLeft corner of the bottomleft corner tile
		pCol.offset = new Vector2 (-0.5f, -0.5f);
		#endregion
	}

	//destroys the child GameObject (that represents the room) from this room generator and clears the dictionary references to the tiles on the childto make it a clear room
	public void ClearRoom () {
		//destroy all tiles
		tiles.Clear ();
		if (this.transform.childCount > 0)
			DestroyImmediate (this.transform.GetChild (0).gameObject);
		else
			Debug.Log ("Nothing needed to be cleared");
	}

}