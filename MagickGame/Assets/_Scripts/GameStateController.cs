using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class GameStateController : MonoBehaviour {
	EntityFactory.Archetype player = EntityFactory.buildArchetype (typeof(Rigidbody2D), 
		//new ComponentWrapper(typeof(SpriteRenderer), (System.Type r) => ((SpriteRenderer)r).sprite = 
			//Resources.Load("player", typeof(Sprite)) as Sprite),
		typeof(MotionFlawless), typeof(CircleCollider2D), typeof(PlayerController));

	// Use this for initialization
	void Start () {
		EntityFactory.generate (player);
	}
	/*
	class PlayerEntity: Entity {
		void Start() {
			Init<CircleCollider2D, MotionFlawless> (Resources.Load("player", typeof(Sprite)) as Sprite);
		}
	}
	*/
}
