using UnityEngine;
using JetBrains.Annotations;
using System.Security.Cryptography;

public abstract class Entity : MonoBehaviour {
	private Tool equipped;

	// Use this for initialization
	public virtual void Init<Collider, Movement>(Sprite sprite) where Movement: Motion where Collider: Collider2D {
		// Initialize given:
		// Motion Component
		// Rigidbody2D
		// Collider
		gameObject.AddComponent<Rigidbody2D>();
		gameObject.AddComponent<SpriteRenderer>().sprite = sprite;
		gameObject.AddComponent<Collider>();
		gameObject.AddComponent<Movement>();
	}

	void Equip(Tool tool) {
		equipped.EquippedBy(null);
		equipped = tool;
		equipped.EquippedBy(this);
	}
}
