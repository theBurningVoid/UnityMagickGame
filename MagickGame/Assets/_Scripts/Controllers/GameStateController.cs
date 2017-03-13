using UnityEngine;
using System;

public class GameStateController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		EntityFactory.generate ("Player", TemplateEntities.player).SetActive (true);
		EntityFactory.generate ("Gun", TemplateEntities.gun).SetActive (true);
		EntityFactory.generate ("Laser Gun", TemplateEntities.laserGun).SetActive (true);
		//EntityFactory.generate ("Zombie", TemplateEntities.zombie).SetActive (true);
	}
}
