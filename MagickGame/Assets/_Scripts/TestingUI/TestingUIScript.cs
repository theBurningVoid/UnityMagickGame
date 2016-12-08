using UnityEngine;
using System.Collections.Generic;

public class TestingUIScript : MonoBehaviour {
	private Dictionary<Vector2, GameObject> tiles = new Dictionary<Vector2, GameObject> ();
	//private List<GameObject> tiles = new List<GameObject>();

	public GameObject floorTilePrefab;
	public GameObject wallTilePrefab;

	public enum TilePlacingMode {Empty,Floor,Wall};

	public TilePlacingMode placingMode = TilePlacingMode.Empty;

	public void tileGUIClicked(Ray mousePositionRay)
	{
		Vector2 worldClickPosition = mousePositionRay.origin;//this assumes that we keep the scene window camera to orthigraphic/2D
		//Debug.Log("left click at world coords: " + worldClickPosition.ToString());

		Vector2 tileSpawnCoords = VectorUtilities.FloorVectorDataToInts(worldClickPosition + new Vector2(0.5f, 0.5f));// we add 0.5 to account for the fact that the tile object's coords line up with the center of the sprite
		//Debug.Log("TileSpawnCoords: " + tileSpawnCoords);

		if (tiles.ContainsKey (tileSpawnCoords)) {//regardless if we are trying to remove a tile or we are setting it to something else if a tile exists at the coords in question it needs to be destroyed
			GameObject tile = tiles[tileSpawnCoords];
			tiles.Remove (tileSpawnCoords);
			GameObject.DestroyImmediate (tile);
		} 

		switch (placingMode) {//creates a new gameobject at the correct location using the apropriate prefab and either adds it to the dictionary with the key being its location or overwrites the gameobject already at said location
		case TilePlacingMode.Floor:
			tiles.Add(tileSpawnCoords, (GameObject) Instantiate (floorTilePrefab, tileSpawnCoords, Quaternion.identity, this.transform));
			break;

		case TilePlacingMode.Wall:
			tiles.Add(tileSpawnCoords, (GameObject) Instantiate (wallTilePrefab, tileSpawnCoords, Quaternion.identity, this.transform));
			break;
		}







		//GameObject tile = Instantiate (prefabToUse, tileSpawnCoords, Quaternion.identity, this.transform);
	}
}
