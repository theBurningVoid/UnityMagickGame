using Entity;
using UnityEngine;

// Creates the initial state of the game by adding entities to the current scene.
namespace Controllers {
	public class GameStateController : MonoBehaviour {

		// Use this for initialization
		void Start() {
			// TODO: Replace with spawning logic
			Ego.AddGameObject(EntityFactory.GeneratePlayer().gameObject);
			Ego.AddGameObject(EntityFactory.GenerateGun().gameObject);
			//Ego.AddGameObject(EntityFactory.generate ("Laser Gun", TemplateEntities.laserGun));
			//EntityFactory.generate ("Zombie", TemplateEntities.zombie).SetActive (true);
		}
	}
}