using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class GameStateController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		EntityFactory.generate (typeof(PlayerEntity), typeof(PlayerController));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	class PlayerEntity: Entity {
		void Start() {
			Init<CircleCollider2D, MotionFlawless> (Resources.Load("player", typeof(Sprite)) as Sprite);
		}
	}
}
