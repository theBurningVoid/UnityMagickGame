using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Components.Action.Event {
	class UseEvent {
		public readonly EgoComponent Actor, Object;

		public UseEvent(EgoComponent actor, EgoComponent obj) {
			Actor=actor;
			Object=obj;
		}
	}
}
