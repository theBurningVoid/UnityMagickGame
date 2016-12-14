using UnityEngine;
using System.Collections;
using Tile;

public class WorldController : MonoBehaviour {
	TileData[,] worldTileData;

	private int worldWidth = 100;
	private int worldHeight = 100;

	public int minNumRooms = 1;
	public int maxNumRooms = 1;
	public int minRoomSize = 1;
	public int maxRoomSize = 1;

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