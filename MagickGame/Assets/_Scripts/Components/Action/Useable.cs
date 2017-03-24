using System;
using UnityEngine;

// Object's response to being used
namespace Components.Action {
	[DisallowMultipleComponent]
	class Useable: MonoBehaviour {
		public Action<EgoComponent> UseAction;
	}
}
