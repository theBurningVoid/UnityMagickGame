using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.ComponentModel;

namespace AssemblyCSharp
{
	public static class EntityFactory
	{
		//public EntityFactory instance = this;
		public static GameObject generate(params System.Type[] components) {
			GameObject entity = new GameObject ();
			foreach(System.Type c in components) {
				entity.AddComponent (c);
			}
			return entity;
		}

		public static Archetype buildArchetype(params System.Type[] components) {
			return new Archetype (components);
		}

		public class Archetype {
			List<System.Type> components;

			public Archetype(System.Type[] components) {
				this.components = new List<System.Type>();
				this.components.AddRange (components);
			}

			public Archetype with(System.Type[] components) {
				List<System.Type> list = new List<System.Type> ();
				list.AddRange (this.components);
				foreach (System.Type t in components) {
					if (list.FindAll (x => list.Contains (x)).Count == 0) {
						list.Add (t);
					}
				}
				return new Archetype (list.ToArray ());
			}

			public Archetype without(System.Type[] components) {
				List<System.Type> list = new List<System.Type> ();
				list.AddRange (this.components);
				list.RemoveAll (x => list.Contains (x));
				return new Archetype (list.ToArray ());
			}

			public static implicit operator System.Type[](Archetype a) {
				return a.components.ToArray ();
			}
		}
	}
}

