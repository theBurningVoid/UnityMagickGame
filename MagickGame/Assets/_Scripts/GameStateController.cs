using UnityEngine;
using System.Collections;

public class GameStateController : MonoBehaviour {

	public class PlayerEntity: Entity {
		void Start() {
			Init<CircleCollider2D, MotionFlawless> (Resources.Load("player", typeof(Sprite)) as Sprite);
		}
	}

	// Use this for initialization
	void Start () {
		GameObject g = new GameObject ();
		g.AddComponent<PlayerController>().Init<PlayerEntity>();
		//Instantiate (g);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
