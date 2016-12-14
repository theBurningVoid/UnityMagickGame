using UnityEngine;
using System.Collections;
using Tile;

public class WorldController : MonoBehaviour {
	TileData[,] worldTileData;

	public int worldWidth = 100;
	public int worldHeight = 100;

	void Start()
	{
		PreInitializeWorld ();


	}

	void PreInitializeWorld()
	{
		worldTileData = new TileData[worldWidth,worldHeight];

		TileType.clearAndInitializeTileTypes (true);

		for (int x = 0; x < worldWidth; x++) {
			for (int y = 0; y < worldWidth; y++) {
				worldTileData [x,y] = new TileData ("Empty");
			}
		}
	}

}