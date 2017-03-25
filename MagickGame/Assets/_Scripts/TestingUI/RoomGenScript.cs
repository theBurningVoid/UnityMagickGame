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

		if (floorTile == null) {
			Debug.Log ("floorTile is null, perhaps the asset has been moved/deleted or the path Tiles/" + wingType.ToString() + "Wing/ is incorrect?");
		}
		if (wallTile == null) {
			Debug.Log ("wallTile is null, perhaps the asset has been moved/deleted or the path Tiles/" + wingType.ToString() + "Wing/ is incorrect?");
		}
		if (cornerWallTile == null) {
			Debug.Log ("cornerWallTile is null, perhaps the asset has been moved/deleted or the path Tiles/" + wingType.ToString() + "Wing/ is incorrect?");
		}
		if (floorTile == null || wallTile == null || cornerWallTile == null) {
			Debug.Log ("Not all of the tiles loaded correctly, aborting room generation.");
			return;
		}
		ClearRoom ();
		
		Quaternion left = Quaternion.Euler(0, 0, 90);
		Quaternion reverse = Quaternion.Euler(0, 0, 180);
		Quaternion right = Quaternion.Euler(0, 0, 270);

		Vector2 coords = new Vector2 (0, 0);
		tiles.Add(coords, Instantiate (cornerWallTile, coords, reverse, this.transform) as GameObject);//bottomLeft corner

		for (int i = 1; i < roomWidth - 1; i++) {//bottom edge of walls from left to right 
			coords = new Vector2 (i, 0);
			tiles.Add(coords, Instantiate (wallTile, coords, reverse, this.transform) as GameObject);
		}

		coords = new Vector2 (roomWidth - 1, 0);
		tiles.Add(coords, (GameObject) Instantiate (cornerWallTile, coords, right, this.transform));//bottomRight corner

		for (int i = 1; i < roomHeight - 1; i++) {//right edge of walls from bottom to top 
			coords = new Vector2 (roomWidth - 1, i);
			tiles.Add(coords, Instantiate (wallTile, coords, right, this.transform) as GameObject);
		}

		coords = new Vector2 (roomWidth - 1, roomHeight - 1);
		tiles.Add(coords, Instantiate (cornerWallTile, coords, Quaternion.identity, this.transform) as GameObject);//topRight corner

		for (int i = 1; i < roomWidth - 1; i++) {//top edge of walls from left to right 
			coords = new Vector2 (i, roomHeight - 1);
			tiles.Add(coords, Instantiate (wallTile, coords, Quaternion.identity, this.transform) as GameObject);
		}

		coords = new Vector2 (0, roomHeight - 1);
		tiles.Add(coords, Instantiate (cornerWallTile, coords, left, this.transform) as GameObject);//topLeft corner

		for (int i = 1; i < roomHeight - 1; i++) {//left edge of walls from bottom to top 
			coords = new Vector2 (0, i);
			tiles.Add(coords, Instantiate (wallTile, coords, left, this.transform) as GameObject);
		}

		//floor tiles column by column left to right, bottom to top
		for (int x = 1; x < roomWidth - 1; x++) {
			for (int y = 1; y < roomHeight - 1; y++) {
				coords = new Vector2 (x, y);
				tiles.Add(coords, Instantiate (floorTile, coords, Quaternion.identity, this.transform) as GameObject);
			}
		}
	}

	//removes all tiles and room defining components from this room and clear the dictionary references to said tiles to make it a or clear room
	public void ClearRoom () {
		tiles.Clear ();
		MiscUtilities.DestroyImmediateAllChildren (this.transform);
	}

}