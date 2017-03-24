using UnityEngine;

namespace Controllers {
	public class GameStateController : MonoBehaviour {

		// Use this for initialization
		void Start() {
			Ego.AddGameObject(TemplateEntities.GeneratePlayer().gameObject);
			Ego.AddGameObject(TemplateEntities.GenerateGun().gameObject);
			//Ego.AddGameObject(EntityFactory.generate ("Laser Gun", TemplateEntities.laserGun));
			//EntityFactory.generate ("Zombie", TemplateEntities.zombie).SetActive (true);
		}
	}
}