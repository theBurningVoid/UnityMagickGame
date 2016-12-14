using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Tile {
	public class TileScript : MonoBehaviour {
		public void UpdateVisualTileType(TileType newType)
		{
			SpriteRenderer sRen = gameObject.GetComponent<SpriteRenderer>();
			BoxCollider2D bColl = gameObject.GetComponent<BoxCollider2D>();
			if (newType == null || newType == TileType.tileTypeEmpty) {//disable all components (except for this script) for empty tiles
				sRen.enabled = false;
				bColl.enabled = false;
				return;
			}
			if (newType.mainSprite != null && newType.spriteSortingLayerName != null) {
				sRen.sprite = newType.mainSprite;
				sRen.sortingLayerID = SortingLayer.NameToID (newType.spriteSortingLayerName);//this will return the default sortinglayer id if the given name is not the name of a sortinglayer
				sRen.enabled = true;
			} else {
				sRen.enabled = false;
			}

			bColl.enabled = newType.hasWallCollision;
		}
	}



	public class TileData {
		private TileType _tileType;
		public TileType tileType {
			get{ return _tileType; }
			set {
				if (tileGO != null) {
					TileType oldType = _tileType;
					_tileType = value;
					if (oldType != _tileType)
						tileGO.GetComponent<TileScript> ().UpdateVisualTileType (_tileType);
				} else
					_tileType = value;
			}
		}

		private GameObject _tileGO;//the visual gameobject that is currently representing this TileData object
		public GameObject tileGO {
			get{ return _tileGO; }
			set {
				if (value != null) {//is a new gameobject representing this tile
					value.GetComponent<TileScript> ().UpdateVisualTileType (_tileType);
					if (_tileGO != null) {// is this TileData already represented by another GameObject
						//TODO: do we need to tell the GameObject we were represented by that it no longer represents us
					}
				} else {
					//TODO: do we need to tell the GameObject we were represented by that it no longer represents us
				}
				_tileGO = value;
			}
		}

		public TileData(int typeID){
			_tileType = TileType.getType (typeID);
			_tileGO = null;
		}

		public TileData(string typeName){
			_tileType = TileType.getType (typeName);
			_tileGO = null;
		}

	}



	//this class is meant to represent a particular type of tile and its basic properties like texture and facename as well as staticly holding all current available tiletypes
	public class TileType {
		private static List<TileType> allTileTypes;
		public readonly static TileType tileTypeEmpty = new TileType ("Empty", null, null, false);//this can't be const instead of readonly static because I'm using a method to initialize it

		public readonly int typeID;//may end up removing this field
		public readonly Sprite mainSprite;
		public readonly string spriteSortingLayerName;
		public readonly string faceName;//the name that would be displayed ingame for the tiletype
		public readonly bool hasWallCollision;//should this type have a BoxCollider2D

		private static int nextID = 0;//the next typeID to use when generating new TileTypes

		private TileType(string fName, Sprite mSprite, string sortLName, bool wallCollision)
		{
			faceName = fName;
			mainSprite = mSprite;
			spriteSortingLayerName = sortLName;
			hasWallCollision = wallCollision;
			typeID = nextID;
		}

		public static void clearAndInitializeTileTypes(bool initTestingTypes)
		{
			allTileTypes = new List<TileType> ();
			nextID = 0;
			allTileTypes [nextID] = TileType.tileTypeEmpty;
			nextID++;

			if (initTestingTypes) {
				allTileTypes [nextID] = new TileType (TestingTileTypes.TestingFloor.ToString(), Resources.Load("Images/BasicTestingFloorTile") as Sprite, "Floor", false);
				nextID++;
				allTileTypes [nextID] = new TileType (TestingTileTypes.TestingWall.ToString(), Resources.Load("Images/BasicTestingWall") as Sprite, "Wall", true);
				nextID++;
			}
			//here we would read in the other different tileTypes' data from files
		}

		public static TileType getType(int id)
		{
			if (allTileTypes == null) {
				Debug.LogWarning("allTileTypes hasn't been initialized yet");
				return null;
			}

			if (id < 0 || id >= allTileTypes.Count) {
				Debug.LogWarning("id " + id + " is out of bounds, allTileTypes.Count is: " + allTileTypes.Count);
				return null;
			}

			return allTileTypes[id];
		}

		public static TileType getType(string name)
		{
			if (allTileTypes == null) {
				Debug.LogWarning("allTileTypes hasn't been initialized yet");
				return null;
			}

			foreach (TileType t in allTileTypes) {
				if (t.faceName.Equals (name))
					return t;
			}

			Debug.LogWarning(name + " is not the faceName of a current TileType");//could not find tiletype
			return null;
		}
	}

	public enum TestingTileTypes {TestingFloor, TestingWall};
}