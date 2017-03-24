using System;
using UnityEngine;

// Object's response to being used
namespace Components.Action {
	[DisallowMultipleComponent]
	class Useable: MonoBehaviour {
		public Action<EgoComponent> UseAction;

		public static Useable Initialize(GameObject entity, Action<EgoComponent> action) {
			Useable useable = entity.AddComponent<Useable>();
			useable.UseAction=action;
			return useable;
		}
	}
}
