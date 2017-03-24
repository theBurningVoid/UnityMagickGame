using UnityEngine;

namespace Controllers {
	public class GameStateController : MonoBehaviour {

		// Use this for initialization
		void Start() {
			Ego.AddGameObject(EntityFactory.GeneratePlayer().gameObject);
			Ego.AddGameObject(EntityFactory.GenerateGun().gameObject);
			//Ego.AddGameObject(EntityFactory.generate ("Laser Gun", TemplateEntities.laserGun));
			//EntityFactory.generate ("Zombie", TemplateEntities.zombie).SetActive (true);
		}
	}
}