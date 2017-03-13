using UnityEngine;
using System.Collections;
using System;

public class TemplateEntities
{
	public static EntityFactory.Archetype bullet = EntityFactory.buildArchetype (typeof(Rigidbody2D), sprite ("BaseTestingCircle"), 
		boxCollider (.2f, .2f), typeof(MotionFlawless));

	public static EntityFactory.Archetype gun = EntityFactory.buildArchetype (typeof(Rigidbody2D), boxCollider(.5f, .5f), 
		hardpoint (0, .5f, typeof(Hardpoint)), new ComponentWrapper(typeof(FireProjectile), 
			(Component c) => ((FireProjectile)c).projectile = EntityFactory.generate ("Bullet", bullet)), sprite ("gun"));

	public static EntityFactory.Archetype laserGun = gun.remove (typeof(FireProjectile)).add (typeof(Hitscan));

	public static EntityFactory.Archetype creature = EntityFactory.buildArchetype (typeof(Rigidbody2D), typeof(CircleCollider2D), 
		typeof(MotionFlawless));

	public static EntityFactory.Archetype player = creature.add(sprite("player"), hardpoint(.75f, 0f, typeof(Held)), 
		typeof(PlayerController));

	public static EntityFactory.Archetype zombie = creature.add (sprite ("player"), new ComponentWrapper(typeof(Chase), (Component c)
		=> ((Chase)c).following = Vector2.zero));

	public static ComponentWrapper sprite(String name) {
		return new ComponentWrapper (typeof(SpriteRenderer), (Component c) => ((SpriteRenderer)c).sprite = 
			Resources.Load ("Images/" + name, typeof(Sprite)) as Sprite);
	}

	public static ComponentWrapper boxCollider(float width, float height) {
		return new ComponentWrapper (typeof(BoxCollider2D), (Component c) => ((BoxCollider2D)c).size = new Vector2(width, height));
	}

	public static ComponentWrapper circleCollider(float radius) {
		return new ComponentWrapper (typeof(CircleCollider2D), (Component c) => ((CircleCollider2D)c).radius = radius);
	}

	public static ComponentWrapper hardpoint(float x, float y, Type type) {
		return new ComponentWrapper (type, (Component c) => ((Hardpoint)c).setHardpoint (new Vector2(x, y)));
	}
}