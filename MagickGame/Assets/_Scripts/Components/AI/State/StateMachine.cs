using System;
using System.Collections.Generic;
using UnityEngine;

namespace Components.AI.State {
	[DisallowMultipleComponent]
	public class StateMachine : MonoBehaviour {
		public Dictionary<String, State> States;

		public StateMachine(Tuple<String, State>[] states) {
			States = new Dictionary<string, State>();
			foreach (Tuple<String, State> state in states) {
				States.Add(state.first, state.second);
			}
		}

		public class State {
			public Component[] StateComponents;

			public State(Component[] stateComponents) {
				StateComponents = stateComponents;
			}
		}
	}
}