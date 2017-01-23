﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Tile {
	public class TileScript : MonoBehaviour {
		public void UpdateVisualTileType(TileType newType)
		{
			SpriteRenderer sRen = gameObject.GetComponent<SpriteRenderer>();
			BoxCollider2D bColl = gameObject.GetComponent<BoxCollider2D>();
			if (newType == null) {//disable all components (except for this script) for empty tiles
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

			bColl.enabled = newType.roleID == TileRoleID.FullWall;
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

		public TileData(TileType tType){
			_tileType = tType;
			_tileGO = null;
		}
	}

	public enum TileRoleID{
								FullWall, //regular wall with 4 sided collision
								PlainFloor //regular floor tile purely for aesthetics
	}

	//this class is meant to represent a particular type of tile and its basic properties like texture and facename as well as staticly holding all current available tiletypes
	[CreateAssetMenu()]
	public class TileType : ScriptableObject {
		public Sprite mainSprite;
		public string spriteSortingLayerName;
		public string faceName;//the name that would be displayed ingame for the tiletype
		public TileRoleID roleID;//is it a wall, floor, door, etc.
	}

	[CreateAssetMenu()]
	public class TileTypePalette : ScriptableObject {
		public List<TileType> tileTypes = new List<TileType>();
	}
}