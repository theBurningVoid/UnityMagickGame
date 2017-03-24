using UnityEngine;
using System;
using Assets._Scripts;
using Components.Attachment.Event;
using Components.Steering;
using Attachments;
using Components.Action;
using Components.AI.Tree.Branch;
using Components.AI.Tree.Leaf;
using Components.AI.Tree.Selector;
using Components.Attachment;
using Components.Behavior_Tree;
using Components.Steering.Event;

public class EntityFactory
{
	public static EgoComponent GenerateBullet() {
		return EntityBuilder.Generate().WithPhysics(typeof(CircleCollider2D), .2f).WithGraphics("Images/BaseTestingCircle").WithMotion();
	}

	public static EgoComponent GenerateGun() {
		EntityBuilder entity = EntityBuilder.Generate().WithPhysics(typeof(BoxCollider2D), .5f).WithGraphics("Images/gun");
		Interactive c = Ego.AddComponent<Interactive>(entity);
		c.InteractAction = e => EgoEvents<AttachEvent>.AddEvent(new AttachEvent(c.GetComponent<EgoComponent>(), e));
		Ego.AddComponent<Mountpoint>(entity);
		Useable u = Ego.AddComponent<Useable>(entity);
		u.UseAction = e => {
			Transform transform = u.transform;
			double theta = transform.rotation.eulerAngles.z*Mathf.Deg2Rad;
			Vector2 force = new Vector2((float) Math.Cos(theta), (float) Math.Sin(theta));
			force.Normalize();
			// generate new projectile, add motion in direction at speed

			EgoComponent bullet = Ego.AddGameObject(GenerateBullet().gameObject);
			bullet.transform.rotation = transform.rotation;
			bullet.transform.position = transform.position;
			bullet.gameObject.SetActive(true);
			EgoEvents<SetVelocityByEvent>.AddEvent(new SetVelocityByEvent(bullet, force));
		};
		return entity;
	}

	public static EgoComponent GenerateCreature() {
		EntityBuilder entity = EntityBuilder.Generate().WithPhysics(typeof(CircleCollider2D)).WithMotion();
		Ego.AddComponent<Hardpoint>(entity);
		return entity;
	}

	public static EgoComponent GeneratePlayer() {
		EntityBuilder entity = EntityBuilder.Generate().WithPhysics(typeof(CircleCollider2D)).WithMotion().WithGraphics("Images/player");
		Ego.AddComponent<MovementInput>(entity);
		Ego.AddComponent<Hardpoint>(entity);
		Ego.AddComponent<BehaviorTree>(entity).TrunkNode = 
		new SelectorAll(
			new ButtonPressed(
				new Drop(), "Drop"),
			new ButtonPressed(
				new Interact(), "Interact"),
			new ButtonPressed(
				new Use(), "Fire1")
			);

		return entity;
	}
}