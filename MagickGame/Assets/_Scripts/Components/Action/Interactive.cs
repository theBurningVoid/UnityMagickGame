using System;
using UnityEngine;

// Object's response to being interacted with
namespace Components.Action {
	[DisallowMultipleComponent]
	class Interactive: MonoBehaviour {
		public Action<EgoComponent> InteractAction;

		public static GameObject Initialize(GameObject entity, Action<EgoComponent> action) {
			Interactive comp = entity.AddComponent<Interactive>();
			comp.InteractAction = action;
			return entity;
		}
	}
}