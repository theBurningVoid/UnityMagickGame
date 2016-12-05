using System;
using System.CodeDom.Compiler;
using UnityEngine;

namespace AssemblyCSharp
{
	public class EntityFactory
	{
		//public EntityFactory instance = this;
		public GameObject generate(params System.Type[] components) {
			GameObject entity = new GameObject ();
			foreach(System.Type c in components) {
				entity.AddComponent (c);
			}
			return entity;
		}

		public Archetype buildArchetype(params System.Type[] components) {
			return new Archetype (components);
		}

		public class Archetype {
			System.Type[] components;

			public Archetype(System.Type[] components) {
				this.components = components;
			}
		}
	}
}

