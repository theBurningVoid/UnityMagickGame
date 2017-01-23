using UnityEngine;
using System.Collections;

public class FullGridWingContoller : MonoBehaviour {
	public Tile.TileTypePalette wingTileTypePalette;
	public GameObject floorObjPrefab;

	private Tile.TileType[,] TileTypeMap;

	// Use this for initialization
	void Start () {
		
	}

	public Tile.TileType[,] GenerateTileTypeMap()
	{





		return null;
	}
	
	public void Generate()
	{
		//dual nested for loops for testing
		for (int x = 0; x < 250; x++) {
			for (int y = 0; y < 250; y++) {
				Instantiate (floorObjPrefab, new Vector2 (x, y), Quaternion.identity, this.transform);
			}
		}
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
