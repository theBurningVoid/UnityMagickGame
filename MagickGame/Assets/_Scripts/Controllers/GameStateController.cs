using UnityEngine;
using System;

public class GameStateController : MonoBehaviour {
	EntityFactory.Archetype player = EntityFactory.buildArchetype (typeof(Rigidbody2D),
		new ComponentWrapper(typeof(SpriteRenderer), (Component c) => ((SpriteRenderer)c).sprite = 
			Resources.Load("Images/player", typeof(Sprite)) as Sprite),typeof(MotionFlawless), 
		typeof(CircleCollider2D), typeof(PlayerController));

	// Use this for initialization
	void Start () {
		EntityFactory.generate (player);
	}
}
