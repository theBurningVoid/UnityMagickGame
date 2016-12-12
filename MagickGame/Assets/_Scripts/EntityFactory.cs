using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

namespace AssemblyCSharp
{
	public static class EntityFactory
	{
		public static GameObject generate(params ComponentWrapper[] components) {
			GameObject entity = new GameObject ();
			foreach(ComponentWrapper c in components) {
				entity.AddComponent (c.value);
				if(c.action != null) c.action (c.value);
			}
			return entity;
		}

		public static Archetype buildArchetype(params ComponentWrapper[] components) {
			return new Archetype (components);
		}

		public class Archetype {
			List<ComponentWrapper> components;

			public Archetype(ComponentWrapper[] components) {
				this.components = new List<ComponentWrapper>();
				this.components.AddRange (components);
			}

			public Archetype with(ComponentWrapper[] components) {
				List<ComponentWrapper> list = new List<ComponentWrapper> ();
				list.AddRange (this.components);
				foreach (ComponentWrapper t in components) {
					if (list.FindAll (x => x.value.IsInstanceOfType (t)).Count == 0) {
						list.Add (t);
					}
				}
				return new Archetype (list.ToArray ());
			}

			public Archetype without(ComponentWrapper[] components) {
				List<ComponentWrapper> list = new List<ComponentWrapper> ();
				list.AddRange (this.components);
				foreach(ComponentWrapper t in components) {
					list.RemoveAll (x => x.value.IsInstanceOfType (t));
				}
				return new Archetype (list.ToArray ());
			}

			public static implicit operator ComponentWrapper[](Archetype a) {
				return a.components.ToArray ();
			}
		}
	}
	public struct ComponentWrapper {
		public System.Type value;
		public System.Action<System.Type> action;

		public ComponentWrapper(System.Type value, System.Action<System.Type> action) {
			this.value = value;
			this.action = action;
		}

		public static implicit operator ComponentWrapper(System.Type t) {
			return new ComponentWrapper (t, null);
		}
	}
}

