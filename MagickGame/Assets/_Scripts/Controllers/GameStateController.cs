using UnityEngine;
using System;

public class GameStateController : MonoBehaviour {
	public static EntityFactory.Archetype gun = EntityFactory.buildArchetype (typeof(Rigidbody2D), typeof(PolygonCollider2D));

	public static EntityFactory.Archetype creature = EntityFactory.buildArchetype (typeof(Rigidbody2D), typeof(CircleCollider2D),
		typeof(MotionFlawless));
		
	public static EntityFactory.Archetype player = creature.add(sprite("player"), typeof(Held), typeof(PlayerController));

	public static ComponentWrapper sprite(String name) {
		return new ComponentWrapper (typeof(SpriteRenderer), (Component c) => ((SpriteRenderer)c).sprite = 
			Resources.Load ("Images/" + name, typeof(Sprite)) as Sprite);
	}

	// Use this for initialization
	void Start () {
		EntityFactory.generate (player);
		EntityFactory.generate (gun);
	}
}
