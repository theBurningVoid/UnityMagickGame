using Components.Action.Event;

namespace Components.Action.System {
	class ActionSystem: EgoSystem {
		public override void Start() {
			EgoEvents<InteractEvent>.AddHandler(Handle);
			EgoEvents<UseEvent>.AddHandler(Handle);
		}

		// TODO: Replace anti-pattern of components storing functionality
		// Actions should be handled through the AI and Steering/Pathfinding

		// Handles calling interaction function
		void Handle(InteractEvent e) {
			Interactive interactive;
			if (e.Object.TryGetComponents(out interactive)) {
				interactive.InteractAction(e.Actor);
			}
		}

		// Handles calling use function
		void Handle(UseEvent e) {
			Useable useable;
			if (e.Object.TryGetComponents(out useable)) {
				useable.UseAction(e.Actor);
			}
		}
	}
}
