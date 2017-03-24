using System;
using Components.Steering;
using UnityEngine;

// Builder that creates and helps define entities (GameObjects)
namespace Entity {
	class EntityBuilder {
		public EgoComponent Entity;

		private EntityBuilder(GameObject entity) {
			Entity = Ego.AddGameObject(entity);
		}

		public static EntityBuilder Generate() {
			return new EntityBuilder(new GameObject());
		}

		public EntityBuilder WithPhysics(Type colliderType, float diameter = 1) {
			Ego.AddComponent<Rigidbody2D>(Entity);
			if (colliderType == typeof(CircleCollider2D)) {
				Ego.AddComponent<CircleCollider2D>(Entity).radius = diameter/2;
			}else if (colliderType == typeof(BoxCollider2D)) {
				Ego.AddComponent<BoxCollider2D>(Entity).size = new Vector2(diameter, diameter);
			}
			else {
				Debug.LogError("Collider type specified not supported.");
			}
			return this;
		}

		
		public EntityBuilder WithMotion() {
			Ego.AddComponent<MovementLimiter>(Entity);
			return this;
		}

		public EntityBuilder WithGraphics(String sprite) {
			Ego.AddComponent<SpriteRenderer>(Entity).sprite = Resources.Load(sprite, typeof(Sprite)) as Sprite;
			return this;
		}

		/*
		public EntityBuilder WithBehavior(params TreeNode[] nodes) {
			BehaviorTree.Initialize(Entity, nodes[0]);
			for(int i = 1; i < nodes.Length; i++) {
				//if(nodes[i-1] is  )
			}
			
			return this;
		}*/

		public static implicit operator EgoComponent(EntityBuilder b) {
			return b.Entity;
		}
	}
}
