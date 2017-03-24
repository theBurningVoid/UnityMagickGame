using UnityEngine;
using System.Collections;

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


	public void GenerateRoom () {
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

		}

	}

	//removes all tiles and room defining components from this room to make it a blank or clear room
	public void ClearRoom () {
		MiscUtilities.DestroyImmediateAllChildren (this.transform);

	}

}