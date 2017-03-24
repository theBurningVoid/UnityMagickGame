using System;
using UnityEngine;

// Object's response to being interacted with
namespace Components.Action {
	[DisallowMultipleComponent]
	class Interactive: MonoBehaviour {
		public Action<EgoComponent> InteractAction;
	}
}