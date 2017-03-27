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
		
		Quaternion rightEdge = Quaternion.Euler(0, 0, 90);
		Quaternion topEdge = Quaternion.Euler(0, 0, 180);
		Quaternion leftEdge = Quaternion.Euler(0, 0, 270);


		#region CornerTileCreation
		Vector2 coords = new Vector2 (0, 0);
		tiles.Add (coords, Ego.AddGameObject (Instantiate (cornerWallTile, coords, Quaternion.identity, this.transform) as GameObject).gameObject);//bottomLeft corner

		coords = new Vector2 (roomWidth - 1, 0);
		tiles.Add (coords, Ego.AddGameObject (Instantiate (cornerWallTile, coords, rightEdge, this.transform) as GameObject).gameObject);//bottomRight corner

		coords = new Vector2 (roomWidth - 1, roomHeight - 1);
		tiles.Add (coords, Ego.AddGameObject (Instantiate (cornerWallTile, coords, topEdge, this.transform) as GameObject).gameObject);//topRight corner

		coords = new Vector2 (0, roomHeight - 1);
		tiles.Add (coords, Ego.AddGameObject (Instantiate (cornerWallTile, coords, leftEdge, this.transform) as GameObject).gameObject);//topLeft corner
		#endregion

		#region WallTileCreation
		for (int i = 1; i < roomWidth - 1; i++) {//from left to right 
			coords = new Vector2 (i, 0);//bottom edge of walls
			tiles.Add (coords, Ego.AddGameObject (Instantiate (wallTile, coords, Quaternion.identity, this.transform) as GameObject).gameObject);

			coords = new Vector2 (i, roomHeight - 1);//top edge of walls
			tiles.Add (coords, Ego.AddGameObject (Instantiate (wallTile, coords, topEdge, this.transform) as GameObject).gameObject);
		}

		for (int i = 1; i < roomHeight - 1; i++) {//bottom to top 
			coords = new Vector2 (roomWidth - 1, i);//right edge of walls
			tiles.Add (coords, Ego.AddGameObject (Instantiate (wallTile, coords, rightEdge, this.transform) as GameObject).gameObject);

			coords = new Vector2 (0, i);//left edge of walls
			tiles.Add (coords, Ego.AddGameObject (Instantiate (wallTile, coords, leftEdge, this.transform) as GameObject).gameObject);
		}
		#endregion

		#region FloorTileCreation
		//floor tiles column by column left to right, bottom to top
		for (int x = 1; x < roomWidth - 1; x++) {
			for (int y = 1; y < roomHeight - 1; y++) {
				coords = new Vector2 (x, y);
				tiles.Add (coords, Ego.AddGameObject (Instantiate (floorTile, coords, Quaternion.identity, this.transform) as GameObject).gameObject);
			}
		}
		#endregion

		//make sure we are part of EgoCS
		EgoComponent egoComp = this.GetComponent<EgoComponent> ();
		if (egoComp == null) {
			Ego.AddGameObject (this.gameObject);
			egoComp = this.GetComponent<EgoComponent> ();
		}

		PolygonCollider2D pCol = Ego.AddComponent<PolygonCollider2D> (egoComp);
		pCol.pathCount = 2;

		//setting up first path, which defines the outer bounds
		Vector2[] path1 = new Vector2[4];
		path1[0] = new Vector2(0, 0);//bottomLeft
		path1[1] = new Vector2(roomWidth, 0);//bottomRight
		path1[2] = new Vector2(roomWidth, roomHeight);//topRight
		path1[3] = new Vector2(0, roomHeight);//topBottom
		//setting up second path, which defines the inner bounds (ie the bounds the player will be interacting with)
		Vector2[] path2 = new Vector2[4];
		path2[0] = new Vector2(1, 1);//bottomLeft
		path2[1] = new Vector2(roomWidth - 1, 1);//bottomRight
		path2[2] = new Vector2(roomWidth - 1, roomHeight - 1);//topRight
		path2[3] = new Vector2(1, roomHeight - 1);//topBottom

		pCol.SetPath (0, path1);
		pCol.SetPath (1, path2);

		//this way a point vertex of (0,0) will be the bottomLeft corner of the bottomleft corner tile
		pCol.offset = new Vector2(-0.5f, -0.5f);
	}

	//removes all tiles and room defining components from this room and clear the dictionary references to said tiles to make it a or clear room
	public void ClearRoom () {
		tiles.Clear ();
		MiscUtilities.DestroyImmediateAllChildren (this.transform);

//		BoxCollider2D bCol = this.GetComponent<BoxCollider2D> ();
//		while (bCol != null) {
//			DestroyImmediate (bCol);
//			bCol = this.GetComponent<BoxCollider2D> ();
//		}
	}

}