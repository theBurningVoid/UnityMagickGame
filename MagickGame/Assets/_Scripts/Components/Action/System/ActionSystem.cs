using Components.Action.Event;
using UnityEngine;

namespace Components.Action.System {
	class ActionSystem: EgoSystem {
		public override void Start() {
			EgoEvents<InteractEvent>.AddHandler(Handle);
			EgoEvents<UseEvent>.AddHandler(Handle);
		}

		void Handle(InteractEvent e) {
			Interactive interactive;
			if (e.Object.TryGetComponents(out interactive)) {
				interactive.InteractAction(e.Actor);
			}
		}

		void Handle(UseEvent e) {
			Useable useable;
			if (e.Object.TryGetComponents(out useable)) {
				useable.UseAction(e.Actor);
			}
		}
	}
}
